using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIFramework.FlyingRewardsUIFeedback
{
    [Serializable]
    public class FlyingRewardUI : MonoBehaviour
    {
        [SerializeField] private Transform visualRoot;
        [SerializeField] Image icon;
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private float destructionDelay;

        [field: SerializeField] public FlyingRewardFeedbackData defaultData { get; private set; }
        
        public void Init(Sprite overrideIcon, string overrideLabel)
        {
            if (visualRoot == null)
            {
                visualRoot = transform;
            }

            visualRoot.localScale = Vector3.one;

            if (icon != null)
            {
                if (overrideIcon != null)
                {
                    icon.sprite = overrideIcon;
                }
            }
            if (label != null)
            {
                if (!string.IsNullOrEmpty(overrideLabel))
                {
                    label.text = overrideLabel;
                }
                else
                {
                    label.text = string.Empty;
                }
            }
        }

        public void SetIconSize(Vector2 size)
        {
            if (icon != null)
            {
                icon.rectTransform.sizeDelta = size;
            }
        }

        public async UniTaskVoid Release()
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(destructionDelay), cancellationToken: this.GetCancellationTokenOnDestroy());

                var poolable = GetComponent<PoolableMonoBehaviour>();
                if (poolable != null)
                {
                    poolable.ReleaseObject();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            catch
            {
                // exception thrown when object is destroyed, we do nothing here
            }
        }
    }
}