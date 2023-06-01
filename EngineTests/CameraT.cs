using CG_Project.Tests.MathTests;
using CGProject.Engine;
using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project.Tests.EngineTests
{
    [TestClass]
    public class CameraT
    {
        Game gameInit()
        {
            return new Game
                      (new CoordinateSystem(new Point(0, 0, 0),
                       new VectorSpace(new Vector(1, 0, 0),
                                       new Vector(0, 1, 0),
                                       new Vector(0, 0, 1))),
                       new EntityList());
        }

        [TestMethod]
        public void DirectedPos()
        {
            GameCamera cam = new(gameInit(),
                                 new Point(0, 0, 0),
                                 new Vector(1, 0, 0),
                                 120f, 20f);

            MatrixT.TableAssert(new Point(0, 0, 0), cam[EntityProp.Position]);
        }

        [TestMethod]
        public void DirectedDir()
        {
            GameCamera cam = new(gameInit(),
                                 new Point(0, 0, 0),
                                 new Vector(1, 0, 0),
                                 120f, 20f);

            MatrixT.TableAssert(new Vector(1, 0, 0), cam[EntityProp.Direction]);
        }

        [TestMethod]
        public void DirectedFoV()
        {
            GameCamera cam = new(gameInit(),
                                 new Point(0, 0, 0),
                                 new Vector(1, 0, 0),
                                 120f, 20f);

            Assert.AreEqual(120f, cam[EntityProp.FoV]);
        }

        [TestMethod]
        public void DirectedDist()
        {
            GameCamera cam = new(gameInit(),
                                 new Point(0, 0, 0),
                                 new Vector(1, 0, 0),
                                 120f, 20f);

            Assert.AreEqual(20f, cam[EntityProp.DrawDist]);
        }
    }
}
