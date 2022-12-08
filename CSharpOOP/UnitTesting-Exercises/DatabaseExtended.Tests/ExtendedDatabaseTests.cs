namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        Person stamat;
        Person stamatDuplicatedUn;
        Person stamatDuplicatedId;
        Person peshko;
        Person emptich;
        Database db0;
        Database db2;
        Database db3;
        Database db15;
        Database db16;
        private Person[] CreatePersons(int quantity)
        {
            Person[] result = new Person[quantity];
            for (int i = 0; i < quantity; i++)
            {
                Person person = new Person(i, $"Stamat{i}");
                result[i] = person;
            }
            return result;
        }


        [SetUp]
        public void Init()
        {
            //Person person1 = new Person(1, "Pesho");
            //Person person2 = new Person(2, "Gosho");
            //Person person3 = new Person(3, "Stmat");
            //Person[] persons = new Person[3] { person1, person2, person3 };

            db0 = new Database(CreatePersons(0));
            db2 = new Database(CreatePersons(2));
            db3 = new Database(CreatePersons(3));
            db15 = new Database(CreatePersons(15));
            db16 = new Database(CreatePersons(16));

            stamat = new Person(555, "Stamat");
            stamatDuplicatedUn = new Person(444, "Stamat");
            stamatDuplicatedId = new Person(555, "StamatAnother");

            peshko = new Person(666, "Peshko");

            emptich = new Person(888, "");
        }


        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(5, new Database(CreatePersons(5)).Count, "normal");
            Assert.AreEqual(0, new Database(CreatePersons(0)).Count, "edge1");
            Assert.AreEqual(16, new Database(CreatePersons(16)).Count, "edge2");
            Assert.Throws<ArgumentException>(() => new Database(CreatePersons(17)), "incorrect");
        }

        [Test]
        public void Test_Add_Regular()
        {
            db3.Add(stamat);
            Assert.AreEqual(4, db3.Count, "regular");
            db3.Add(peshko);
            Assert.AreEqual(5, db3.Count, "consecutive");
        }

        [Test]
        public void Test_Add_Edge()
        {
            db15.Add(stamat);
            Assert.AreEqual(16, db15.Count);
            db0.Add(peshko);
            Assert.AreEqual(1, db0.Count);
            db0.Add(emptich);
            Assert.AreEqual(2, db0.Count, "added empty string un");
        }

        [Test]
        public void Test_Add_Incorrect()
        {
            Assert.Throws<InvalidOperationException>(() => db16.Add(peshko));
            db3.Add(stamat);
            Assert.Throws<InvalidOperationException>(() => db3.Add(stamatDuplicatedId));
            db2.Add(stamat);
            Assert.Throws<InvalidOperationException>(() => db2.Add(stamatDuplicatedUn));
        }

        [Test]
        public void Test_Remove_Regular()
        {
            db3.Remove();
            Assert.AreEqual(2, db3.Count, "regular");
            db3.Remove();
            Assert.AreEqual(1, db3.Count, "consecutive");
        }

        [Test]
        public void Test_Remove_Edge()
        {
            db2.Remove();
            db2.Remove();
            Assert.AreEqual(0, db2.Count);

            db16.Remove();
            Assert.AreEqual(15, db16.Count);
        }

        [Test]
        public void Test_Remove_Incorrect()
        {
            Assert.Throws<InvalidOperationException>(() => db0.Remove());
        }

        [Test]
        public void Test_FindByUsername_Regular_And()
        {
            Person person = db15.FindByUsername("Stamat5");
            Assert.AreEqual("Stamat5", person.UserName);
            Assert.AreEqual(5, person.Id);

        }

        [Test]
        public void Test_FindByUsername_Incorrect()
        {
            Assert.Throws<InvalidOperationException>(() => db15.FindByUsername("Stamat16"), "regular not found");
            Assert.Throws<InvalidOperationException>(() => db0.FindByUsername("Stamat16"), "edge not found");
            Assert.Throws<InvalidOperationException>(() => db16.FindByUsername("stamat5"), "caseSensitive not found");

            Assert.Throws<ArgumentNullException>(() => db15.FindByUsername(""), "null case");
        }

        [Test]
        public void Test_FindById_Regular()
        {
            Person person = db15.FindById(8);
            Assert.AreEqual(8, person.Id);
            Assert.AreEqual("Stamat8", person.UserName);
        }

        [Test]
        public void Test_FindById_Incorrect()
        {
            Assert.Throws<InvalidOperationException>(()=>db15.FindById(16));
            Assert.Throws<ArgumentOutOfRangeException>(()=>db15.FindById(-1));
        }
    }
}