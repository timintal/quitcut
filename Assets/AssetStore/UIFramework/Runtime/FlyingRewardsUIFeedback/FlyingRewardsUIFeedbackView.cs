using Libraries.Rewards.Runtime;
using Rewards.Runtime;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using VContainer;

namespace UIFramework.FlyingRewardsUIFeedback
{
    public class FlyingRewardsUIFeedbackView : MonoBehaviour
    {
        [SerializeField] FlyingRewardOverride[] flyingRewardOverrides;
        [SerializeField] private FlyingRewardUI defaultView;
        [SerializeField] private FloatAndFadeWidget floatAndFadeWidgetPrefab;

        [Inject] internal PoolService poolService;

        public FlyingRewardUI GetRewardPrefab(Vector3 position, RewardType type)
        {
            FlyingRewardUI rewardInstance = poolService.GetPoolable<FlyingRewardUI>(GetRewardPrefab(type).gameObject);
            
            rewardInstance.transform.SetParent(transform);
            rewardInstance.transform.localScale = Vector3.one;
            rewardInstance.transform.position = position;

            return rewardInstance;
        }
        
        public FlyingRewardFeedbackData GetSettings(RewardType type)
        {
            foreach (var prefabOverrides in flyingRewardOverrides)
            {
                if (prefabOverrides.rewardType == type.Name)
                {
                    return prefabOverrides.rewardUI.defaultData;
                }
            }

            return defaultView.defaultData;
        }

        public FlyingRewardUI GetRewardPrefab(RewardType type)
        {
            foreach (var prefabOverrides in flyingRewardOverrides)
            {
                if (prefabOverrides.rewardType == type.Name)
                {
                    return prefabOverrides.rewardUI;
                }
            }

            return defaultView;
        }

        public FloatAndFadeWidget GetFloatAndFadeWidgetPrefab(Vector3 position)
        {
            var floatAndFadeWidget = poolService.GetPoolable<FloatAndFadeWidget>(floatAndFadeWidgetPrefab.gameObject);
            floatAndFadeWidget.transform.SetParent(transform);

            floatAndFadeWidget.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            floatAndFadeWidget.transform.localScale = Vector3.one;

            floatAndFadeWidget.transform.position = position;

            return floatAndFadeWidget;
        }
    }

    [Serializable]
    public class FlyingRewardOverride
    {
        [ValueDropdown(nameof(GetValues))]
        public string rewardType;

        public FlyingRewardUI rewardUI;
        
        private IEnumerable GetValues()
        {
#if UNITY_EDITOR            
            return Enumeration.GetAll<RewardType>().Select(type => type.Name);
#else
            return null;    
#endif
        }
    }
}