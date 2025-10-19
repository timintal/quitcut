using EasyTweens;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[TweenCategoryOverride("UI/TMP")]
public class TypewriterTween : FloatTween<TMP_Text>
{
    protected override float Property { get; set; }

    public override void SetFactor(float f)
    {
        base.SetFactor(f);
        if (target.textInfo == null)
        {
            return;
        }
        int textInfoCharacterCount = target.textInfo.characterCount;
        target.maxVisibleCharacters = Mathf.RoundToInt(Property * textInfoCharacterCount);
#if UNITY_EDITOR

        if (!Application.isPlaying)
        {
            EditorUtility.SetDirty(target);
        }
#endif
    }
}