using UnityEngine.UI;

namespace EasyTweens
{
    [TweenCategoryOverride("UI")]
    public class SliderTween : FloatTween<Slider>
    {

        protected override float Property
        {
            get => target.value;
            set => target.value = value;
        }
    }
}