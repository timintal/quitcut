using System;
using System.Collections.Generic;
using Libraries.GameFlow.CommandQueue.Queue.Ordered;
using Libraries.GameFlow.CommandQueue.Queue.Prioritized;
using VContainer;

namespace Libraries.GameFlow.CommandQueue.Queue
{
    public class CommandQueueFactory : IDisposable
    {
        [Inject] internal IObjectResolver resolver;
        
        public enum QueueType
        {
            Ordered,
            Prioritized
        }

        //debug only
        public HashSet<BaseCommandQueue> ActiveQueues = new();
        
        public void Dispose()
        {
            ActiveQueues = null;
        }
        
        public BaseCommandQueue CreateCommandQueue(QueueType queueType)
        {
            BaseCommandQueue queue;
            
            switch (queueType)
            {
                case QueueType.Ordered:

                    queue = new OrderedCommandQueue();
                    break;
                case QueueType.Prioritized:
                    queue = new PrioritizedCommandQueue();
                    break;
                default:
                    throw new InvalidOperationException($"Unrecognized queue type: {queueType}");
            }
            
            resolver.Inject(queue);
            return queue;
        }
    }
}