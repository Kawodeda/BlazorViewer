using BlazorExtensions.InputHandling;

namespace BlazorExtensions.Commands.Parameters
{
    public class ScrollCommandParams
    {
        public IScrollable Scrollable { get; set; }
        public float DeltaScrollX { get; set; }
        public float DeltaScrollY { get; set; }

        public ScrollCommandParams(
            IScrollable scrollable, 
            float deltaScrollX, 
            float deltaScrollY)
        {
            Scrollable = scrollable;
            DeltaScrollX = deltaScrollX;
            DeltaScrollY = deltaScrollY;
        }
    }
}
