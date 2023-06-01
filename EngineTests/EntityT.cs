using CGProject.Engine;
using CGProject.Math;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG_Project.Tests.MathTests;
using CGProject;

namespace CG_Project.Tests.EngineTests
{
    [TestClass]
    public class EntityT
    {
        Entity EntInit(Point pt)
        {
            return new Entity(new CoordinateSystem(pt,
                              new VectorSpace(new Vector(1, 0, 0),
                                              new Vector(0, 1, 0),
                                              new Vector(0, 0, 1))));
        }

        [TestMethod]

        public void PropsAdd1()
        {
            Entity ent = EntInit(new Point(0, 0, 0));
            
            Point pt = new(0, 0, 0);

            ent[EntityProp.Position] = pt;

            MatrixT.TableAssert(pt, ent[EntityProp.Position]);
        }

        [TestMethod]

        public void PropsAdd2()
        {
            Entity ent = EntInit(new Point(0, 0, 0));

            float dist = 10f;

            ent[EntityProp.DrawDist] = dist;

            Assert.AreEqual(10f, ent[EntityProp.DrawDist]);
        }

        [TestMethod]
        public void Contains1()
        {
            Entity ent = EntInit(new Point(0, 0, 0));
            Assert.IsFalse(ent.Contains(EntityProp.Position));
        }

        [TestMethod]
        public void Contains2()
        {
            Entity ent = EntInit(new Point(0, 0, 0));
            Assert.IsFalse(ent.Contains(EntityProp.FoV));
        }

        [TestMethod]
        public void Contains3()
        {
            Entity ent = EntInit(new Point(0, 0, 0));
            ent.SetProp(EntityProp.Position, new Point(1, 1, 1));
            Assert.IsTrue(ent.Contains(EntityProp.Position));
        }

        [TestMethod]
        public void Contains4()
        {
            Entity ent = EntInit(new Point(0, 0, 0));
            ent.SetProp(EntityProp.Position, new Point(1, 1, 1));
            Assert.IsFalse(ent.Contains(EntityProp.Direction));
        }

        [TestMethod]

        public void PropsRemove1()
        {
            Entity ent = EntInit(new Point(0, 0, 0));
            ent[EntityProp.DrawDist] = 10f;
            ent.RemoveProp(EntityProp.DrawDist);
            Assert.IsFalse(ent.Contains(EntityProp.DrawDist));
        }

        [TestMethod]
        public void PropsRemove2()
        {
            Entity ent = EntInit(new Point(0, 0, 0));
            ent[EntityProp.DrawDist] = 10f;
            ent[EntityProp.Position] = new Point(1, 1, 1);
            ent.RemoveProp(EntityProp.DrawDist);
            Assert.IsTrue(ent.Contains(EntityProp.Position));
        }

        [TestMethod]
        [ExpectedException (typeof(EngineExceptions.PropertyTypeException))]
        public void PropSetType()
        {
            Entity ent = new(new CoordinateSystem(new Point(0, 0, 0),
                new VectorSpace(new Vector(1, 0, 0),
                                new Vector(0, 1, 0),
                                new Vector(0, 0, 1))));

            ent[EntityProp.DrawDist] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(EngineExceptions.NonExistantPropertyException))]
        public void PropRemoveNonExistant()
        {
            Entity ent = new(new CoordinateSystem(new Point(0, 0, 0),
                new VectorSpace(new Vector(1, 0, 0),
                                new Vector(0, 1, 0),
                                new Vector(0, 0, 1))));

            ent.RemoveProp(EntityProp.Position);
        }

    }
}
