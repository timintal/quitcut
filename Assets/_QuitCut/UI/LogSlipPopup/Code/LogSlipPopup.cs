using System;
using Cysharp.Threading.Tasks;
using Protorius42.NativeDateTimePicker;
using QuitCut.Data.DataServices;
using QuitCut.Services;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut.UI.LogSlipPopup
{
    public class LogSlipPopup : UIScreen
    {
        [SerializeField] Button _closeButton;
        [SerializeField] Button _logNowButton;
        [SerializeField] Button _logWithCustomDateButton;
        
        [Inject] CigarettesData _cigarettesData;
        [Inject] TimeProvider _timeProvider;
        
        void OnEnable()
        {
            _closeButton.onClick.AddListener(UI_Close);
            _logNowButton.onClick.AddListener(LogNow);
            _logWithCustomDateButton.onClick.AddListener(() => LogWithCustomDate().Forget());
        }
        private void LogNow()
        {
            _cigarettesData.LogCigarette(_timeProvider.GetUtcNow().DateTime);
            UI_Close();
        }

        private async UniTaskVoid LogWithCustomDate()
        {
            using NativeDateTimePickerDialog dialog = new NativeDateTimePickerDialog();

            var dateTimeParam = new DialoDateTimeParam(
                "Pick Date and Time",
                DateTimePickerMode.UIDatePickerModeDateAndTime,
                "OK",
                "Cancel",
                DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()); //8.11.1977 8:20 PM UTC

            try
            {
                var (timestamp, error) = await dialog.ShowNativeDateTimeDialogAsync(dateTimeParam);
                if (error == DateTimeErrorCode.NoError)
                {
                    var dateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
                    Debug.Log($"User picked dateTime={dateTime}");
                    _cigarettesData.LogCigarette(dateTime);
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"DateTimeDialog.OnDateTimeButtonClick done with exception={e}");
            }
            finally
            {
                UI_Close();
            }
        }
        
        void OnDisable()
        {
            _closeButton.onClick.RemoveListener(UI_Close);
            _logNowButton.onClick.RemoveListener(LogNow);
            _logWithCustomDateButton.onClick.RemoveAllListeners();
        }
        
        
    }
}