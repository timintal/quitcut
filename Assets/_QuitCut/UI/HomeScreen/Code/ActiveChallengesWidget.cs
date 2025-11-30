using System;
using DG.Tweening;
using ObservableCollections;
using QuitCut.Configs;
using QuitCut.Data.DataServices;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut
{

    public class ActiveChallengesWidget : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _challengeName;
        [SerializeField] TextMeshProUGUI _challengeCountLabel;
        [SerializeField] TextMeshProUGUI _daysProgressLabel;
        [SerializeField] private Image _daysProgress;
        [SerializeField] TextMeshProUGUI _smokesProgressLabel;
        [SerializeField] private Image _smokesProgress;
        [SerializeField] Button _nextChallengeButton;
        [SerializeField] Button _previousChallengeButton;
        [SerializeField] Pagination _pagination;

        [Inject] ChallengesData _challengesData;
        [Inject] CigarettesData _cigarettesData;
        [Inject] ChallengeSets _challengeSets;
        [Inject] TimeProvider _timeProvider;
        
        int _currentChallengeIndex;

        void OnEnable()
        {
            _nextChallengeButton.onClick.AddListener(OnNextChallenge);
            _previousChallengeButton.onClick.AddListener(OnPreviousChallenge);
        }
        
        private void OnDisable()
        {
            _nextChallengeButton.onClick.RemoveListener(OnNextChallenge);
            _previousChallengeButton.onClick.RemoveListener(OnPreviousChallenge);
        }
        
        void Start()
        {
            _currentChallengeIndex = 0;
            
            _challengesData.ActiveChallenges
                .ObserveCountChanged(true)
                .Subscribe(UpdateChallengeDisplay)
                .AddTo(this);
            
            _challengesData.OnChallengesDataChanged
                .Subscribe(_challengesData.ActiveChallenges, (_, c) => UpdateChallengeDisplay(c.Count))
                .AddTo(this);
            
            UpdateChallengeDisplay(_challengesData.ActiveChallenges.Count);
        }

        private void OnNextChallenge()
        {
            _currentChallengeIndex = (_currentChallengeIndex + 1) % _challengesData.ActiveChallenges.Count;
            SetCurrentChallenge(_currentChallengeIndex);
        }
        private void OnPreviousChallenge()
        {
            _currentChallengeIndex = (_currentChallengeIndex - 1 + _challengesData.ActiveChallenges.Count) % _challengesData.ActiveChallenges.Count;
            SetCurrentChallenge(_currentChallengeIndex);
        }
        
        private void UpdateChallengeDisplay(int count)
        {
            _pagination.SetDotsCount(count);
            if (count > 0)
            {
                _challengeCountLabel.text = $"Active Challenges: {count}";
                SetCurrentChallenge(_currentChallengeIndex);
            }
            else
            {
                _challengeName.text = "No Active Challenges";
                _challengeCountLabel.text = "Active Challenges: 0";

                _daysProgressLabel.text = "";
                _daysProgress.fillAmount = 0f;

                _smokesProgressLabel.text = "";
                _smokesProgress.fillAmount = 0f;
            }
        }
        
        private void SetCurrentChallenge(int index)
        {
            _pagination.SetActivePage(index);
            var activeChallenge = _challengesData.ActiveChallenges[index];
            var challengeConfig = _challengeSets.GetChallengeConfig(activeChallenge.SavedData.ChallengeId);

            _challengeName.text = $"{_challengeSets.GetChallengeSetName(activeChallenge.SavedData.ChallengeId)}";

            var now = _timeProvider.GetUtcNow();
            var daysPassed = activeChallenge.Progress.CurrentValue * challengeConfig.DurationDays;
            _daysProgressLabel.text = $"{Mathf.RoundToInt(daysPassed)}/{challengeConfig.DurationDays}";

            var fillAmount = (float)(now - activeChallenge.SavedData.StartDate).TotalSeconds / (float)(activeChallenge.SavedData.EndDate - activeChallenge.SavedData.StartDate).TotalSeconds;
            _daysProgress.DOFillAmount(fillAmount, 0.3f).SetEase(Ease.OutQuad);

            _smokesProgressLabel.text = $"{_cigarettesData.TodayCigarettes.CurrentValue}/{challengeConfig.PerDayLimit}";
            _smokesProgress.DOFillAmount(activeChallenge.DailyLimitProgress.Value, 0.3f).SetEase(Ease.OutQuad);
        }
    }
}
