using System;

namespace Aurigma.Design.Math
{
    public sealed partial class Affine2DMatrix
    {
        public static Affine2DMatrix CreateIdentity()
        {
            return new Affine2DMatrix();
        }

        public static Affine2DMatrix CreateTranslate(Point destination)
        {
            Affine2DMatrix result = CreateIdentity();
            result.d1_ = destination.X;
            result.d2_ = destination.Y;

            return result;
        }

        public static Affine2DMatrix CreateScale(float dx, float dy)
        {
            Affine2DMatrix result = CreateIdentity();
            result.m11_ = dx;
            result.m22_ = dy;

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
            result.m11_ = cos;
            result.m12_ = -sin;
            result.m21_ = sin;
            result.m22_ = cos;

            return result;
        }

        public static Affine2DMatrix Multiply(Affine2DMatrix a, Affine2DMatrix b)
        {
            return new Affine2DMatrix()
            {
                m11_ = a.m11_ * b.m11_ + a.m12_ * b.m21_,
                m12_ = a.m11_ * b.m12_ + a.m12_ * b.m22_,
                m21_ = a.m21_ * b.m11_ + a.m22_ * b.m21_,
                m22_ = a.m21_ * b.m12_ + a.m22_ * b.m22_,
                d1_ = a.m11_ * b.d1_ + a.m12_ * b.d2_ + a.d1_,
                d2_ = a.m21_ * b.d1_ + a.m22_ * b.d2_ + a.d2_
            };
        }

        public static Affine2DMatrix operator *(Affine2DMatrix a, Affine2DMatrix b)
            => Multiply(a, b);

        public Affine2DMatrix Prepend(Affine2DMatrix matrix)
        {
            return Multiply(matrix, this);
        }

        public Affine2DMatrix Append(Affine2DMatrix matrix)
        {
            return Multiply(this, matrix);
        }

        public Affine2DMatrix Translate(Point destination)
        {
            return Append(CreateTranslate(destination));
        }

        public Affine2DMatrix PrependTranslate(Point destination)
        {
            return Prepend(CreateTranslate(destination));
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
            m11_ = 1f;
            m12_ = 0f;
            m21_ = 0f;
            m22_ = 1f;
            d1_ = 0f;
            d2_ = 0f;
        }
    }
}
