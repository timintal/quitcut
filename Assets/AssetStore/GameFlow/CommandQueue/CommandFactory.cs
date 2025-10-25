using VContainer;

namespace Libraries.GameFlow.CommandQueue
{
    public class CommandFactory
    {
        private IObjectResolver resolver;
        
        public CommandFactory(IObjectResolver resolver)
        {
            this.resolver = resolver;
        }
        
        public T CreateWithDefaultConstructor<T>() where T : Command, new()
        {
            var command = new T();
            resolver.Inject(command);
            return command;
        }

        public T Get<T>() where T : Command
        {
            return resolver.Resolve<T>();
        }

        public void SetupSerializedCommand<T>(T command) where T : Command
        {
            resolver.Inject(command);
        }
    }
}