using EasyTweens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIFramework.FlyingRewardsUIFeedback
{
    public class FloatAndFadeWidget : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text text;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TweenAnimation floatAndFadeAnimation;

        public void Init(Sprite iconSprite, int amount)
        {
            if (icon != null)
            {
                icon.sprite = iconSprite;
            }

            if (text != null)
            {
                text.text = $"{amount}";
            }
        }
        
        public void PlayAnimation() => floatAndFadeAnimation.Play();

        public void Release()
        {
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
    }
}