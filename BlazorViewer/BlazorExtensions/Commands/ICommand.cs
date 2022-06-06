namespace BlazorExtensions.Commands
{
    public interface ICommand
    {
        public void Execute();

        public bool CanExecute();

        public static ICommand operator +(ICommand a, ICommand b)
        {
            return new MultipleCommandResult(a, b);
        }
    }
}
