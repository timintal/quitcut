using UnityEngine.UI;

namespace EasyTweens
{
    [TweenCategoryOverride("UI")]
    public class TextFontSize : FloatTween<Text>
    {
        protected override float Property
        {
            get => target.fontSize;
            set => target.fontSize = (int)value;
        }
    }
}