using System;
using Cysharp.Threading.Tasks;
using QuitCut.NavBar;
using UIFramework;
using UIFramework.Runtime;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;

namespace QuitCut.UI.NavBar.Code
{
    public class NavBar : UIScreen
    {
        [SerializeField] private NavBarButton[] _buttons;
        [SerializeField] int _initialButtonIndex;

        [Inject] private UIFrame _uiFrame;
        [Inject] NavBarSettings _settings;

        int _activeButtonIndex = -1;

        void Start()
        {
            Assert.AreEqual(_buttons.Length, _settings.Items.Length, "NavBar buttons count must match settings items count.");
            for (var i = 0; i < _buttons.Length; i++)
            {
                var button = _buttons[i];
                var buttonIndex = i;
                button.Initialize(_settings.Items[i].icon, String.Empty, _settings.Items[i].Type, () => OnButtonClicked(buttonIndex).Forget());
            }
            OnButtonClicked(_initialButtonIndex).Forget();
        }

        private async UniTaskVoid OnButtonClicked(int index)
        {
            if (_activeButtonIndex != index)
            {
                if (_activeButtonIndex >= 0)
                    _uiFrame.Close(_buttons[_activeButtonIndex].Type);

                await _uiFrame.OpenAsync(_buttons[index].Type);
                _activeButtonIndex = index;

                for (int i = 0; i < _buttons.Length; i++)
                {
                    _buttons[i].SetSelected(i == index);
                }
            }
        }
    }
}