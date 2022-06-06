using BlazorExtensions.InputHandling;

namespace BlazorExtensions.Commands.Parameters
{
    public class ZoomCommandParams
    {
        public IZoomable Zoomable { get; set; }

        public float DeltaZoom { get; set; }

        public ZoomCommandParams(IZoomable zoomable, float zoom)
        {
            Zoomable = zoomable;
            DeltaZoom = zoom;
        }
    }
}
