using QuitCut.Configs.Code;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut.UI.HomeScreen.Code
{
    public class DateItem : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _dateText;
        [SerializeField] private TMPro.TextMeshProUGUI _dayName;
        [SerializeField] private Graphic _back;
        [SerializeField] private Graphic _glow;
        
        [Inject] WeeklyWidgetColors _weeklyWidgetColors;
        public void SetDate(string date, string dayName)
        {
            _dateText.text = date;
            _dayName.text = dayName;
        }

        public void SetCigsCount(int count)
        {
            _back.color = _glow.color = _weeklyWidgetColors.GetColorForCount(count);
        }

        public void SetAsToday()
        {
            _back.color = _glow.color = _weeklyWidgetColors.TodayColor;
        }
        
        public void SetAsFutureDay()
        {
            _back.color = _glow.color = _weeklyWidgetColors.FutureDayColor;
        }
    }
}