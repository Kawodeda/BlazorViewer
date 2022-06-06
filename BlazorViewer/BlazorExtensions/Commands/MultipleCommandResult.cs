namespace BlazorExtensions.Commands
{
    public class MultipleCommandResult : ICommand
    {
        private readonly List<ICommand> _commands;

        public MultipleCommandResult(params ICommand[] commands)
        {
            _commands = new List<ICommand>(commands);
        }

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            foreach (ICommand command in _commands)
            {
                if (command.CanExecute())
                {
                    command.Execute();
                }
            }
        }
    }
}
