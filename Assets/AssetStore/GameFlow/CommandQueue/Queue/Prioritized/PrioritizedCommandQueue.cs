using System.Collections.Generic;

namespace Libraries.GameFlow.CommandQueue.Queue.Prioritized
{
    /// <summary>
    /// A command queue which orders commands based on priority.
    /// </summary>
    public class PrioritizedCommandQueue : BaseCommandQueue
    {
        protected readonly List<Command> Commands = new();
        
        public override void AddCommand(Command command)
        {
            Commands.Add(command);
            Commands.Sort((a, b) => b.Priority.CompareTo(a.Priority));//sort by priority
        }

        public override bool HasCommands() => Commands.Count > 0;

        protected override Command GetNextCommand()
        {
            var command = Commands[0];//first
            Commands.RemoveAt(0);
            return command;
        }

        protected override void Clear() => Commands.Clear();
    }
}