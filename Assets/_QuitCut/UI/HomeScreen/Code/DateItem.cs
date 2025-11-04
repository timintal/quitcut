using QuitCut.Configs.Code;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut.UI.HomeScreen.Code
{
    public class DateItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dateText;
        [SerializeField] private TextMeshProUGUI _dayName;
        [SerializeField] private Graphic _back;
        [SerializeField] private Graphic _glow;
        [SerializeField] private Color _todayColor;
        
        [Inject] WeeklyWidgetColors _weeklyWidgetColors;
        public void SetDate(string date, string dayName)
        {
            _dateText.text = date;
            _dayName.text = dayName;
            _dayName.color = Color.white;
        }

        public void SetCigsCount(int count)
        {
            _back.color = _glow.color = _weeklyWidgetColors.GetColorForCount(count);
        }

        public void SetAsToday()
        {
            // _back.color = _glow.color = _weeklyWidgetColors.TodayColor;
            _dayName.text = "TODAY";
            _dayName.color = _todayColor;
            _dayName.fontStyle = FontStyles.Underline;
        }
        
        public void SetAsFutureDay()
        {
            _back.color = _glow.color = _weeklyWidgetColors.FutureDayColor;
        }
    }
}