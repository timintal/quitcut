using System;
using TMPro;
using UIFramework;
using UnityEngine;
using VContainer;

namespace QuitCut.UI.HomeScreen.Code
{
    public class HomeScreen : UIScreen
    {
        [SerializeField] private TextMeshProUGUI _title;

        [Inject] TimeProvider _timeProvider;
        
        private void Awake()
        {
            var dateTime = _timeProvider.GetLocalNow();
            _title.text = dateTime.ToString("MMMM yyyy");
        }
    }
}
