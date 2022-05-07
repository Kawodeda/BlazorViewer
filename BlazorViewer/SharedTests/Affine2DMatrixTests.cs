using System;
using Aurigma.Design.Math;
using NUnit.Framework;

namespace SharedTests
{
    public class Affine2DMatrixTests
    {       
        //                    1 0 0
        // IdentityMatrix  =  0 1 0
        //                    0 0 1
        public static Affine2DMatrix IdentityMatrix { get; } = new Affine2DMatrix()
        {
            M11 = 1f,
            M12 = 0f,
            M21 = 0f,
            M22 = 1f,
            D1 = 0f,
            D2 = 0f
        };

        public const float Pi = (float)Math.PI;

        [Test]
        public void Parameterless_constructor_returns_identity()
        {
            Affine2DMatrix expected = IdentityMatrix;

            // Call parameterless constructor
            var actual = new Affine2DMatrix();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_identity_returns_identity()
        {
            Affine2DMatrix expected = IdentityMatrix;

            Affine2DMatrix actual = Affine2DMatrix.CreateIdentity();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_translate_returns_translation_matrix()
        {
            var destination = new Point()
            {
                X = 1.43f,
                Y = -11f
            };

            //              1 0 destination.x
            // expected  =  0 1 destination.y
            //              0 0 1
            var expected = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = destination.X,
                D2 = destination.Y
            };

            Affine2DMatrix actual = Affine2DMatrix.CreateTranslate(destination);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_scale_returns_scale_matrix()
        {
            float dx = 1.5f;
            float dy = 2f;

            //              dx 0  0
            // expected  =  0  dy 0
            //              0  0  1
            var expected = new Affine2DMatrix()
            {
                M11 = dx,
                M12 = 0f,
                M21 = 0f,
                M22 = dy,
                D1 = 0f,
                D2 = 0f
            };

            Affine2DMatrix actual = Affine2DMatrix.CreateScale(dx, dy);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_scale_one_value_returns_scale_matrix()
        {
            float scale = 0.5f;

            //              scale 0     0
            // expected  =  0     scale 0
            //              0     0     1
            var expected = new Affine2DMatrix()
            {
                M11 = scale,
                M12 = 0f,
                M21 = 0f,
                M22 = scale,
                D1 = 0f,
                D2 = 0f
            };

            Affine2DMatrix actual = Affine2DMatrix.CreateScale(scale);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_rotate_returns_rotation_matrix()
        {
            // Angle in radians
            float angle = Pi / 5f;
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            //              cos(angle) -sin(angle) 0
            // expected  =  sin(angle)  cos(angle) 0
            //              0           0          1
            var expected = new Affine2DMatrix()
            {
                M11 = cos,
                M12 = -sin,
                M21 = sin,
                M22 = cos,
                D1 = 0f,
                D2 = 0f
            };

            Affine2DMatrix actual = Affine2DMatrix.CreateRotate(angle);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_returns_product_of_matrices()
        {
            //             1 2 3
            // matrix1  =  4 5 6
            //             0 0 1  
            var matrix1 = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 2f,
                M21 = 4f,
                M22 = 5f,
                D1 = 3f,
                D2 = 6f
            };

            //             7  8  9
            // matrix2  =  10 11 12
            //             0  0  1  
            var matrix2 = new Affine2DMatrix()
            {
                M11 = 7f,
                M12 = 8f,
                M21 = 10f,
                M22 = 11f,
                D1 = 9f,
                D2 = 12f
            };

            //              27 30 36
            // expected  =  78 87 102
            //              0  0  1  
            var expected = new Affine2DMatrix()
            {
                M11 = 27f,
                M12 = 30f,
                M21 = 78f,
                M22 = 87f,
                D1 = 36f,
                D2 = 102f
            };

            Affine2DMatrix actual = Affine2DMatrix.Multiply(matrix1, matrix2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_returns_product_of_matrices_reversed()
        {
            //             1 2 3
            // matrix1  =  4 5 6
            //             0 0 1  
            var matrix1 = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 2f,
                M21 = 4f,
                M22 = 5f,
                D1 = 3f,
                D2 = 6f
            };

            //             7  8  9
            // matrix2  =  10 11 12
            //             0  0  1  
            var matrix2 = new Affine2DMatrix()
            {
                M11 = 7f,
                M12 = 8f,
                M21 = 10f,
                M22 = 11f,
                D1 = 9f,
                D2 = 12f
            };

            //              39 54 78
            // expected  =  54 75 108
            //              0  0  1  
            var expected = new Affine2DMatrix()
            {
                M11 = 39f,
                M12 = 54f,
                M21 = 54f,
                M22 = 75f,
                D1 = 78f,
                D2 = 108f
            };

            Affine2DMatrix actual = Affine2DMatrix.Multiply(matrix2, matrix1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_returns_product_of_matrices()
        {
            //             2 3 4
            // matrix1  =  5 6 7
            //             0 0 1  
            var matrix1 = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 3f,
                M21 = 5f,
                M22 = 6f,
                D1 = 4f,
                D2 = 7f
            };

            //             8  9  10
            // matrix2  =  11 12 13
            //             0  0  1  
            var matrix2 = new Affine2DMatrix()
            {
                M11 = 8f,
                M12 = 9f,
                M21 = 11f,
                M22 = 12f,
                D1 = 10f,
                D2 = 13f
            };

            //              61 78  105
            // expected  =  82 105 141
            //              0  0   1  
            var expected = new Affine2DMatrix()
            {
                M11 = 61f,
                M12 = 78f,
                M21 = 82f,
                M22 = 105f,
                D1 = 105f,
                D2 = 141f
            };

            Affine2DMatrix actual = matrix1.Prepend(matrix2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Append_returns_product_of_matrices()
        {
            //             2 3 4
            // matrix1  =  5 6 7
            //             0 0 1  
            var matrix1 = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 3f,
                M21 = 5f,
                M22 = 6f,
                D1 = 4f,
                D2 = 7f
            };

            //             8  9  10
            // matrix2  =  11 12 13
            //             0  0  1  
            var matrix2 = new Affine2DMatrix()
            {
                M11 = 8f,
                M12 = 9f,
                M21 = 11f,
                M22 = 12f,
                D1 = 10f,
                D2 = 13f
            };

            //              49  54  63
            // expected  =  106 117 135
            //              0   0   1  
            var expected = new Affine2DMatrix()
            {
                M11 = 49f,
                M12 = 54f,
                M21 = 106f,
                M22 = 117f,
                D1 = 63f,
                D2 = 135f
            };

            Affine2DMatrix actual = matrix1.Append(matrix2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiplying_operator_returns_product()
        {
            //             1 2 3
            // matrix1  =  4 5 6
            //             0 0 1  
            var matrix1 = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 2f,
                M21 = 4f,
                M22 = 5f,
                D1 = 3f,
                D2 = 6f
            };

            //             7  8  9
            // matrix2  =  10 11 12
            //             0  0  1  
            var matrix2 = new Affine2DMatrix()
            {
                M11 = 7f,
                M12 = 8f,
                M21 = 10f,
                M22 = 11f,
                D1 = 9f,
                D2 = 12f
            };

            //              27 30 36
            // expected  =  78 87 102
            //              0  0  1  
            var expected = new Affine2DMatrix()
            {
                M11 = 27f,
                M12 = 30f,
                M21 = 78f,
                M22 = 87f,
                D1 = 36f,
                D2 = 102f
            };

            Affine2DMatrix actual = matrix1 * matrix2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiplying_operator_returns_product_reversed()
        {
            //             1 2 3
            // matrix1  =  4 5 6
            //             0 0 1  
            var matrix1 = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 2f,
                M21 = 4f,
                M22 = 5f,
                D1 = 3f,
                D2 = 6f
            };

            //             7  8  9
            // matrix2  =  10 11 12
            //             0  0  1  
            var matrix2 = new Affine2DMatrix()
            {
                M11 = 7f,
                M12 = 8f,
                M21 = 10f,
                M22 = 11f,
                D1 = 9f,
                D2 = 12f
            };

            //              39 54 78
            // expected  =  54 75 108
            //              0  0  1  
            var expected = new Affine2DMatrix()
            {
                M11 = 39f,
                M12 = 54f,
                M21 = 54f,
                M22 = 75f,
                D1 = 78f,
                D2 = 108f
            };

            Affine2DMatrix actual = matrix2 * matrix1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Translate_returns_translated_matrix()
        {
            //            1 0 5
            // matrix  =  0 1 0
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 5f,
                D2 = 0f
            };

            var destination = new Point()
            {
                X = 10f,
                Y = 20f
            };

            //              1 0 15
            // expected  =  0 1 20
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            Affine2DMatrix actual = matrix.Translate(destination);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_translate_returns_translated_matrix()
        {
            //            1 0 5
            // matrix  =  0 1 0
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 5f,
                D2 = 0f
            };

            var destination = new Point()
            {
                X = 10f,
                Y = 20f
            };

            //              1 0 15
            // expected  =  0 1 20
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            Affine2DMatrix actual = matrix.PrependTranslate(destination);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Scale_returns_scaled_matrix()
        {
            //            1 0 15
            // matrix  =  0 1 20
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            float dx = 2f;
            float dy = 3f;

            //              2 0 15
            // expected  =  0 3 20
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 3f,
                D1 = 15f,
                D2 = 20f
            };

            Affine2DMatrix actual = matrix.Scale(dx, dy);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_scale_returns_scaled_matrix()
        {
            //            1 0 15
            // matrix  =  0 1 20
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            float dx = 2f;
            float dy = 3f;

            //              2 0 30
            // expected  =  0 3 60
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 3f,
                D1 = 30f,
                D2 = 60f
            };

            Affine2DMatrix actual = matrix.PrependScale(dx, dy);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Scale_one_value_returns_scaled_matrix()
        {
            //            1 0 15
            // matrix  =  0 1 20
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            float factor = 2f;

            //              2 0 15
            // expected  =  0 2 20
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 15f,
                D2 = 20f
            };

            Affine2DMatrix actual = matrix.Scale(factor);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_scale_one_value_returns_scaled_matrix()
        {
            //            1 0 15
            // matrix  =  0 1 20
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            float factor = 2f;

            //              2 0 30
            // expected  =  0 2 40
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 30f,
                D2 = 40f
            };

            Affine2DMatrix actual = matrix.PrependScale(factor);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Scale_at_returns_scaled_matrix_at_center()
        {
            //            1 0 15
            // matrix  =  0 1 20
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            float dx = 2f;
            float dy = 3f;
            var center = new Point()
            {
                X = 10,
                Y = 15
            };

            //              2 0 5
            // expected  =  0 3 -10
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 3f,
                D1 = 5f,
                D2 = -10f
            };

            Affine2DMatrix actual = matrix.ScaleAt(dx, dy, center);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Scale_at_one_value_returns_scaled_matrix_at_center()
        {
            //            1 0 15
            // matrix  =  0 1 20
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            float factor = 2f;
            var center = new Point()
            {
                X = 10,
                Y = 15
            };

            //              2 0 5
            // expected  =  0 2 5
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 5f,
                D2 = 5f
            };

            Affine2DMatrix actual = matrix.ScaleAt(factor, center);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_scale_at_returns_scaled_matrix_at_center()
        {
            //            1 0 15
            // matrix  =  0 1 20
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            float dx = 2f;
            float dy = 3f;
            var center = new Point()
            {
                X = 10,
                Y = 15
            };

            //              2 0 20
            // expected  =  0 3 30
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 3f,
                D1 = 20f,
                D2 = 30f
            };

            Affine2DMatrix actual = matrix.PrependScaleAt(dx, dy, center);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_scale_at_one_value_returns_scaled_matrix_at_center()
        {
            //            1 0 15
            // matrix  =  0 1 20
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 1f,
                M12 = 0f,
                M21 = 0f,
                M22 = 1f,
                D1 = 15f,
                D2 = 20f
            };

            float factor = 2f;
            var center = new Point()
            {
                X = 10,
                Y = 15
            };

            //              2 0 20
            // expected  =  0 2 25
            //              0 0 1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 20f,
                D2 = 25f
            };

            Affine2DMatrix actual = matrix.PrependScaleAt(factor, center);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rotate_returns_rotated_matrix()
        {
            float angle = Pi / 6f;
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            //            2 0 20
            // matrix  =  0 2 25
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 20f,
                D2 = 25f
            };

            //              2cos -2sin 20
            // expected  =  2sin 2cos  25
            //              0    0     1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f * cos,
                M12 = -2f * sin,
                M21 = 2f * sin,
                M22 = 2f * cos,
                D1 = 20f,
                D2 = 25f
            };

            Affine2DMatrix actual = matrix.Rotate(angle);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_rotate_returns_rotated_matrix()
        {
            float angle = Pi / 6f;
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            //            2 0 20
            // matrix  =  0 2 25
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 20f,
                D2 = 25f
            };

            //              2cos -2sin 20cos - 25sin
            // expected  =  2sin 2cos  20sin + 25cos
            //              0    0     1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f * cos,
                M12 = -2f * sin,
                M21 = 2f * sin,
                M22 = 2f * cos,
                D1 = 20f * cos - 25f * sin,
                D2 = 20f * sin + 25f * cos
            };

            Affine2DMatrix actual = matrix.PrependRotate(angle);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rotate_at_returns_rotated_matrix_at_center()
        {
            float angle = Pi / 6f;
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            //            2 0 20
            // matrix  =  0 2 25
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 20f,
                D2 = 25f
            };

            var center = new Point()
            {
                X = 10,
                Y = 15
            };

            //              2cos -2sin -20cos + 30sin + 40
            // expected  =  2sin 2cos  -20sin - 30cos + 55
            //              0    0     1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f * cos,
                M12 = -2f * sin,
                M21 = 2f * sin,
                M22 = 2f * cos,
                D1 = -20f * cos + 30f * sin + 40f,
                D2 = -20f * sin - 30f * cos + 55f
            };

            Affine2DMatrix actual = matrix.RotateAt(angle, center);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_rotate_at_returns_rotated_matrix_at_center()
        {
            float angle = Pi / 6f;
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            //            2 0 20
            // matrix  =  0 2 25
            //            0 0 1  
            var matrix = new Affine2DMatrix()
            {
                M11 = 2f,
                M12 = 0f,
                M21 = 0f,
                M22 = 2f,
                D1 = 20f,
                D2 = 25f
            };

            var center = new Point()
            {
                X = 10,
                Y = 15
            };

            //              2cos -2sin 10cos - 10sin + 10
            // expected  =  2sin 2cos  10sin + 10cos + 15
            //              0    0     1 
            var expected = new Affine2DMatrix()
            {
                M11 = 2f * cos,
                M12 = -2f * sin,
                M21 = 2f * sin,
                M22 = 2f * cos,
                D1 = 10f * cos - 10f * sin + 10f,
                D2 = 10f * sin + 10f * cos + 15f
            };

            Affine2DMatrix actual = matrix.PrependRotateAt(angle, center);

            Assert.AreEqual(expected, actual);
        }
    }
}