using BlazorExtensions.InputHandling;

namespace BlazorExtensions.Commands.Parameters
{
    public class ScrollbarDragCommandParams
    {
        public IScrollbar Scrollbar { get; set; }
        public float HorizontalScrollbarShift { get; set; }
        public float VerticalScrollbarShift { get; set; }

        public ScrollbarDragCommandParams(
            IScrollbar scrollbar,
            float horizontalScrollbarShift, 
            float verticalScrollbarShift)
        {
            HorizontalScrollbarShift = horizontalScrollbarShift;
            VerticalScrollbarShift = verticalScrollbarShift;
            Scrollbar = scrollbar;
        }
    }
}
