namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using Moq;
    using static System.Net.Mime.MediaTypeNames;
    using System.Xml.Linq;
    using System.Reflection;

    [TestFixture]
    public class ArenaTests
    {
        Warrior stamat;
        Warrior pencho;
        Warrior sameNameStamat;
        Warrior goshko;

        Arena arena;

        [SetUp]
        public void Init()
        {
            stamat = new Warrior("Stamat", 12, 36);
            sameNameStamat = new Warrior("Stamat", 12, 36);
            pencho = new Warrior("Pencho", 10, 32);
            goshko = new Warrior("Goshko", 10, 32);

            arena = new Arena();
        }


        [Test]
        public void Test_Constructor()
        {
            Arena arena0 = new Arena();
            Assert.AreEqual(0, arena0.Count);
            Assert.AreEqual(0, arena0.Warriors.Count);
        }

        [Test]
        public void Test_Enroll_Regular()
        {
            arena.Enroll(stamat);
            Assert.AreEqual(1, arena.Count,"regular");
            Assert.AreEqual("Stamat", arena.Warriors.ToArray()[0].Name,"regular name");
            arena.Enroll(pencho);
            Assert.AreEqual(2, arena.Count,"consecutive");
            Assert.AreEqual("Pencho", arena.Warriors.ToArray()[1].Name,"consecutive name");

            Assert.AreEqual(2, arena.Warriors.Count);

        }
        [Test]
        public void Test_Enroll_Regular2()
        {
            arena.Enroll(stamat);
            bool isIn = arena.Warriors.Contains(stamat);

            Assert.IsTrue(isIn);

        }

        [Test]
        public void Test_Enroll_Regular_Incorrect()
        {
            
            arena.Enroll(stamat);
            Assert.AreEqual(1, arena.Count,"regular");
            Assert.AreEqual("Stamat", arena.Warriors.ToArray()[0].Name,"regular name");
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(stamat));

        }

        [Test]
        public void Test_Enroll_Regular_Incorrect_Edge()
        {
            
            arena.Enroll(stamat);
            Assert.AreEqual(1, arena.Count,"regular");
            Assert.AreEqual("Stamat", arena.Warriors.ToArray()[0].Name,"regular name");
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(sameNameStamat));

        }

        [Test]
        public void Test_Fight_Regular()
        {
            arena.Enroll(stamat);
            arena.Enroll(pencho);
            arena.Enroll(goshko);
            arena.Fight("Stamat", "Pencho");
            Assert.AreEqual(26, stamat.HP, "stamat hp regular 36-10");
            Assert.AreEqual(12, stamat.Damage, "stamat damage regular remains 12");
            Assert.AreEqual(20, pencho.HP, "pencho hp regular 32-12");
            Assert.AreEqual(10, pencho.Damage, "pencho damage regular remains 10");
        }
        

        [Test]
        public void Test_Fight_Incorrect_Fighter()
        {
            arena.Enroll(stamat);
            arena.Enroll(pencho);
            arena.Enroll(goshko);
            Assert.Throws<InvalidOperationException>(()=> arena.Fight("George", "Pencho"));
        }
        [Test]
        public void Test_Fight_Incorrect_Fightee()
        {
            arena.Enroll(stamat);
            arena.Enroll(pencho);
            arena.Enroll(goshko);
            Assert.Throws<InvalidOperationException>(()=> arena.Fight("Stamat", "Peter"));
        }
        [Test]
        public void Test_Fight_Incorrect_Both()
        {
            arena.Enroll(stamat);
            arena.Enroll(pencho);
            arena.Enroll(goshko);
            Assert.Throws<InvalidOperationException>(()=> arena.Fight("George", "Peter"));
        }

        [Test]
        public void Test_Warriors_is_Readonly()
        {
            arena.Enroll(stamat);
            arena.Enroll(pencho);
            var warriors = arena.Warriors;
            warriors.Append(goshko);
            Assert.AreEqual(2, arena.Warriors.Count);
        }

        [Test]
        public void Test_Count_with_no_entries()
        {
            Assert.AreEqual(0, arena.Count);
        }
    }
}
