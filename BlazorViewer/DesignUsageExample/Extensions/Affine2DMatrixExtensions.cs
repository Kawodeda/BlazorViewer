
namespace DesignModel.MathTypes
{
    public sealed partial class Affine2DMatrix
    {
        public Affine2DMatrix(int width, int height, IEnumerable<float> elements)
        {
            width_ = width;
            height_ = height;
            elements_.AddRange(elements);
        }
    }
}
