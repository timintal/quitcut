using System;
using QuitCut.Data;
using QuitCut.Data.Database;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut.UI.HomeScreen.Code
{

    public class HomeScreen : UIScreen
    {
        [SerializeField] Button _logCigaretteButton;
        [SerializeField] Button _printTodayButton;

        [Inject] DataBaseService _dataBaseService;
        
        private void OnEnable()
        {
            _logCigaretteButton.onClick.AddListener(LogCigarette);
            _printTodayButton.onClick.AddListener(PrintTodayCount);
        }

        private void OnDisable()
        {
            _logCigaretteButton.onClick.RemoveListener(LogCigarette);
            _printTodayButton.onClick.RemoveListener(PrintTodayCount);       
        }
        
        private void PrintTodayCount()
        {
            Debug.Log(_dataBaseService.GetTodayCigarettesCount());
            GetWeek();
        }

        void GetWeek()
        {
            var cigarettesCountByDay = _dataBaseService.GetCigarettesCountByDay(DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);
            foreach (var (day, count) in cigarettesCountByDay)
            {
                Debug.Log($"{day} {count}");
            }
        }

        private void LogCigarette()
        {
            _dataBaseService.LogCigarette(DateTime.UtcNow);
        }
    }
}
