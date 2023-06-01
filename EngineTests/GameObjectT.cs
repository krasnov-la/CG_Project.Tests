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
            return new GameObject(new Game
                      (new CoordinateSystem(new Point(0, 0, 0),
                       new VectorSpace(new Vector(1, 0, 0),
                                       new Vector(0, 1, 0),
                                       new Vector(0, 0, 1))),
                       new EntityList()),
                   new Point(0, 0, 0),
                   new Vector(1, 0, 0));
        }

        [TestMethod]
        public void Move1()
        {
            GameObject obj = objInit();
            obj.Move(new Vector(1, 1, 1));
            MatrixT.TableAssert(new Point(1, 1, 1), obj[EntityProp.Position]);
        }

        [TestMethod]
        public void Move2()
        {
            GameObject obj = objInit();
            obj.Move(new Vector(1, 1, 1));
            obj.Move(new Vector(1, -2, -1));
            MatrixT.TableAssert(new Point(2, -1, 0), obj[EntityProp.Position]);
        }

        [TestMethod]
        public void SetPos1()
        {
            GameObject obj = objInit();

            obj.SetPos(new Point(2, 3, -4));
            MatrixT.TableAssert(new Point(2, 3, -4), obj[EntityProp.Position]);
        }

        [TestMethod]
        public void SetPos2()
        {
            GameObject obj = objInit();

            obj.SetPos(new Point(2, 3, -4));
            obj.SetPos(new Point(8, 3, 1));
            MatrixT.TableAssert(new Point(8, 3, 1), obj[EntityProp.Position]);
        }

        [TestMethod]
        public void SetPos3()
        {
            GameObject obj = objInit();

            obj.SetPos(new Point(2, 3, -4));
            obj.SetPos(new Point(8, 3, 1));
            obj.SetPos(new Point(6, 6, 6));
            MatrixT.TableAssert(new Point(6, 6, 6), obj[EntityProp.Position]);
        }

        [TestMethod]
        public void Rotate3D1()
        {
            GameObject obj = objInit();

            obj.Rotate3D(0, 90, 0);
            obj.Rotate3D(45, 0, 0);
            MatrixT.TableAssert(new Vector(0, (float)Math.Sqrt(2)/2, -(float)Math.Sqrt(2)/2), (Vector)obj[EntityProp.Direction]);
        }

        [TestMethod]
        public void Rotate3D2()
        {
            GameObject obj = objInit();

            obj.Rotate3D(0, 90, 0);
            obj.Rotate3D(45, 0, 0);
            MatrixT.TableAssert(new Vector(0, (float)Math.Sqrt(2) / 2, -(float)Math.Sqrt(2) / 2), (Vector)obj[EntityProp.Direction]);
        }

        [TestMethod]
        public void RotatePlanar1()
        {
            GameObject obj = objInit();

            obj.RotatePlanar(0, 2, 90);
            MatrixT.TableAssert(new Vector(0, 0, -1), (Vector)obj[EntityProp.Direction]);
        }

        [TestMethod]
        public void RotatePlanar2()
        {
            GameObject obj = objInit();

            obj.RotatePlanar(0, 2, 90);
            obj.RotatePlanar(1, 2, 45);
            MatrixT.TableAssert(new Vector(0, (float)Math.Sqrt(2) / 2, -(float)Math.Sqrt(2) / 2), (Vector)obj[EntityProp.Direction]);
        }

        [TestMethod]
        public void SetDir1()
        {
            GameObject obj = objInit();

            obj.SetDir(new Vector(2, 3, -4));
            MatrixT.TableAssert(new Vector(2, 3, -4), (Vector)obj[EntityProp.Direction]);
        }

        [TestMethod]
        public void SetDir2()
        {
            GameObject obj = objInit();

            obj.SetDir(new Vector(2, 3, -4));
            obj.SetDir(new Vector(8, 3, 1));
            MatrixT.TableAssert(new Vector(8, 3, 1), (Vector)obj[EntityProp.Direction]);
        }

        [TestMethod]
        public void SetDir3()
        {
            GameObject obj = objInit();

            obj.SetDir(new Vector(2, 3, -4));
            obj.SetDir(new Vector(8, 3, 1));
            obj.SetDir(new Vector(6, 6, 6));
            MatrixT.TableAssert(new Vector(6, 6, 6), (Vector)obj[EntityProp.Direction]);
        }
    }
}
