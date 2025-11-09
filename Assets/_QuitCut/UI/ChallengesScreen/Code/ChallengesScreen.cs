using System.Collections.Generic;
using Libraries.Utils;
using QuitCut.Configs;
using UIFramework;
using UnityEngine;
using VContainer;

namespace QuitCut.UI.HomeScreen.Code
{
    public class ChallengesScreen : UIScreen
    {
        [SerializeField] Transform _challengesContainer;
        [SerializeField] ChallengeWidget _challengeWidgetPrefab;
        
        [Inject] ChallengeSets _challengeSets;
        [Inject] AutoInjectFactory _autoInjectFactory;
        
        List<ChallengeWidget> _challengeWidgets = new(); 

        void Start()
        {
            foreach (var set in _challengeSets.Sets)
            {
                var challengeWidget = _autoInjectFactory.Spawn(_challengeWidgetPrefab, _challengesContainer);
                challengeWidget.gameObject.SetActive(true);
                challengeWidget.Initialize(set, () =>
                {
                    Debug.Log("Challenge clicked: " + set.Name);
                });
                _challengeWidgets.Add(challengeWidget);
            }
        }
    }
}
