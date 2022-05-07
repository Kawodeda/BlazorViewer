using System;
using Aurigma.Design.Math;
using NUnit.Framework;

namespace SharedTests
{
    public class PointTests
    {
        public const float Pi = (float)Math.PI;

        [Test]
        public void Constructor_x_y_returns_point()
        {
            float x = 20f;
            float y = 30f;

            var expected = new Point()
            {
                X = x,
                Y = y
            };

            var actual = new Point(x, y);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_returns_multiplied_point()
        {
            var point = new Point()
            {
                X = 10f,
                Y = 15f
            };

            //            2 0 10
            // matrix  =  0 2 5
            //            0 0 1
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 10f,
                D2 = 5f
            };

            var expected = new Point()
            {
                X = 30f,
                Y = 35f
            };

            Point actual = Point.Multiply(matrix, point);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_is_commutative()
        {
            var point = new Point()
            {
                X = 10f,
                Y = 15f
            };

            //            2 0 10
            // matrix  =  0 2 5
            //            0 0 1
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 10f,
                D2 = 5f
            };

            Point product1 = Point.Multiply(matrix, point);
            Point product2 = Point.Multiply(point, matrix);

            Assert.AreEqual(product1, product2);
        }

        [Test]
        public void Multiply_by_returns_multiplied_point()
        {
            var point = new Point()
            {
                X = 10f,
                Y = 15f
            };

            //            2 0 10
            // matrix  =  0 2 5
            //            0 0 1
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 10f,
                D2 = 5f
            };

            var expected = new Point()
            {
                X = 30f,
                Y = 35f
            };

            Point actual = point.MultiplyBy(matrix);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiplying_operator_returns_multiplied_point()
        {
            var point = new Point()
            {
                X = 10f,
                Y = 15f
            };

            //            2 0 10
            // matrix  =  0 2 5
            //            0 0 1
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 10f,
                D2 = 5f
            };

            var expected = new Point()
            {
                X = 30f,
                Y = 35f
            };

            Point actual = point * matrix;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiplying_operator_is_commutative()
        {
            var point = new Point()
            {
                X = 10f,
                Y = 15f
            };

            //            2 0 10
            // matrix  =  0 2 5
            //            0 0 1
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 10f,
                D2 = 5f
            };

            Point product1 = matrix * point;
            Point product2 = point * matrix;

            Assert.AreEqual(product1, product2);
        }

        [Test]
        public void Negate_returns_negated_point()
        {
            var point = new Point()
            {
                X = 10f,
                Y = 15f
            };

            var expected = new Point()
            {
                X = -10f,
                Y = -15f
            };

            Point actual = Point.Negate(point);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Unary_minus_operator_returns_negated_point()
        {
            var point = new Point()
            {
                X = 10f,
                Y = 15f
            };

            var expected = new Point()
            {
                X = -10f,
                Y = -15f
            };

            Point actual = -point;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Translate_returns_translated_point()
        {
            var point = new Point()
            {
                X = 4f,
                Y = 10f
            };

            var destination = new Point()
            {
                X = 10f,
                Y = 5f
            };

            var expected = new Point()
            {
                X = 14f,
                Y = 15f
            };

            Point actual = point.Translate(destination);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Scale_returns_scaled_point()
        {
            var point = new Point()
            {
                X = 4f,
                Y = 10f
            };

            float dx = 2f;
            float dy = 3f;

            var expected = new Point()
            {
                X = 8f,
                Y = 30f
            };

            Point actual = point.Scale(dx, dy);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Scale_one_value_returns_scaled_point()
        {
            var point = new Point()
            {
                X = 4f,
                Y = 10f
            };

            float factor = 2f;

            var expected = new Point()
            {
                X = 8f,
                Y = 20f
            };

            Point actual = point.Scale(factor);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Scale_at_returns_scaled_point_at_center()
        {
            var point = new Point()
            {
                X = 4f,
                Y = 10f
            };

            var center = new Point()
            {
                X = 10f,
                Y = 5f
            };

            float dx = 2f;
            float dy = 3f;

            var expected = new Point()
            {
                X = -2f,
                Y = 20f
            };

            Point actual = point.ScaleAt(dx, dy, center);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Scale_at_one_value_returns_scaled_point_at_center()
        {
            var point = new Point()
            {
                X = 4f,
                Y = 10f
            };

            var center = new Point()
            {
                X = 10f,
                Y = 5f
            };

            float factor = 2f;

            var expected = new Point()
            {
                X = -2f,
                Y = 15f
            };

            Point actual = point.ScaleAt(factor, center);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rotate_returns_rotated_point()
        {
            var point = new Point()
            {
                X = 4f,
                Y = 0f
            };

            float angle = Pi / 2;
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            var expected = new Point()
            {
                X = point.X * cos - point.Y * sin,
                Y = point.X * sin + point.Y * cos
            };

            Point actual = point.Rotate(angle);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rotate_at_returns_rotated_point_at_center()
        {
            var point = new Point()
            {
                X = 4f,
                Y = 0f
            };

            var center = new Point()
            {
                X = 2f,
                Y = 2f
            };

            float angle = Pi / 2;
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            var expected = new Point()
            {
                X = point.X * cos - point.Y * sin - 2 * cos + 2 * sin + 2,
                Y = point.X * sin + point.Y * cos - 2 * sin - 2 * cos + 2
            };

            Point actual = point.RotateAt(angle, center);

            // Doesn't work without NearlyEquals
            Assert.IsTrue(expected.NearlyEquals(actual));
        }
    }
}
