using System.Threading;
using Cysharp.Threading.Tasks;

namespace Libraries.GameFlow.CommandQueue
{
    public abstract class Command
    {
        public int Priority { get; set; }
        public abstract UniTask Execute(CancellationToken ct);
        public override string ToString() => GetType().Name;
    }
}