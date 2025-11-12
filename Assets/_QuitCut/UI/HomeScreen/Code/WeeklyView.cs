using System;
using System.Linq;
using QuitCut.Data.Database;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace QuitCut.UI.HomeScreen.Code
{
    public class WeeklyView : MonoBehaviour
    {
        [SerializeField] DateItem[] _dateItems;

        [Inject] DataBaseService _dataBaseService;
        [Inject] TimeProvider _timeProvider;

        private void Start()
        {
            RefreshView();
            _dataBaseService.OnCigarettesDataChanged
                .Subscribe(this,(_, self) => self.RefreshView())
                .AddTo(this);   
        }
        
        private void RefreshView()
        {
            var today = _timeProvider.GetUtcNow().DateTime;
            //get current week start (Monday)
            var weekStart = today.AddDays(-(today.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)today.DayOfWeek - 1));
            var cigarettesCountByDay = _dataBaseService.GetCigarettesCountByDay(weekStart, weekStart.AddDays(7));
            for (int i = 0; i < _dateItems.Length; i++)
            {
                var date = weekStart.AddDays(i);
                _dateItems[i].SetDate(date.Day.ToString(), date.ToString("ddd"));
                
                if (date.Date > today.Date)
                {
                    _dateItems[i].SetAsFutureDay();
                }
                else
                {
                    var count = cigarettesCountByDay
                        .Where(pair => pair.Key.Date == date.Date)
                        .Select(pair => pair.Value)
                        .FirstOrDefault();
                    
                    _dateItems[i].SetCigsCount(count);
                    
                    if (date.Date == today.Date)
                    {
                        _dateItems[i].SetAsToday();
                    }
                }
            }
        }
    }
}