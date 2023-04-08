using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CG_Project;

namespace CG_Project.Tests
{
    [TestClass]
    public class PointVectorTests
    {
        void PointAssert(Point actual, Point result)
        {
            Assert.AreEqual(actual.Rows, result.Rows);
            Assert.AreEqual(actual.Cols, result.Cols);

            for (int i = 0; i < actual.Rows; i++)
                for (int j = 0; j < actual.Cols; j++)
                    Assert.AreEqual(actual[i, j], result[i, j]);
        }

        [TestMethod]
        public void OrtonormScalar()
        {
            Vector vector1 = new Vector(1, 6, 9, 4);
            Vector vector2 = new Vector(8, 5, 0, 1);

            float result = vector1 % vector2;

            Assert.AreEqual(42f, result);
        }

        [TestMethod]

        public void VectorProd()
        {
            Vector vector1 = new Vector(1, 6, 9);
            Vector vector2 = new Vector(8, 5, 0);

            Vector actual = new Vector(-45, 72, -43);

            Vector result = vector1 ^ vector2;

            PointAssert(actual, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionExeption))]
        public void VectorProdNon3D()
        {
            Vector vector1 = new Vector(1, 6, 9, 4);
            Vector vector2 = new Vector(8, 5, 0, 1);

            Vector result = vector1 ^ vector2;

            Assert.AreEqual(null, result);
        }

        [TestMethod]

        public void VectorOrtoLength()
        {
            Vector vector = new Vector(1, 6, 5, 3, 7, 1);

            float result = vector.Lenght();

            Assert.AreEqual(11, result);
        }

        [TestMethod]
        
        public void VectorSum()
        {
            Vector vector1 = new Vector(1, 6, 9, 4);
            Vector vector2 = new Vector(8, 5, 0, 1);

            Vector actual = new Vector(9, 11, 9, 5);

            Vector result = vector1 + vector2;

            PointAssert(actual, result);
        }

        [TestMethod]

        public void ScalarMult()
        {
            Vector vector = new Vector(1, 6, 9, 4);

            Vector actual = new Vector(3, 18, 27, 12);
            Vector result = vector * 3;

            PointAssert(result, actual);
        }

        [TestMethod]

        public void ScalarNegMult()
        {
            Vector vector = new Vector(1, -6, 9, -4);

            Vector actual = new Vector(-3, 18, -27, 12);
            Vector result = vector * -3;

            PointAssert(result, actual);
        }

        [TestMethod]

        public void PointVectorSum()
        {
            Vector vector = new Vector(1, 3, 5, 4);
            Point point = new Vector(8, 1, 5, 4);

            Point actual = new Vector(9, 4, 10, 8);

            Point result = point + vector;

            PointAssert(actual, result);
        }
    }
}
