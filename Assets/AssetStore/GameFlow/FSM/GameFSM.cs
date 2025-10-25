using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Libraries.GameFlow.FSM
{
    public interface IStateProperties
    {
    }
    
    public class GameFSM : IDisposable, ITickable, IGameFSM
    {
        private readonly IGameStateFactory _stateFactory;
        //internal state
        internal FSMStateBase currentState;
        internal Stack<FSMStateBase> statesStack = new();

        public FSMStateBase CurrentState => currentState;
        
        //private state
        private Queue<FSMCommand> commandQueue = new();
        private CancellationTokenSource cancellationTokenSource;
        
        
        public GameFSM(IGameStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
            
            cancellationTokenSource = new();
            Run(cancellationTokenSource.Token).Forget();
        }

        public void Tick()
        {
            if (currentState != null)
            {
                currentState.OnUpdate();
            }
        }
        private async UniTask Run(CancellationToken ct)
        {
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    return;
                }
                if (commandQueue.Count > 0)
                {
                    var command = commandQueue.Dequeue();
                    await command.Execute();
                }
                await UniTask.Yield();
            }
        }

        public void Push<T>(IStateProperties properties = null) where T : FSMStateBase
        {
            commandQueue.Enqueue(new PushStateCommand(this, _stateFactory.GetState<T>(), properties));
        }

        public void MoveTo<T>(IStateProperties properties = null) where T : FSMStateBase
        {
            PopState();
            Push<T>(properties);
        }

        public void ClearAndPush<T>(IStateProperties properties = null) where T : FSMStateBase
        {
            ClearStateStack();
            Push<T>(properties);
        }

        public void PopState()
        {
            commandQueue.Enqueue(new PopStateCommand(this));
        }

        public void PopUntil<T>()
        {
            int index = 0;
            foreach (var state in statesStack)
            {
                if (state.GetType() == typeof(T))
                {
                    break;
                }
                index++;
            }

            if (index >= statesStack.Count)
            {
                ClearStateStack();
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    PopState();
                }       
            }
        }

        public void ClearStateStack()
        {
            commandQueue.Enqueue(new ClearStackCommand(this));
        }

        public async UniTask PushAndWaitForExit<T>(IStateProperties properties = null) where T : FSMStateBase
        {
            commandQueue.Enqueue(new PushStateCommand(this, _stateFactory.GetState<T>(), properties));
            var previousState = currentState;
            await UniTask.WaitUntil(this, x => x.currentState.GetType() == typeof(T));
            await UniTask.WaitUntil((this, previousState), x => x.Item1.currentState == x.previousState);
        }

        public void Dispose()
        {
            cancellationTokenSource?.Dispose();
        }
    }
}
