using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorExtensions.Commands.Parameters;
using BlazorExtensions.InputHandling;

namespace BlazorExtensions.Commands
{
    public class ScrollbarDragCommand : ICommand
    {
        private ScrollbarDragCommandParams _params;

        public ScrollbarDragCommand(ScrollbarDragCommandParams @params)
        {
            _params = @params;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            float scrollX 
                = GetScrollXFromScrollbarShift(_params.HorizontalScrollbarShift);
            float scrollY
                = GetScrollYFromScrollbarShift(_params.VerticalScrollbarShift);
            var @params = new ScrollCommandParams(Scrollbar, scrollX, scrollY);

            ICommand scrollCommand = new ScrollCommand(@params);
            if(scrollCommand.CanExecute())
            {
                scrollCommand.Execute();
            }
        }

        private IScrollbar Scrollbar
        {
            get
            {
                return _params.Scrollbar;
            }
        }

        private float GetScrollXFromScrollbarShift(float shift)
        {
            return Scrollbar.ScrollableAreaWidth * -shift 
                / Scrollbar.HorizontalScrollbarWidth;
        }

        private float GetScrollYFromScrollbarShift(float shift)
        {
            return Scrollbar.ScrollableAreaHeight * -shift
                / Scrollbar.VerticalScrollbarHeight;
        }
    }
}
