using Libraries.Rewards.Runtime;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UIFramework.FlyingRewardsUIFeedback;
using UnityEngine;
using VContainer;

namespace Caramba.TowerOfFortune.UI.Widgets
{
    public class MonoRewardPositionProvider : MonoBehaviour, IRewardUIPositionProvider
    {
        [ValueDropdown(nameof(GetValues)), SerializeField]
        string rewardType;

        [Inject] internal FlyingRewardsService flyingRewardsService;

        IEnumerable GetValues()
        {
            return RewardType.GetAllTypeNames();
        }

        protected virtual void OnEnable()
        {
            flyingRewardsService.RegisterPositionProvider(this);
        }

        protected virtual void OnDisable()
        {
            flyingRewardsService.UnregisterPositionProvider(this);
        }

        public RewardType RewardType => RewardType.GetByName(rewardType);

        public Vector3 GetRewardTargetPosition() => transform.position;

        public Action OnRewardReachedTarget => null;
    }
}