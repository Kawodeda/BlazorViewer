namespace BlazorExtensions.InputHandling
{
    public interface IViewPort : IScrollbar, IZoomable
    {
        public float ViewPortWidth { get; }

        public float ViewPortHeight { get; }
    }
}
