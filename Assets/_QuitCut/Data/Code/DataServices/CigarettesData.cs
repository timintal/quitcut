using System;
using QuitCut.Data.Database;
using R3;
using VContainer;
using VContainer.Unity;

namespace QuitCut.Data.DataServices
{
    public class CigarettesData : IInitializable, IDisposable
    {
        [Inject] DataBaseService _dataBaseService;

        private readonly ReactiveProperty<int> _todayCigarettes = new(0);
        public ReadOnlyReactiveProperty<int> TodayCigarettes => _todayCigarettes;

        private readonly ReactiveProperty<DateTime> _lastCigaretteDate = new(DateTime.MinValue);
        public ReadOnlyReactiveProperty<DateTime> LastCigaretteDate => _lastCigaretteDate;

        private readonly ReactiveProperty<TimeSpan> _longestStreak = new(TimeSpan.MinValue);
        public ReadOnlyReactiveProperty<TimeSpan> LongestStreak => _longestStreak;
        
        private readonly ReactiveProperty<TimeSpan> _timeSinceLastCigarette = new(TimeSpan.MinValue);
        public ReadOnlyReactiveProperty<TimeSpan> TimeSinceLastCigarette => _timeSinceLastCigarette;

        private CompositeDisposable _disposable;

        public void Initialize()
        {
            _disposable = new();
            UpdateData();
            PerSecondUpdate();
            _dataBaseService.OnCigarettesDataChanged.Subscribe(this, (unit, self) => self.UpdateData())
                .AddTo(_disposable);

            StartCheckingLiveStats();
        }
        private void StartCheckingLiveStats()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(this, (_, self) => self.PerSecondUpdate())
                .AddTo(_disposable);
        }
        private void PerSecondUpdate()
        {
            var streak = _dataBaseService.GetLongestStreak();
            var now = DateTime.UtcNow;
            var lastStreak = now - _lastCigaretteDate.CurrentValue;
            _timeSinceLastCigarette.Value = lastStreak;
            
            if (lastStreak > streak)
                _longestStreak.Value = lastStreak;
            
        }

        public void LogCigarette(DateTime time, string note = null)
        {
            _dataBaseService.LogCigarette(time, note);
        }

        private void UpdateData()
        {
            var count = _dataBaseService.GetTodayCigarettesCount();
            _todayCigarettes.Value = count;
            _lastCigaretteDate.Value = _dataBaseService.GetLastCigaretteDate();
            var longestInDb = _dataBaseService.GetLongestStreak();
            _longestStreak.Value = longestInDb;
        }
        public void Dispose()
        {
            _todayCigarettes?.Dispose();
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}