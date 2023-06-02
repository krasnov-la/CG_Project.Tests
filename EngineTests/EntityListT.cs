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
    public class EntityListT
    {
        EntityList entL = new();
        Entity[] testSet = new Entity[5];

        [TestInitialize]
        public void TestInit()
        {
            for (int i = 0; i < 5; i++)
            {
                entL = new();
                Entity ent = new(new CoordinateSystem(new Point(0, 0, 0),
                new VectorSpace(new Vector(1, 0, 0),
                                new Vector(0, 1, 0),
                                new Vector(0, 0, 1))));

                ent[EntityProp.Direction] = new Vector(i + 1, i + 2, i + 3);

                testSet[i] = ent;
            }
        }

        void Inverse(Entity ent)
        {
            ent[EntityProp.Direction] = -1 * (Vector)ent[EntityProp.Direction];
        }

        [TestMethod]
        public void Add1()
        {
            entL.Add(testSet[0]);
            Assert.IsTrue(entL.Contains(testSet[0].Identifier));
        }

        [TestMethod]
        public void Add2()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            Assert.IsTrue(entL.Contains(testSet[1].Identifier));
        }

        [TestMethod]
        public void Add3()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            Assert.IsTrue(entL.Contains(testSet[2].Identifier));
        }

        [TestMethod]
        public void Add4()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            Assert.IsTrue(entL.Contains(testSet[3].Identifier));
        }

        [TestMethod]
        public void Add5()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            Assert.IsTrue(entL.Contains(testSet[4].Identifier));
        }

        [TestMethod]
        public void Get1()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            Assert.AreEqual(entL[testSet[0].Identifier], testSet[0]);
        }

        [TestMethod]
        public void Get2()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            Assert.AreEqual(entL[testSet[2].Identifier], testSet[2]);
        }

        [TestMethod]
        public void Get3()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            Assert.AreEqual(entL[testSet[4].Identifier], testSet[4]);
        }

        [TestMethod]
        public void Remove1ID()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Remove(testSet[2]);
            Assert.IsFalse(entL.Contains(testSet[2].Identifier));
        }

        [TestMethod]
        public void Remove2Ent()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Remove(testSet[2]);
            entL.Remove(testSet[0]);
            Assert.IsFalse(entL.Contains(testSet[0].Identifier));
        }

        [TestMethod]
        public void Remove3()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Remove(testSet[2]);
            entL.Remove(testSet[0]);
            Assert.IsTrue(entL.Contains(testSet[1].Identifier));
        }

        [TestMethod]
        public void Remove4()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Remove(testSet[2]);
            entL.Remove(testSet[0]);
            Assert.IsTrue(entL.Contains(testSet[3].Identifier));
        }

        [TestMethod]
        public void Remove5()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Remove(testSet[2]);
            entL.Remove(testSet[0]);
            Assert.IsTrue(entL.Contains(testSet[4].Identifier));
        }

        [TestMethod]
        public void Exec1()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-1, -2, -3), entL[testSet[0].Identifier][EntityProp.Direction]);
        }

        [TestMethod]
        public void Exec2()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-2, -3, -4), entL[testSet[1].Identifier][EntityProp.Direction]);
        }

        [TestMethod]
        public void Exec3()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-3, -4, -5), entL[testSet[2].Identifier][EntityProp.Direction]);
        }

        [TestMethod]
        public void Exec4()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-4, -5, -6), entL[testSet[3].Identifier][EntityProp.Direction]);
        }

        [TestMethod]
        public void Exec5()
        {
            entL.Add(testSet[0]);
            entL.Add(testSet[1]);
            entL.Add(testSet[2]);
            entL.Add(testSet[3]);
            entL.Add(testSet[4]);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-5, -6, -7), entL[testSet[4].Identifier][EntityProp.Direction]);
        }
    }
}
