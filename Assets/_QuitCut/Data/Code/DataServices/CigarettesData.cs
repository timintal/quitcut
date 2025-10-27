using System;
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
        
        private IDisposable _disposable;

        public void Initialize()
        {
            UpdateData();
            _disposable = _dataBaseService.OnCigarettesDataChanged.
                Subscribe(this, (unit, self) => self.UpdateData());
        }

        public void LogCigarette(DateTime time, string note = null)
        {
            _dataBaseService.LogCigarette(time, note);
        }
        
        private void UpdateData()
        {
            var count = _dataBaseService.GetTodayCigarettesCount();
            _todayCigarettes.Value = count;
        }
        public void Dispose()
        {
            _todayCigarettes?.Dispose();
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}