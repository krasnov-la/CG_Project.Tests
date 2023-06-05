using CGProject.Engine;
using CGProject.Math;
using CG_Project.Tests.MathTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project.Tests.EngineTests
{
    [TestClass]
    public class GameObjectT
    {

        GameObject objInit()
        {
            return new HyperPlane(new Game
                      (new CoordinateSystem(new Point(0, 0, 0),
                       new VectorSpace(new Vector(1, 0, 0),
                                       new Vector(0, 1, 0),
                                       new Vector(0, 0, 1))),
                       new ObjectList()),
                   new Point(0, 0, 0),
                   new Vector(1, 0, 0));
        }

        [TestMethod]
        public void Move1()
        {
            GameObject obj = objInit();
            obj.Move(new Vector(1, 1, 1));  
            MatrixT.TableAssert(new Point(1, 1, 1), obj.Position);
        }

        [TestMethod]
        public void Move2()
        {
            GameObject obj = objInit();
            obj.Move(new Vector(1, 1, 1));
            obj.Move(new Vector(1, -2, -1));
            MatrixT.TableAssert(new Point(2, -1, 0), obj.Position);
        }

        [TestMethod]
        public void SetPos1()
        {
            GameObject obj = objInit();

            obj.SetPos(new Point(2, 3, -4));
            MatrixT.TableAssert(new Point(2, 3, -4), obj.Position);
        }

        [TestMethod]
        public void SetPos2()
        {
            GameObject obj = objInit();

            obj.SetPos(new Point(2, 3, -4));
            obj.SetPos(new Point(8, 3, 1));
            MatrixT.TableAssert(new Point(8, 3, 1), obj.Position);
        }

        [TestMethod]
        public void SetPos3()
        {
            GameObject obj = objInit();

            obj.SetPos(new Point(2, 3, -4));
            obj.SetPos(new Point(8, 3, 1));
            obj.SetPos(new Point(6, 6, 6));
            MatrixT.TableAssert(new Point(6, 6, 6), obj.Position);
        }

        
    }
}
