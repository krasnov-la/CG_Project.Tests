using CGProject;
using CGProject.Math;

namespace CG_Project.Tests.MathTests
{
    [TestClass]
    public class VectorSpaceT
    {
        [TestMethod]
        [ExpectedException(typeof(EngineExceptions.InvalidBasisException))]
        public void BasisCheck1()
        {
            VectorSpace vs = new VectorSpace();
        }

        [TestMethod]
        [ExpectedException(typeof(EngineExceptions.InvalidBasisException))]
        public void BasisCheck2()
        {
            VectorSpace vs = new VectorSpace(new Vector(1, 0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(EngineExceptions.InvalidBasisException))]
        public void BasisCheck3()
        {
            VectorSpace vs = new VectorSpace(new Vector(1, 0, 0), new Vector(0, 1, 0, 0), new Vector(0, 0, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(EngineExceptions.InvalidBasisException))]
        public void BasisCheck4()
        {
            VectorSpace vs = new VectorSpace(new Vector(1, 0, 0), new Vector(0, 1, 0), new Vector(0, 0, 1), new Vector(0, 0, 5));
        }

        [TestMethod]
        [ExpectedException(typeof(EngineExceptions.InvalidBasisException))]
        public void BasisCheck5()
        {
            VectorSpace vs = new VectorSpace(new Vector(1, 0, 0), new Vector(0, 1, 0), new Vector(1, 1, 0));
        }

        [TestMethod]
        public void BasisCheck6()
        {
            VectorSpace vs = new VectorSpace(new Vector(1, 0, 0), new Vector(0, 1, 0), new Vector(0, 0, 1));
        }

        static VectorSpace VS = new(new Vector(1, 2, 3), new Vector(1, 3, 6), new Vector(2, 4, 7));

        [TestMethod]
        public void NonOrtonormScalarProd()
        {
            Vector vector1 = new(3, 5, 6);
            Vector vector2 = new(5, 6, 7);

            float result = VS.ScalarProduct(vector1, vector2);

            Assert.AreEqual(11120, result);
        }

        [TestMethod]

        public void PointAsVector()
        {
            Point point = new(1, 3, 7);

            Vector result = VS.AsVector(point);
            point.Transpose();
            Vector Tresult = VS.AsVector(point);

            Vector actual = new(18, 39, 70);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(result[i], actual[i]);
                Assert.AreEqual(Tresult[i], actual[i]);
            }
        }
    }
}
