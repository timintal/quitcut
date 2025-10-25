using Caramba.PersistentData;
using Libraries.Rewards.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Rewards.Runtime
{
    public abstract class RewardDefinition : ScriptableObject
    {
        [PreviewField]
        public Sprite Icon;
        public Vector2 FlyingRewardIconSize = new(128, 128);
        
        public virtual string GelLabelForAmount(int amount) => amount.ToString();

        public abstract void GrantReward(DataManager dataManager, int amount);
        
        public abstract RewardType RewardType { get; }
    }
}