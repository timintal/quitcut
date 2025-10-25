using VContainer;

namespace Libraries.GameFlow.FSM
{
    public class GameStateFactory : IGameStateFactory
    {
        private readonly IObjectResolver _resolver;
        public GameStateFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public T GetState<T>() where T : FSMStateBase
        {
            return _resolver.Resolve<T>();
        }
    }
}