namespace BlazorExtensions.Commands
{
    public class EmptyCommandResult : ICommand
    {
        public bool CanExecute()
        {
            return false;
        }

        public void Execute()
        {
            return;
        }
    }
}
