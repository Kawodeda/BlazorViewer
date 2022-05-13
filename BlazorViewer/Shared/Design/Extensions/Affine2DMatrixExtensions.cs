using System;

namespace Aurigma.Design.Math
{
    public sealed partial class Affine2DMatrix
    {
        public static Affine2DMatrix CreateIdentity()
        {
            return new Affine2DMatrix();
        }

        public static Affine2DMatrix CreateTranslate(Point shift)
        {
            Affine2DMatrix result = CreateIdentity();
            result.D1 = shift.X;
            result.D2 = shift.Y;

            return result;
        }

        public static Affine2DMatrix CreateScale(float dx, float dy)
        {
            Affine2DMatrix result = CreateIdentity();
            result.M11 = dx;
            result.M22 = dy;

            return result;
        }

        public static Affine2DMatrix CreateScale(float factor)
        {
            return CreateScale(factor, factor);
        }

        public static Affine2DMatrix CreateRotate(float angle)
        {
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            Affine2DMatrix result = CreateIdentity();
            result.M11 = cos;
            result.M12 = -sin;
            result.M21 = sin;
            result.M22 = cos;

            return result;
        }

        public static Affine2DMatrix Multiply(Affine2DMatrix a, Affine2DMatrix b)
        {
            return new Affine2DMatrix()
            {
                M11 = a.M11 * b.M11 + a.M12 * b.M21,
                M12 = a.M11 * b.M12 + a.M12 * b.M22,
                M21 = a.M21 * b.M11 + a.M22 * b.M21,
                M22 = a.M21 * b.M12 + a.M22 * b.M22,
                D1 = a.M11 * b.D1 + a.M12 * b.D2 + a.D1,
                D2 = a.M21 * b.D1 + a.M22 * b.D2 + a.D2
            };
        }

        public static Affine2DMatrix operator *(Affine2DMatrix a, Affine2DMatrix b)
        {
            return Multiply(a, b);
        }

        public Affine2DMatrix Prepend(Affine2DMatrix matrix)
        {
            return Multiply(matrix, this);
        }

        public Affine2DMatrix Append(Affine2DMatrix matrix)
        {
            return Multiply(this, matrix);
        }

        public Affine2DMatrix Translate(Point shift)
        {
            return Append(CreateTranslate(shift));
        }

        public Affine2DMatrix PrependTranslate(Point shift)
        {
            return Prepend(CreateTranslate(shift));
        }

        public Affine2DMatrix Scale(float factor)
        {
            return Scale(factor, factor);
        }

        public Affine2DMatrix Scale(float dx, float dy)
        {
            return Append(CreateScale(dx, dy));
        }

        public Affine2DMatrix PrependScale(float factor)
        {
            return PrependScale(factor, factor);
        }

        public Affine2DMatrix PrependScale(float dx, float dy)
        {
            return Prepend(CreateScale(dx, dy));
        }

        public Affine2DMatrix ScaleAt(float factor, Point center)
        {
            return ScaleAt(factor, factor, center);
        }

        public Affine2DMatrix ScaleAt(float dx, float dy, Point center)
        {
            return Translate(center)
                .Scale(dx, dy)
                .Translate(-center);
        }

        public Affine2DMatrix PrependScaleAt(float factor, Point center)
        {
            return PrependScaleAt(factor, factor, center);
        }

        public Affine2DMatrix PrependScaleAt(float dx, float dy, Point center)
        {
            return Prepend(CreateTranslate(center)
                .Scale(dx, dy)
                .Translate(-center));
        }

        public Affine2DMatrix Rotate(float angle)
        {
            return Append(CreateRotate(angle));
        }

        public Affine2DMatrix PrependRotate(float angle)
        {
            return Prepend(CreateRotate(angle));
        }

        public Affine2DMatrix RotateAt(float angle, Point center)
        {
            return Translate(center)
                .Rotate(angle)
                .Translate(-center);
        }

        public Affine2DMatrix PrependRotateAt(float angle, Point center)
        {
            return Prepend(CreateTranslate(center)
                .Rotate(angle)
                .Translate(-center));
        }

        // Makes a matrix the identity matrix when the parameterless
        // constructor is called
        partial void OnConstruction()
        {           
            M11 = 1f;
            M12 = 0f;
            M21 = 0f;
            M22 = 1f;
            D1 = 0f;
            D2 = 0f;
        }
    }
}
