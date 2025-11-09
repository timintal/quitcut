using System;
using QuitCut.Configs;
using QuitCut.Data.Database;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut.UI.HomeScreen.Code
{
    public class ChallengeWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private GameObject[] _stars;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;

        [Inject] DataBaseService _dataBaseService;
        private Action _onClick;

        public void Initialize(ChallengeSet challengeSet, Action onClick)
        {
            _onClick = onClick;
            var completedChallenges = _dataBaseService.GetCompletedChallenges();
            _title.text = challengeSet.Name;

            int starCount = 0;
            for (int i = 0; i < challengeSet.Challenges.Length; i++)
            {
                var challenge = challengeSet.Challenges[i];
                if (completedChallenges.Exists(c => c.ChallengeId == challenge.Id))
                {
                    starCount++;
                }
            }
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].SetActive(i < starCount);
            }

            //set icon from last non completed
            if (starCount < challengeSet.Challenges.Length)
                _icon.sprite = challengeSet.Challenges[starCount].Icon;
            else if (challengeSet.Challenges.Length > 0)
                _icon.sprite = challengeSet.Challenges[^1].Icon;
            else
                _icon.sprite = null;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
        
        
        private void OnButtonClicked()
        {
            _onClick?.Invoke();
        }
    }
}