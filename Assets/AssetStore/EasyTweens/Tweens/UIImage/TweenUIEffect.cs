#if UI_EFFECT

using Coffee.UIEffects;

namespace EasyTweens
{
    [TweenCategoryOverride("Image")]
    public class TweenUIEffect : FloatTween<UIEffect>
    {
        protected override float Property
        {
            get => target.transitionRate;
            set => target.transitionRate = value;
        }
    }
}
#endif