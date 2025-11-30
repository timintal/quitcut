using System.Linq;
using QuitCut.Configs;
using QuitCut.Data.Database;
using QuitCut.Data.DataServices;
using TMPro;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut
{
    public class ChallengeDescriptionProperties : IScreenProperties
    {
        public ChallengeSet ChallengeSet;
        public ChallengeDescriptionProperties(ChallengeSet challengeSet)
        {
            ChallengeSet = challengeSet;
        }
    }

    public class ChallengeDescriptionPopup : UIScreen<ChallengeDescriptionProperties>
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] ChallengeLevelWidget[] _levels;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _startButton;

        [Inject] DataBaseService _dataBaseService;
        [Inject] ChallengeSets _challengeSets;
        [Inject] ChallengesData _challengesData;

        int _selectedLevel;

        void OnEnable()
        {
            _closeButton.onClick.AddListener(UI_Close);
            _startButton.onClick.AddListener(StartSelectedChallenge);
        }

        private void StartSelectedChallenge()
        {
            _dataBaseService.StartChallenge(Properties.ChallengeSet.Challenges[_selectedLevel].Id);
            UI_Close();
        }

        private void Start()
        {
            var challengeSet = Properties.ChallengeSet;

            _title.text = challengeSet.Name;
            _description.text = challengeSet.Description;

            int completedLevel = 0;

            for (var i = 0; i < challengeSet.Challenges.Length; i++)
            {
                var challenge = challengeSet.Challenges[i];
                if (_challengesData.CompletedChallenges.Any(c => c.ChallengeId == challenge.Id))
                {
                    completedLevel = Mathf.Max(completedLevel, challenge.Level);
                }
            }

            for (int i = 0; i < challengeSet.Challenges.Length && i < _levels.Length; i++)
            {
                int index = i;
                _levels[i].Init(challengeSet.Challenges[i], completedLevel >= i, () =>
                {
                    OnLevelSelected(index);
                });
            }
            OnLevelSelected(0, false);
        }
        void OnDisable()
        {
            _closeButton.onClick.RemoveListener(UI_Close);
            _startButton.onClick.RemoveAllListeners();
        }

        private void OnLevelSelected(int level, bool animated = true)
        {
            _selectedLevel = level;
            foreach (var lvl in _levels)
            {
                lvl.SetSelected(false, false);
            }
            _levels[level].SetSelected(true, animated);
        }

    }
}