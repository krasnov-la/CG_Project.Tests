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
    public class ObjectListT
    {
        ObjectList entL = new();
        GameObject[] testSet = new GameObject[5];

        [TestInitialize]
        public void TestInit()
        {
            for (int i = 0; i < 5; i++)
            {
                entL = new();
                GameObject ent = new HyperPlane(new Game(new CoordinateSystem(new Point(0, 0, 0),
                                                                          new VectorSpace(new Vector(1, 0, 0),
                                                                                          new Vector(0, 1, 0),
                                                                                          new Vector(0, 0, 1))),
                                                     new ObjectList()),
                                            new Point(i + 1, i + 2, i + 3),
                                            new Vector(1, 0, 0));

                testSet[i] = ent;
            }
        }

        void Move(GameObject obj)
        {
            obj.Move(new Vector(1, 1, 1));
        }

        void Adder(int num)
        {
            for (int i = 0; i < num; i++)
            {
                entL.Add(testSet[i]);
            }
        }

        [TestMethod]
        public void Add1()
        {
            Adder(1);
            Assert.IsTrue(entL.Contains(testSet[0].Identifier));
        }

        [TestMethod]
        public void Add2()
        {
            Adder(2);
            Assert.IsTrue(entL.Contains(testSet[1].Identifier));
        }

        [TestMethod]
        public void Add3()
        {
            Adder(3);
            Assert.IsTrue(entL.Contains(testSet[2].Identifier));
        }

        [TestMethod]
        public void Add4()
        {
            Adder(4);
            Assert.IsTrue(entL.Contains(testSet[3].Identifier));
        }

        [TestMethod]
        public void Add5()
        {
            Adder(5);
            Assert.IsTrue(entL.Contains(testSet[4].Identifier));
        }

        [TestMethod]
        public void Get1()
        {
            Adder(5);
            Assert.AreEqual(entL[testSet[0].Identifier], testSet[0]);
        }

        [TestMethod]
        public void Get2()
        {
            Adder(5);
            Assert.AreEqual(entL[testSet[2].Identifier], testSet[2]);
        }

        [TestMethod]
        public void Get3()
        {
            Adder(5);
            Assert.AreEqual(entL[testSet[4].Identifier], testSet[4]);
        }

        [TestMethod]
        public void Remove1ID()
        {
            Adder(5);
            entL.Remove(testSet[2]);
            Assert.IsFalse(entL.Contains(testSet[2].Identifier));
        }

        [TestMethod]
        public void Remove2Ent()
        {
            Adder(5);
            entL.Remove(testSet[2]);
            entL.Remove(testSet[0]);
            Assert.IsFalse(entL.Contains(testSet[0].Identifier));
        }

        [TestMethod]
        public void Remove3()
        {
            Adder(5);
            entL.Remove(testSet[2]);
            entL.Remove(testSet[0]);
            Assert.IsTrue(entL.Contains(testSet[1].Identifier));
        }

        [TestMethod]
        public void Remove4()
        {
            Adder(5);
            entL.Remove(testSet[2]);
            entL.Remove(testSet[0]);
            Assert.IsTrue(entL.Contains(testSet[3].Identifier));
        }

        [TestMethod]
        public void Remove5()
        {
            Adder(5);
            entL.Remove(testSet[2]);
            entL.Remove(testSet[0]);
            Assert.IsTrue(entL.Contains(testSet[4].Identifier));
        }

        /*[TestMethod]
        public void Exec1()
        {
            Adder(5);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-1, -2, -3), entL[testSet[0].Identifier][EntityProp.Direction]);
        }

        [TestMethod]
        public void Exec2()
        {
            Adder(5);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-2, -3, -4), entL[testSet[1].Identifier][EntityProp.Direction]);
        }

        [TestMethod]
        public void Exec3()
        {
            Adder(5);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-3, -4, -5), entL[testSet[2].Identifier][EntityProp.Direction]);
        }

        [TestMethod]
        public void Exec4()
        {
            Adder(5);
            entL.Exec(Inverse);
            MatrixT.TableAssert(new Vector(-4, -5, -6), entL[testSet[3].Identifier][EntityProp.Direction]);
        }

        [TestMethod]
        public void Exec5()
        {
            Adder(5);
            entL.Exec();
            MatrixT.TableAssert(new Vector(-5, -6, -7), entL[testSet[4].Identifier][EntityProp.Direction]);
        }*/

        [TestMethod]

        public void ForEach()
        {
            Adder(5);
            foreach (Entity ent in entL)
            {
                Assert.IsTrue(testSet.Contains(ent));
            }
        }
    }
}
