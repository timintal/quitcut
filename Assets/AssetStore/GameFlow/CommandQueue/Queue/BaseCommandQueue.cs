using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Libraries.GameFlow.CommandQueue.Queue
{
    /// <summary>
    /// Base class for command queues.
    /// </summary>
    public abstract class BaseCommandQueue
    {
        public delegate void CommandDelegate(BaseCommandQueue queue, Command command);
        
        public bool IsExecuting { get; private set; }
        
        public async UniTask Execute(CancellationToken ct)
        {
            IsExecuting = true;
            try
            {
                while (!ct.IsCancellationRequested && HasCommands())
                {
                    var command = GetNextCommand();
                    await command.Execute(ct);
                }
            }
            catch (TaskCanceledException)
            {
                Debug.Log($"Command queue execution was cancelled");
            }
            catch (OperationCanceledException)
            {
                Debug.Log($"Command Queue operation was cancelled");
            }
            finally
            {
                Clear();
                IsExecuting = false;
            }
        }
        
        public abstract bool HasCommands();

        public abstract void AddCommand(Command command);

        protected abstract Command GetNextCommand();

        protected abstract void Clear();
    }
}