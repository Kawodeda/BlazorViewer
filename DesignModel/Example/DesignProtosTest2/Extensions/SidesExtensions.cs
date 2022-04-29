
namespace DesignModel.MathTypes
{
    public sealed partial class Sides
    {
        public Sides(float left, float top, float right, float bottom)
        {
            left_ = left;
            top_ = top;
            right_ = right;
            bottom_ = bottom;
        }

        public Sides(float offset) : this(offset, offset, offset, offset)
        {

        }
    }
}
