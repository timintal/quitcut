using Cysharp.Threading.Tasks;
using QuitCut.Data.DataServices;
using R3;
using TMPro;
using UIFramework.Runtime;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut.UI.HomeScreen.Code
{
    public class CurrentStatsWidget : MonoBehaviour
    {
        [SerializeField] Button _logCigaretteButton;
        [SerializeField] TextMeshProUGUI _lastCigTimeLabel;
        [SerializeField] TextMeshProUGUI _recordLabel;

        [Inject] private CigarettesData _cigarettesData;
        [Inject] UIFrame _uiFrame;
        
        void Start()
        {
            _cigarettesData.TimeSinceLastCigarette.Subscribe(_lastCigTimeLabel, (time, label) =>
            {
                label.text = $"{(int)time.TotalDays}d {time.Hours}h {time.Minutes}m";
            });
            _cigarettesData.LongestStreak.Subscribe(_recordLabel, (timespan, label) =>
            {
                int days = timespan.Days;
                int hours = timespan.Hours;
                int minutes = timespan.Minutes;
                label.text = $"Record: {days}d {hours}h {minutes}m";
            });
        }
        private void OnEnable()
        {
            _logCigaretteButton.onClick.AddListener(LogCigarette);
        }

        private void OnDisable()
        {
            _logCigaretteButton.onClick.RemoveListener(LogCigarette);
        }



        private void LogCigarette()
        {
            _uiFrame.OpenAsync<LogSlipPopup.LogSlipPopup>().Forget();
        }
    }
}