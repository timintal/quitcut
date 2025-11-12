using System;
using System.Linq;
using ObservableCollections;
using QuitCut.Configs;
using QuitCut.Data.Database;
using R3;
using VContainer.Unity;

namespace QuitCut.Data.DataServices
{
    public enum ChallengeState
    {
        Active = 0,
        Completed = 1,
        Failed = 2,
        Claimed = 3
    }
    [Serializable]
    public class SavedChallengeInfo
    {
        public int Id;
        public ChallengeId ChallengeId;
        public DateTime StartDate;
        public DateTime EndDate;
        public ChallengeState State;
    }
    
    [Serializable]
    public class ActiveChallenge
    {
        public SavedChallengeInfo SavedData;
        
        public ReactiveProperty<ChallengeState> State = new(ChallengeState.Active);
        public ReactiveProperty<float> Progress = new(0);
        public ReactiveProperty<float> DailyLimitProgress = new(0);
        public ReactiveProperty<float> TotalLimitProgress = new(0);
    }

    public class ChallengesData : IInitializable, IDisposable
    {
        private readonly DataBaseService _dataBaseService;
        private readonly ChallengeSets _challengeSets;
        private readonly TimeProvider _timeProvider;

        CompositeDisposable _disposable;
        
        public ChallengesData(DataBaseService dataBaseService, ChallengeSets challengeSets, TimeProvider timeProvider)
        {
            _dataBaseService = dataBaseService;
            _challengeSets = challengeSets;
            _timeProvider = timeProvider;
            _disposable = new();
        }

        private readonly ObservableList<ActiveChallenge> _activeChallenges = new();
        public IReadOnlyObservableList<ActiveChallenge> ActiveChallenges => _activeChallenges;
        
        public Subject<Unit> OnChallengesDataChanged = new();
        
        public void Initialize()
        {
            UpdateActiveChallenges();
            _dataBaseService.OnCigarettesDataChanged
                .Subscribe(this, (_, self) => self.UpdateActiveChallenges())
                .AddTo(_disposable);
            
            _dataBaseService.OnChallengesDataChanged
                .Subscribe(this, (_, self) => self.UpdateActiveChallenges())
                .AddTo(_disposable);
        }

        private void UpdateActiveChallenges()
        {
            var activeChallenges = _dataBaseService.GetActiveChallenges();
            var now = _timeProvider.GetUtcNow();
            
            foreach (var challenge in activeChallenges)
            {
                var activeChallenge = _activeChallenges.FirstOrDefault(ac => ac.SavedData.Id == challenge.Id);
                var challengeConfig = _challengeSets.GetChallengeConfig(challenge.ChallengeId);
                var cigarettesCountByDay = _dataBaseService.GetCigarettesCountByDay(challenge.StartDate, challenge.EndDate);

                int totalCigarettes = 0;
                int daysPassed = (now.Date - challenge.StartDate.Date).Days;
                int totalDays = (challenge.EndDate.Date - challenge.StartDate.Date).Days;

                
                float dailyLimitProgress = 0;
                
                foreach (var (day, count) in cigarettesCountByDay)
                {
                    totalCigarettes += count;
                    
                    if (day.Date == now.Date)
                    {
                        dailyLimitProgress = Math.Min((float)count / challengeConfig.PerDayLimit, 1f);
                    }
                }

                float totalLimitProgress = Math.Min((float)totalCigarettes / challengeConfig.TotalLimit, 1f);
                float overallProgress = Math.Min((float)daysPassed / totalDays, 1f);

                if (activeChallenge != null)
                {
                    activeChallenge.State.Value = GetChallengeState(challenge);
                    activeChallenge.Progress.Value = overallProgress;
                    activeChallenge.DailyLimitProgress.Value = dailyLimitProgress;
                    activeChallenge.TotalLimitProgress.Value = totalLimitProgress;
                }
                else
                {
                    activeChallenge = new ActiveChallenge
                    {
                        SavedData = challenge,
                        State = new ReactiveProperty<ChallengeState>(GetChallengeState(challenge)),
                        Progress = new ReactiveProperty<float>(overallProgress),
                        DailyLimitProgress = new ReactiveProperty<float>(dailyLimitProgress),
                        TotalLimitProgress = new ReactiveProperty<float>(totalLimitProgress)
                    };
                    _activeChallenges.Add(activeChallenge);
                }
                if (activeChallenge.SavedData.State != activeChallenge.State.Value)
                {
                    _dataBaseService.UpdateChallengeState(activeChallenge.SavedData.Id, activeChallenge.State.Value);
                    activeChallenge.SavedData.State = activeChallenge.State.Value;
                }
            }
            OnChallengesDataChanged.OnNext(Unit.Default);
        }
        
        private ChallengeState GetChallengeState(SavedChallengeInfo challenge)
        {
            if (challenge.State == ChallengeState.Claimed)
                return ChallengeState.Claimed;
            
            var challengeConfig = _challengeSets.GetChallengeConfig(challenge.ChallengeId);
            var cigarettesCountByDay = _dataBaseService.GetCigarettesCountByDay(challenge.StartDate, challenge.EndDate);

            int cigarettesCount = 0;
            foreach (var (day, count) in cigarettesCountByDay)
            {
                if (count > challengeConfig.PerDayLimit)
                {
                    return ChallengeState.Failed;
                }
                
                cigarettesCount += count;
                if (cigarettesCount > challengeConfig.TotalLimit)
                {
                    return ChallengeState.Failed;
                }
            }
            var now = _timeProvider.GetUtcNow().DateTime;
            if (now <= challenge.EndDate)
            {
                return ChallengeState.Active;
            }
            return ChallengeState.Completed;
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}