using System.Collections.Generic;
using Libraries.Utils;
using QuitCut.Configs;
using QuitCut.Data;
using QuitCut.Data.Database;
using UIFramework;
using UIFramework.Runtime;
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
        [Inject] DataBaseService _dataBaseService;
        [Inject] UIFrame _uiFrame;
        
        List<ChallengeWidget> _challengeWidgets = new(); 

        void Start()
        {
            foreach (var set in _challengeSets.Sets)
            {
                var challengeWidget = _autoInjectFactory.Spawn(_challengeWidgetPrefab, _challengesContainer);
                challengeWidget.gameObject.SetActive(true);
                challengeWidget.Initialize(set, () =>
                {
                    _uiFrame.OpenAsync<ChallengeDescriptionPopup>(
                        new ChallengeDescriptionProperties(challengeSet: set));
                    
                });
                _challengeWidgets.Add(challengeWidget);
            }
        }
    }
}
