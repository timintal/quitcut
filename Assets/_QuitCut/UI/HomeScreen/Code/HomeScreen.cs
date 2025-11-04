using System;
using TMPro;
using UIFramework;
using UnityEngine;

namespace QuitCut.UI.HomeScreen.Code
{
    public class HomeScreen : UIScreen
    {
        [SerializeField] private TextMeshProUGUI _title;

        private void Awake()
        {
            var dateTime = DateTime.Now;
            _title.text = dateTime.ToString("MMMM yyyy");
        }
    }
}
