using UIFramework;
using UIFramework.FlyingRewardsUIFeedback;
using UnityEngine;
using VContainer;

namespace Caramba.Match3.Core.UI.Screens
{
    public class FlyingRewardsScreen : UIScreen
    {
        [SerializeField] private FlyingRewardsUIFeedbackView flyingRewardsUIFeedbackView;
        [Inject] internal FlyingRewardsService flyingRewardsService;

        protected override void OnOpened()
        {
            flyingRewardsService.SetView(flyingRewardsUIFeedbackView);
        }
    }
}
