using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace QuitCut.Configs
{
    [Serializable]
    public class ChallengeConfig
    {
        public ChallengeId Id;
        public Sprite Icon;
        public int Level;
        public int DurationDays;
        public int PerDayLimit;
        public int TotalLimit;
    }
    
    [Serializable]
    public class ChallengeSet
    {
        public string Name;
        public ChallengeConfig[] Challenges;
    }
    
    [CreateAssetMenu(fileName = "ChallengeSets", menuName = "QuitCut/ChallengeSets", order = 0)]
    
    public class ChallengeSets : ScriptableObject
    {
        [ListDrawerSettings(ShowIndexLabels = true, ListElementLabelName = "Name")]
        public ChallengeSet[] Sets;

        public ChallengeConfig GetChallengeConfig(ChallengeId cId)
        {
            foreach (var set in Sets)
            {
                foreach (var challenge in set.Challenges)
                {
                    if (challenge.Id.Equals(cId))
                    {
                        return challenge;
                    }
                }
            }
            return null;
        }
        
        public string GetChallengeSetName(ChallengeId cId)
        {
            foreach (var set in Sets)
            {
                foreach (var challenge in set.Challenges)
                {
                    if (challenge.Id.Equals(cId))
                    {
                        return set.Name;
                    }
                }
            }
            return string.Empty;
        }
    }
}