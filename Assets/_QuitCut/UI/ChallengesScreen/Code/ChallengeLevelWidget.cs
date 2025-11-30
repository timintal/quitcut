using System;
using EasyTweens;
using QuitCut.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuitCut
{
    public class ChallengeLevelWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelLabel;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _icon;
        [SerializeField] TweenAnimation _enabledAnimation;
        [SerializeField] TweenAnimation _disabledAnimation;
        [SerializeField] TweenAnimation _selectedAnimation;
        [SerializeField] Button _button;

        bool _isSelected;
        bool _isEnabled;

        Action _onClick;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            if (_isEnabled && !_isSelected)
            {
                _onClick?.Invoke();
                SetSelected(true);
            }
            else _disabledAnimation.Play();
        }

        public void Init(ChallengeConfig config, bool enabled, Action onClick)
        {
            if (_levelLabel != null)
            {
                _levelLabel.text = config.Level.ToString();
            }
            
            _icon.sprite = config.Icon;
            string description = config.Description
                .Replace("{per_day_smokes}", config.PerDayLimit == 1 ? $"{config.PerDayLimit} smoke" : $"{config.PerDayLimit} smokes")
                .Replace("{days}", config.DurationDays == 1 ? $"{config.DurationDays} day" : $"{config.DurationDays} days")
                .Replace("{total_smokes}", config.TotalLimit == 1 ? $"{config.TotalLimit} smoke" : $"{config.TotalLimit} smokes")
                ;
            _description.text = description;
            _onClick = onClick;

            _selectedAnimation.PlayBackward(false);
            _disabledAnimation.PlayBackward(false);
            
            if (enabled) _enabledAnimation.Play(false);
            else _enabledAnimation.PlayBackward(false);
        }

        public void SetSelected(bool selected, bool animated = true)
        {
            if (selected) _selectedAnimation.Play(animated);
            else _selectedAnimation.PlayBackward(animated);
            _isSelected = selected;
        }
    }
}