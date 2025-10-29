using System;
using Cysharp.Threading.Tasks;
using QuitCut.Data;
using QuitCut.Data.Database;
using UIFramework;
using UIFramework.Runtime;
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
        [Inject] UIFrame _uiFrame;
        
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
        }

        private void LogCigarette()
        {
            _uiFrame.OpenAsync<LogSlipPopup.LogSlipPopup>().Forget();
        }
    }
}
