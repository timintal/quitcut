using System.Collections.Generic;

namespace Libraries.GameFlow.CommandQueue.Queue.Ordered
{
    /// <summary>
    /// A command queue that executes commands in the order they were added.
    /// </summary>
    /// <remarks>
    /// Priority is not considered in this queue.
    /// </remarks>
    public class OrderedCommandQueue : BaseCommandQueue
    {
        protected readonly Queue<Command> Commands = new();

        public override void AddCommand(Command command)
        {
            Commands.Enqueue(command);
        }

        public override bool HasCommands() => Commands.Count > 0;

        protected override Command GetNextCommand()
        {
            return Commands.Dequeue();
        }

        protected override void Clear() => Commands.Clear();
    }
}