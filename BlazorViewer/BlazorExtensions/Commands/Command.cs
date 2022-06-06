namespace BlazorExtensions.Commands
{
    /// <summary>
    /// The basic implementation of ICommand
    /// </summary>
    public class Command : ICommand
    {
        private Action<object?> _execute;
        private Func<object?, bool> _canExecute;
        private object? _parameter;

        public Command(
            Action<object?> execute, 
            Func<object?, bool> canExecute, 
            object? parameter = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _parameter = parameter;
        }

        public void Execute()
        {
            _execute(_parameter);
        }

        public bool CanExecute()
        {
            return _canExecute == null || _canExecute(_parameter);
        }
    }
}
