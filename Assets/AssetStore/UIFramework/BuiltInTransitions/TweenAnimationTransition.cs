using System;
using EasyTweens;
using Sirenix.OdinInspector;
using UIFramework;
using UnityEngine;

namespace Common
{
    public class TweenAnimationTransition : UITransition
    {
        [SerializeField] TweenAnimation _showAnimation;
        [SerializeField] bool _useShowBackwardAnimation;
        
        [SerializeField, HideIf(nameof(_useShowBackwardAnimation))] TweenAnimation _hideAnimation;

        public override void AnimateOpen(Transform target, Action onTransitionCompleteCallback)
        {
            _showAnimation.Play();
            _showAnimation.OnPlayForwardFinished += onTransitionCompleteCallback;
        }

        public override void AnimateClose(Transform target, Action onTransitionCompleteCallback)
        {
            if (_useShowBackwardAnimation)
            {
                _showAnimation.PlayBackward();
                _showAnimation.OnPlayBackwardFinished += onTransitionCompleteCallback;
            }
            else if (_hideAnimation != null)
            {
                _hideAnimation.Play();
                _hideAnimation.OnPlayForwardFinished += onTransitionCompleteCallback;
            }
            else
            {
                onTransitionCompleteCallback?.Invoke();
            }
        }
    }
}
