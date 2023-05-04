using CGProject.Math;

namespace CGProject.Tests
{
    [TestClass]
    public class VectorSpaceTests
    {
        VectorSpace VS = new VectorSpace(new Vector(1, 2, 3), new Vector(1, 3, 6), new Vector(2, 4, 7));

        [TestMethod]
        public void NonOrtonormScalarProd()
        {
            Vector vector1 = new Vector(3, 5, 6);
            Vector vector2 = new Vector(5, 6, 7);

            float result = VS.ScalarProduct(vector1, vector2);

            Assert.AreEqual(11120, result);
        }

        [TestMethod]

        public void PointAsVector()
        {
            Point point = new Point(1, 3, 7);

            Vector result = VS.AsVector(point);
            point.Transpose();
            Vector Tresult = VS.AsVector(point);

            Vector actual = new Vector(18, 39, 70);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(result[i], actual[i]);
                Assert.AreEqual(Tresult[i], actual[i]);
            }
        }
    }
}
