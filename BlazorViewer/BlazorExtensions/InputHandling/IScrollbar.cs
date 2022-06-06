namespace BlazorExtensions.InputHandling
{
    public interface IScrollbar : IScrollable
    {
        public bool IsHorizontalScrollbarShown { get; }

        public bool IsVerticalScrollbarShown { get; }

        public float ScrollbarSize { get; }

        public float ScrollableAreaHeight { get; }

        public float ScrollableAreaWidth { get; }

        public float VerticalScrollbarBodyPos { get; }

        public float HorizontalScrollbarBodyPos { get; }

        public float VerticalScrollbarBodyHeight { get; }

        public float HorizontalScrollbarBodyWidth { get; }

        public float VerticalScrollbarHeight { get; }

        public float HorizontalScrollbarWidth { get; }
    }
}
