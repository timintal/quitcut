using UnityEngine;
using VContainer;

namespace UIFramework.FlyingRewardsUIFeedback
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
