
namespace Aurigma.Design.Math
{
    public sealed partial class Point
    {
        public Point(float x, float y)
        {
            x_ = x;
            y_ = y;
        }

        public static Point Negate(Point point)
        {
            return new Point(-point.x_, -point.y_);
        }

        public static Point Multiply(Affine2DMatrix matrix, Point point)
        {
            float x = point.x_ * matrix.M11 + point.y_ * matrix.M12 + matrix.D1;
            float y = point.x_ * matrix.M21 + point.y_ * matrix.M22 + matrix.D2;

            return new Point(x, y);
        }

        public static Point Multiply(Point point, Affine2DMatrix matrix)
        {
            return Multiply(matrix, point);
        }

        public static bool NearlyEqual(float a, float b, float epsilon)
        {
            float diff = MathF.Abs(a - b);

            if (a == b)
            {
                return true;
            }
            else
            {
                return diff < epsilon;
            }
        }

        public static Point operator -(Point point) => Negate(point);

        public static Point operator *(Point point, Affine2DMatrix matrix) => Multiply(point, matrix);

        public static Point operator *(Affine2DMatrix matrix, Point point) => Multiply(matrix, point);

        public Point MultiplyBy(Affine2DMatrix matrix)
        {
            return Multiply(this, matrix);
        }

        public Point Translate(Point destination)
        {
            return MultiplyBy(Affine2DMatrix.CreateTranslate(destination));
        }

        public Point Scale(float factor)
        {
            return Scale(factor, factor);
        }

        public Point Scale(float dx, float dy)
        {
            return MultiplyBy(Affine2DMatrix.CreateScale(dx, dy));
        }

        public Point ScaleAt(float factor, Point center)
        {
            return ScaleAt(factor, factor, center);
        }

        public Point ScaleAt(float dx, float dy, Point center)
        {
            return MultiplyBy(Affine2DMatrix.CreateIdentity().ScaleAt(dx, dy, center));
        }

        public Point Rotate(float angle)
        {
            return MultiplyBy(Affine2DMatrix.CreateRotate(angle));
        }

        public Point RotateAt(float angle, Point center)
        {
            return MultiplyBy(Affine2DMatrix.CreateIdentity().RotateAt(angle, center));
        }

        public bool NearlyEquals(Point other)
        {
            const float epsilon = 0.000001f;

            return NearlyEqual(x_, other.x_, epsilon) 
                && NearlyEqual(y_, other.y_, epsilon);
        }
    }
}
