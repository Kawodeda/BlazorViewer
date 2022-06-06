using BlazorExtensions.Commands.Parameters;

namespace BlazorExtensions.Commands
{
    public class ScrollCommand : ICommand
    {
        private ScrollCommandParams _params;

        public ScrollCommand(ScrollCommandParams @params)
        {
            _params = @params;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            _params.Scrollable.ScrollX += _params.DeltaScrollX;
            _params.Scrollable.ScrollY += _params.DeltaScrollY;
        }
    }
}
