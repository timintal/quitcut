#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace EasyTweens
{
    public class TweenSpriteColor : ColorTween<SpriteRenderer>
    {
        protected override Color Property
        {
            get => target.color;
            set
            {
                target.color = value;
#if UNITY_EDITOR

                if (!Application.isPlaying)
                {
                    EditorUtility.SetDirty(target);
                }
#endif
            }
        }
    }
}