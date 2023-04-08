using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Specialized;
using CG_Project;

namespace CG_Project.Tests
{
    [TestClass]
    public class MatrixTests
    {
        void MatrixAssert(Matrix actual, Matrix result)
        {
            Assert.AreEqual(actual.Rows, result.Rows);
            Assert.AreEqual(actual.Cols, result.Cols);

            for (int i = 0; i < actual.Rows; i++)
                for (int j = 0; j < actual.Cols; j++)
                {
                    Assert.AreEqual(actual[i, j], result[i, j], 1e-2);
                }
        }

        [TestMethod]
        public void BilinearIdentity()
        {
            Matrix identity = new Matrix(4);
            Vector vector1 = new Vector(2, 6, 3, 9);
            Vector vector2 = new Vector(3, 1, 9, 0);

            float result = identity.BilinearForm(vector1, vector2);

            Assert.AreEqual(39f, result);
        }

        [TestMethod]

        public void Bilinear()
        {
            Matrix matrix = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 },
                                                      { 4, 9, 1, 2 } });

            Vector vector1 = new Vector(2, 6, 3, 9);
            Vector vector2 = new Vector(3, 1, 9, 5);

            float result = matrix.BilinearForm(vector1, vector2);

            Assert.AreEqual(1057f, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionExeption))]
        public void BilinearMisInput()
        {
            Matrix matrix = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

            Vector vector1 = new Vector(2, 6, 3, 9);
            Vector vector2 = new Vector(3, 1, 9, 5);

            float result = matrix.BilinearForm(vector1, vector2);

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]
        public void Gram()
        {
            Vector vector1 = new Vector(2, 6, 3);
            Vector vector2 = new Vector(3, 1, 9);
            Vector vector3 = new Vector(9, 5, 1);

            Matrix result = Matrix.Gram(vector1, vector2, vector3);

            Assert.AreEqual("49 39 51\n39 91 41\n51 41 107", result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionExeption))]
        public void GramMisDim()
        {
            Vector vector1 = new Vector(2, 6, 3);
            Vector vector2 = new Vector(3, 1, 9);
            Vector vector3 = new Vector(9, 5);

            Matrix result = Matrix.Gram(vector1, vector2, vector3);

            Assert.AreEqual(null, result);
        }

        [TestMethod]

        public void GetCofactor()
        {
            Matrix matrix = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 },
                                                      { 4, 9, 1, 2 } });

            float result = matrix.GetCofactor(1, 2);

            Assert.AreEqual(-164f, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionExeption))]
        public void GetCofactorNonSquare()
        {
            Matrix matrix = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

            float result = matrix.GetCofactor(1, 2);

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]

        public void Determinant3()
        {
            Matrix matrix = new Matrix(new float[,] { { 1, 2, 3},
                                                      { 0, -1, -2},
                                                      { -3, 4, -4} });

            float result = matrix.Determinant();

            Assert.AreEqual(15f, result);
        }

        [TestMethod]

        public void Determinant4()
        {
            Matrix matrix = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 },
                                                      { 4, 9, 1, 2 } });

            float result = matrix.Determinant();

            Assert.AreEqual(1059, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionExeption))]
        public void DeterminantNonSquare()
        {
            Matrix matrix = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

        
            float result = matrix.Determinant();

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]

        public void Inverse()
        {
            Matrix matrix = new Matrix(new float[,] { { 2, 5, 7 },
                                                      { 6, 3, 4 },
                                                      { 5, -2, -3} });

            Matrix result = matrix.Inverse();

            Matrix actual = new Matrix(new float[,] { { 1, -1, 1 },
                                                      { -38, 41, -34 },
                                                      { 27, -29, 24} });

            MatrixAssert(actual, result);
        }


        [TestMethod]
        [ExpectedException(typeof(DimensionExeption))]
        public void InverseNonSquare()
        {
            Matrix matrix = new Matrix(new float[,] { { 2, 5, 7 },
                                                      { 6, 3, 4 } });

            Matrix result = matrix.Inverse();

            Assert.AreEqual(null, result);
        }

        [TestMethod]

        public void Sum()
        {
            Matrix matrix1 = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

            Matrix matrix2 = new Matrix(new float[,] { {1, 2, 4, 3 },
                                                       {0, 1, 3, 0 },
                                                       { 1, 5, 9, 1} });

            Matrix actual = new Matrix(new float[,] { {3, 6, 5, 11 },
                                                      {6, 9, 4, 5 },
                                                      {4, 6, 16, 1 } });

            Matrix result = matrix1 + matrix2;

            MatrixAssert(actual, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionExeption))]
        public void SumMisDim()
        {
            Matrix matrix1 = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

            Matrix matrix2 = new Matrix(new float[,] { {1, 2, 4, 3 },
                                                       {0, 1, 3, 0 }});

            Matrix result = matrix1 + matrix2;
            
            Assert.AreEqual(null, result);
        }

        [TestMethod]

        public void ScalarMult()
        {
            Matrix matrix1 = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

            Matrix actual = new Matrix(new float[,] { {5, 10, 2.5f, 20 },
                                                      {15, 20, 2.5f, 12.5f },
                                                      {7.5f, 2.5f, 17.5f, 0 } });

            Matrix result = matrix1 * 2.5f;

            MatrixAssert(actual, result);
        }

        [TestMethod]
        public void ScalarMultNeg()
        {
            Matrix matrix1 = new Matrix(new float[,] { { -2, 4, -1, 8 },
                                                      { 6, -8, 1, -5 },
                                                      { -3, 1, -7, 0 } });

            Matrix actual = new Matrix(new float[,] { {5, -10, 2.5f, -20 },
                                                      {-15, 20, -2.5f, 12.5f },
                                                      {7.5f, -2.5f, 17.5f, 0 } });

            Matrix result = matrix1 * -2.5f;

            MatrixAssert(actual, result);
        }

        [TestMethod]

        public void MatrixMult()
        {
            Matrix matrix1 = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

            Matrix matrix2 = new Matrix(new float[,] { {1, 2, 4},
                                                       {0, 1, 3},
                                                       { 1, 5, 9},
                                                       { 3, 0, 1 } });

            Matrix actual = new Matrix(new float[,] { { 27, 13, 37 },
                                                      { 22, 25, 62 },
                                                      { 10, 42, 78} });

            Matrix result = matrix1 * matrix2;

            MatrixAssert(actual, result);
        }

        [TestMethod]
        public void MatrixMultTranspose()
        {
            Matrix matrix1 = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

            Matrix matrix2 = new Matrix(new float[,] { {1, 2, 4},
                                                       {0, 1, 3},
                                                       { 1, 5, 9},
                                                       { 3, 0, 1 } });

            Matrix actual = new Matrix(new float[,] { { 27, 13, 37 },
                                                      { 22, 25, 62 },
                                                      { 10, 42, 78} });

            actual.Transpose();
            matrix1.Transpose();
            matrix2.Transpose();

            Matrix result = matrix2 * matrix1;

            MatrixAssert(actual, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionExeption))]

        public void MatrixMultMisInput()
        {
            Matrix matrix1 = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 } });

            Matrix matrix2 = new Matrix(new float[,] { {1, 2, 4},
                                                       {0, 1, 3},
                                                       { 1, 5, 9} });

            Matrix result = matrix1 * matrix2;

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void VectorToMatrix()
        {
            Vector vector = new Vector(4.5f, 2, 1, 9);

            Matrix vectorMatrix = new Matrix(vector);
            vector.Transpose();
            Matrix TVectorMatrix = new Matrix(vector);

            Matrix actualVectorMatrix = new Matrix(new float[,] { {4.5f }, { 2 }, { 1 }, { 9 } });
            Matrix actualTVectorMatrix = new Matrix(new float[,] { { 4.5f, 2, 1, 9 } });

            MatrixAssert(actualVectorMatrix, vectorMatrix);
            MatrixAssert(actualTVectorMatrix, TVectorMatrix);
        }
    }
}
