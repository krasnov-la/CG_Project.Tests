using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGProject.Engine;
using CGProject.Math;
using CG_Project.Tests.MathTests;

namespace CG_Project.Tests.EngineTests
{
    [TestClass]
    public class RayT
    {
        [TestMethod]
        public void Normalize1()
        {
            Ray ray = new(new CoordinateSystem(new Point(0, 0, 0),
                                               new VectorSpace(
                                                    new Vector(1, 0, 0), 
                                                    new Vector(0, 1, 0),
                                                    new Vector(0, 0, 1))),
                          new Point(0, 0, 0),
                          new Vector(1, 2, 3));

            ray.Normalize();

            MatrixT.TableAssert(new Vector(1, 2, 3) / (float)Math.Sqrt(14), ray.Dir);
        }

        [TestMethod]
        public void Normalize2()
        {
            Ray ray = new(new CoordinateSystem(new Point(0, 0, 0),
                                               new VectorSpace(
                                                    new Vector(1, 2, 3),
                                                    new Vector(0, 1, 0),
                                                    new Vector(0, 0, 1))),
                          new Point(0, 0, 0),
                          new Vector(1, 2, 3));

            ray.Normalize();

            MatrixT.TableAssert(new Vector(1, 2, 3) / (float)Math.Sqrt(53), ray.Dir);
        }
    }
}
