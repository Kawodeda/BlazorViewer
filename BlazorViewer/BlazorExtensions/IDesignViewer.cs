using Aurigma.Design;
using Aurigma.Design.Math;

namespace BlazorExtensions
{
    public interface IDesignViewer : IViewer
    {
        public Surface CurrentSurface { get; }

        public Element? SelectedElement { get; set; }

        public Affine2DMatrix Transform { get; }
    }
}
