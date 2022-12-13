using NUnit.Framework;
using System;
using System.Linq;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        string modelName = "Samsung note m - 5g + sgmp";
        int maximumBateryCharge = 1000;
        int shopCapacity = 5;
        Smartphone smartphone;
        Shop shop;

        [SetUp]
        public void Init()
        {
            shop = new Shop(shopCapacity);
            smartphone = new Smartphone(modelName, maximumBateryCharge);
        }

        public Smartphone[] smfsCreate(int count)
        {
            Smartphone[] sfs = new Smartphone[count];
            for (int i = 0; i < count; i++)
            {
                sfs[i] = new Smartphone($"Samsung-{i}", 500 + i);
            }
            return sfs;
        }



        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(1000)]
        public void TestConstructor(int c)
        {
            Shop shop = new Shop(c);
            Assert.AreEqual(c, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-5)]
        [TestCase(-1000)]
        public void TestCapacityIncorrect(int c)
        {
            Assert.Throws<ArgumentException>(() => new Shop(c));
        }

        [Test]
        public void TestAddCorrect()
        {
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void TestAddCorrectConsecuetive()
        {
            Smartphone[] sfs = smfsCreate(5);
            sfs.ToList().ForEach(s => shop.Add(s));
            Assert.AreEqual(5, shop.Count);
        }

        [Test]
        public void TestAddIncorrectTooMany()
        {
            Smartphone[] sfs = smfsCreate(5);
            sfs.ToList().ForEach(s => shop.Add(s));

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

         [Test]
        public void TestAddIncorrectSameName()
        {
            Smartphone[] sfs = smfsCreate(2);
            sfs.ToList().ForEach(s => shop.Add(s));
            Smartphone sf = new Smartphone($"Samsung-{1}", 500 + 1);
            Assert.Throws<InvalidOperationException>(() => shop.Add(sf));
        }

         [Test]
        public void TestAddIncorrectSameRef()
        {
            Smartphone[] sfs = smfsCreate(2);
            sfs.ToList().ForEach(s => shop.Add(s));

            Assert.Throws<InvalidOperationException>(() => shop.Add(sfs[0]));
        }

        [Test]
        public void TestRemoveCorrect()
        {
            Smartphone[] sfs = smfsCreate(5);
            sfs.ToList().ForEach(s => shop.Add(s));
            shop.Remove($"Samsung-{1}");
            Assert.AreEqual(4, shop.Count);

            shop.Remove($"Samsung-{2}");
            Assert.AreEqual(3, shop.Count);

        }

        [Test]
        public void TestRemoveIncorrect()
        {
            Smartphone[] sfs = smfsCreate(5);
            sfs.ToList().ForEach(s => shop.Add(s));
            Assert.Throws<InvalidOperationException> (()=>shop.Remove($"Samsung-{5}"));
        }

        [Test]
        public void TestRemoveIncorrectFromNothing()
        {
            
            Assert.Throws<InvalidOperationException> (()=>shop.Remove($"Samsung-{5}"));
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(1000)]
        public void TestTestPhoneCorrect(int usage)
        {
            shop.Add(smartphone);
            shop.TestPhone(modelName, usage);
            Assert.AreEqual(1000-usage, smartphone.CurrentBateryCharge);
        }

        [TestCase(1001)]
        [TestCase(1005)]
        [TestCase(1500)]
        public void TestTestPhoneIncorrect(int usage)
        {
            shop.Add(smartphone);
            
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(modelName, usage));
        }

        [Test]
        public void TestTestPhoneIncorrectII()
        {
            shop.Add(smartphone);
            smartphone.CurrentBateryCharge = 1;
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(modelName, 2));
        }

        [Test]
        public void TestTestPhoneIncorrectNotExistingName()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Not existing", 5));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(null, 5));
        }

        [Test]
        public void TestChargePhoneCorrect()
        {
            shop.Add(smartphone);
            shop.TestPhone(modelName, 50);
            shop.ChargePhone(smartphone.ModelName);
            Assert.AreEqual(1000, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestChargePhoneIncorrect()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Not existing"));
        }
        
        [Test]
        public void TestCount()
        {
            Smartphone[] sfs = smfsCreate(2);
            sfs.ToList().ForEach(s => shop.Add(s));

            Assert.AreEqual(2, shop.Count);

            shop.Remove($"Samsung-{1}");
            Assert.AreEqual(1, shop.Count);

            shop.Remove($"Samsung-{0}");
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void TestCapacity()
        {
            Shop s = new Shop(0);
            Assert.Throws<InvalidOperationException>(() => s.Add(smartphone));

        }
    }
}