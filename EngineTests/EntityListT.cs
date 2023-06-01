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
        void Inverse(Entity ent)
        {
            ent[EntityProp.Direction] = -1 * (Vector)ent[EntityProp.Direction];
        }

        [TestMethod]
        public void AddRemoveTest()
        {
            EntityList entList = new();
            List<Entity> ents = new();

            for (int i = 0; i < 10; i++)
            {
                Entity ent = new(new CoordinateSystem(new Point(0, 0, 0),
                new VectorSpace(new Vector(1, 0, 0),
                                new Vector(0, 1, 0),
                                new Vector(0, 0, 1))));

                ent[EntityProp.Direction] = new Vector(i + 1, i + 2, i + 3);

                entList.Add(ent);
                ents.Add(ent);
            }

            foreach (Entity ent in ents)
                Assert.IsTrue(entList.Contains(ent.Identifier));


            entList.Remove(ents.First());

            Assert.IsFalse(entList.Contains(ents.First().Identifier));
        }

        [TestMethod]

        public void GetTest()
        {
            EntityList entList = new();
            List<Entity> ents = new();

            for (int i = 0; i < 10; i++)
            {
                Entity ent = new(new CoordinateSystem(new Point(0, 0, 0),
                new VectorSpace(new Vector(1, 0, 0),
                                new Vector(0, 1, 0),
                                new Vector(0, 0, 1))));

                ent[EntityProp.Direction] = new Vector(i + 1, i + 2, i + 3);

                entList.Add(ent);
                ents.Add(ent);
            }

            foreach (Entity ent in ents)
                if (entList.Get(ent.Identifier) != ent)
                    Assert.Fail();
        }

        [TestMethod]
        public void ExecTest()
        {
            EntityList entList = new();
            List<Entity> ents = new();

            for (int i = 0; i < 10; i++)
            {
                 Entity ent = new(new CoordinateSystem(new Point(0, 0, 0),
                new VectorSpace(new Vector(1, 0, 0),
                                new Vector(0, 1, 0),
                                new Vector(0, 0, 1))));

                ent[EntityProp.Direction] = new Vector(i + 1, i + 2, i + 3);

                entList.Add(ent);
                ents.Add(ent);
            }

            entList.Exec(Inverse);

            for (int i = 0;i < 10;i++)
            {
                MathTests.MatrixT.TableAssert(new Vector(-(i + 1), -(i + 2), -(i + 3)),
                    (Vector)ents[i][EntityProp.Direction]);
            }
        }
    }
}
