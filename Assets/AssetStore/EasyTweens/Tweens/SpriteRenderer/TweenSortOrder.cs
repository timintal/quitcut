#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace EasyTweens
{
    public class TweenSortOrder : IntTween<SpriteRenderer>
    {
        protected override int Property
        {
            get => target.sortingOrder;
            set
            {
                target.sortingOrder = value;
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