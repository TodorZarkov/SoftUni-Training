namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void Test_Constructor_Regular()
        {
            Warrior warrior = new Warrior("Stamat", 12, 36);
            Assert.AreEqual("Stamat", warrior.Name);
            Assert.AreEqual(12, warrior.Damage);
            Assert.AreEqual(36, warrior.HP);

            Warrior warriorEdge = new Warrior("Stamat", 1, 0);
            Assert.AreEqual("Stamat", warriorEdge.Name);
            Assert.AreEqual(1, warriorEdge.Damage, "edge 1");
            Assert.AreEqual(0, warriorEdge.HP, "edge 0");
        }

        [Test]
        public void Test_Constructor_Incorrect()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 12, 36));
            Assert.Throws<ArgumentException>(() => new Warrior("", 12, 36));
            Assert.Throws<ArgumentException>(() => new Warrior("   ", 12, 36));

            Assert.Throws<ArgumentException>(() => new Warrior("Stamat", 0, 36), "edge 0");
            Assert.Throws<ArgumentException>(() => new Warrior("Stamat", -5, 36));

            Assert.Throws<ArgumentException>(() => new Warrior("Stamat", 12, -1));
        }

        [Test]
        public void Test_Attac_Regular()
        {
            Warrior stamat = new Warrior("Stamat", 12, 36);
            Warrior pencho = new Warrior("Pencho", 10, 32);
            stamat.Attack(pencho);
            Assert.AreEqual(26, stamat.HP,"stamat hp regular 36-10");
            Assert.AreEqual(12, stamat.Damage, "stamat damage regular remains 12");
            Assert.AreEqual(20, pencho.HP, "pencho hp regular 32-12");
            Assert.AreEqual(10, pencho.Damage, "pencho damage regular remains 10");
        }
        [Test]
        public void Test_Attac_Edge_0()
        {
            Warrior stamat = new Warrior("Stamat", 32, 36);
            Warrior pencho = new Warrior("Pencho", 10, 32);
            stamat.Attack(pencho);
            Assert.AreEqual(26, stamat.HP,"stamat hp regular 36-10");
            Assert.AreEqual(32, stamat.Damage, "stamat damage regular remains 32");
            Assert.AreEqual(0, pencho.HP, "pencho hp regular 32-32");
            Assert.AreEqual(10, pencho.Damage, "pencho damage regular remains 10");
        }
        [Test]
        public void Test_Attac_Edge_Negative()
        {
            Warrior stamat = new Warrior("Stamat", 40, 36);
            Warrior pencho = new Warrior("Pencho", 10, 32);
            stamat.Attack(pencho);
            Assert.AreEqual(26, stamat.HP,"stamat hp regular 36-10");
            Assert.AreEqual(40, stamat.Damage, "stamat damage regular remains 40");
            Assert.AreEqual(0, pencho.HP, "pencho hp regular 32-40");
            Assert.AreEqual(10, pencho.Damage, "pencho damage regular remains 10");
        }
        [Test]
        public void Test_Attac_Edge_ThisHP_equals_Enemy_dmg()
        {
            Warrior stamat = new Warrior("Stamat", 40, 36);
            Warrior pencho = new Warrior("Pencho", 36, 32);
            stamat.Attack(pencho);
            Assert.AreEqual(0, stamat.HP,"stamat hp regular 36-36");
            Assert.AreEqual(40, stamat.Damage, "stamat damage regular remains 40");
            Assert.AreEqual(0, pencho.HP, "pencho hp regular 32-40");
            Assert.AreEqual(36, pencho.Damage, "pencho damage regular remains 36");
        }
        [Test]
        public void Test_Attac_Edge_ThisHP_equals_Enemy_dmg2()
        {
            Warrior stamat = new Warrior("Stamat", 40, 36);
            Warrior pencho = new Warrior("Pencho", 36, 45);
            stamat.Attack(pencho);
            Assert.AreEqual(0, stamat.HP,"stamat hp regular 36-36");
            Assert.AreEqual(40, stamat.Damage, "stamat damage regular remains 40");
            Assert.AreEqual(5, pencho.HP, "pencho hp regular 45-40");
            Assert.AreEqual(36, pencho.Damage, "pencho damage regular remains 36");
        }
        [Test]
        public void Test_Attac_Edge_All_Equal()
        {
            Warrior stamat = new Warrior("Stamat", 40, 40);
            Warrior pencho = new Warrior("Pencho", 40, 40);
            stamat.Attack(pencho);
            Assert.AreEqual(0, stamat.HP,"stamat hp regular 40-40");
            Assert.AreEqual(40, stamat.Damage, "stamat damage regular remains 40");
            Assert.AreEqual(0, pencho.HP, "pencho hp regular 40-40");
            Assert.AreEqual(40, pencho.Damage, "pencho damage regular remains 36");
        }
        [Test]
        public void Test_Attac_Edge_Same()
        {
            Warrior stamat = new Warrior("Stamat", 36, 40);
            stamat.Attack(stamat);
            Assert.AreEqual(0, stamat.HP,"stamat hp regular 40-40");
            Assert.AreEqual(36, stamat.Damage, "stamat damage regular remains 40");
        }

        [Test]
        public void Test_Attac_Incorrect_min_Attac_HP()
        {
            Warrior stamat = new Warrior("Stamat", 40, 25);
            Warrior pencho = new Warrior("Pencho", 10, 32);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }
        [Test]
        public void Test_Attac_Incorrect_min_Attac_HP_edge_0()
        {
            Warrior stamat = new Warrior("Stamat", 40, 30);
            Warrior pencho = new Warrior("Pencho", 10, 32);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }
        [Test]
        public void Test_Attac_Incorrect_min_Attac_Enemy_HP()
        {
            Warrior stamat = new Warrior("Stamat", 40, 36);
            Warrior pencho = new Warrior("Pencho", 10, 20);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }
        [Test]
        public void Test_Attac_Incorrect_min_Attac_Enemy_HP_edge_0()
        {
            Warrior stamat = new Warrior("Stamat", 40, 36);
            Warrior pencho = new Warrior("Pencho", 10, 30);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }
         [Test]
        public void Test_Attac_Incorrect_Less_Hp_than_Enemy_dmg()
        {
            Warrior stamat = new Warrior("Stamat", 40, 36);
            Warrior pencho = new Warrior("Pencho", 37, 30);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }
        [Test]
        public void Test_Attac_Incorrect_Less_Hp_than_Enemy_dmg_normal()
        {
            Warrior stamat = new Warrior("Stamat", 40, 36);
            Warrior pencho = new Warrior("Pencho", 50, 35);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }
         [Test]
        public void Test_Attac_Incorrect_Less_Hp_than_30_both()
        {
            Warrior stamat = new Warrior("Stamat", 40, 28);
            Warrior pencho = new Warrior("Pencho", 37, 28);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }
         [Test]
        public void Test_Attac_Incorrect_Less_Hp_than_30_edge_0()
        {
            Warrior stamat = new Warrior("Stamat", 40, 0);
            Warrior pencho = new Warrior("Pencho", 37, 28);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }
         [TestCase(30)]
         [TestCase(15)]
         [TestCase(0)]
        public void Test_Attac_Incorrect_Less_Hp_than_30_edge_0_attackee(int w2Hp)
        {
            Warrior stamat = new Warrior("Stamat", 40, 36);
            Warrior pencho = new Warrior("Pencho", 37, w2Hp);
            Assert.Throws<InvalidOperationException>(()=> stamat.Attack(pencho));
        }

    }
}