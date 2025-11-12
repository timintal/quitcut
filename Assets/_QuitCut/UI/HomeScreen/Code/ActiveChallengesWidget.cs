using System;
using ObservableCollections;
using QuitCut.Configs;
using QuitCut.Data.DataServices;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuitCut
{
    public class ActiveChallengesWidget : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _challengeName;
        [SerializeField] TextMeshProUGUI _challengeCountLabel;
        [SerializeField] TextMeshProUGUI _daysProgressLabel;
        [SerializeField] private Image _daysProgress;
        [SerializeField] TextMeshProUGUI _smokesProgressLabel;
        [SerializeField] private Image _smokesProgress;

        [Inject] ChallengesData _challengesData;
        [Inject] CigarettesData _cigarettesData;
        [Inject] ChallengeSets _challengeSets;
        

        void Start()
        {
            _challengesData.ActiveChallenges
                .ObserveCountChanged(true)
                .Subscribe(UpdateChallengeDisplay)
                .AddTo(this);
            UpdateChallengeDisplay(_challengesData.ActiveChallenges.Count);
        }
        
        private void UpdateChallengeDisplay(int count)
        {
            if (count > 0)
            {
                var challengeConfig = _challengeSets.GetChallengeConfig(_challengesData.ActiveChallenges[0].SavedData.ChallengeId);

                var activeChallenge = _challengesData.ActiveChallenges[0];
                _challengeName.text = $"{_challengeSets.GetChallengeSetName(activeChallenge.SavedData.ChallengeId)}";
                _challengeCountLabel.text = $"Active Challenges: {count}";

                var daysPassed = activeChallenge.Progress.CurrentValue * challengeConfig.DurationDays;
                _daysProgressLabel.text = $"{Mathf.RoundToInt(daysPassed)}/{challengeConfig.DurationDays}";
                _daysProgress.fillAmount = activeChallenge.DailyLimitProgress.Value;

                _smokesProgressLabel.text = $"{_cigarettesData.TodayCigarettes.CurrentValue}/{challengeConfig.PerDayLimit}";
                _smokesProgress.fillAmount = activeChallenge.Progress.Value;
            }
            else
            {
                _challengeName.text = "No Active Challenges";
                _challengeCountLabel.text = "Active Challenges: 0";

                _daysProgressLabel.text = "";
                _daysProgress.fillAmount = 0f;

                _smokesProgressLabel.text = "";
                _smokesProgress.fillAmount = 0f;
            }
        }
    }
}
