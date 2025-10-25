using AYellowpaper.SerializedCollections;
using Libraries.Rewards.Runtime;
using UIFramework.FlyingRewardsUIFeedback;
using UnityEngine;

namespace QuitCut.Data
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "DefaultRewardIconProvider", menuName = "QuitCut/DefaultRewardIconProvider")]
    public class DefaultRewardIconProvider : ScriptableObject, IRewardIconProvider
    {
        [SerializedDictionary("RewardType", "Sprite")]
        public SerializedDictionary<RewardType, Sprite> rewardIcons = new();
        public Sprite GetIcon(RewardType type)
        {
            if (rewardIcons.TryGetValue(type, out var sprite))
            {
                return sprite;
            }
            return null;
        }
    }
}
