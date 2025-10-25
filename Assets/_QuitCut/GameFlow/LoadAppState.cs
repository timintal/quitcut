using Cysharp.Threading.Tasks;
using Libraries.GameFlow.FSM;
using UIFramework.Runtime;
using VContainer;

namespace QuitCut.GameFlow
{
    public class LoadAppState : FSMState
    {
        [Inject] UIFrame _uiFrame;
        
        public override async UniTask OnEnable()
        {
            await _uiFrame.OpenAsync<UI.NavBar.Code.NavBar>();
        }
        
        public override UniTask OnDisable()
        {
            _uiFrame.Close<UI.NavBar.Code.NavBar>();
            return UniTask.CompletedTask;
        }
    }
}
