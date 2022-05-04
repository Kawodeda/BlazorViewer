using DesignModel.MathTypes;

namespace DesignModel.ContentTypes.Controls
{
    public sealed partial class PathControls
    {
        public PathControls(IEnumerable<Point> points)
        {
            controls_.AddRange(points);
        }
    }
}
