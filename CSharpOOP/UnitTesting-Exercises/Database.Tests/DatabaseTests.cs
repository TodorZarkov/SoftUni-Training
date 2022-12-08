namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        int[] correctData = { 1, 2, 3, 4, 5, 6 };
        int[] incorrectData = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        int[] emptyData = new int[0];
        int[] edge16 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        Database database;

        [SetUp]
        public void Init()
        {
            database = new Database(emptyData);
        }
        

        [Test]
        public void Test_Constructor_With_Correct_Data()
        {
            Database db = new Database(correctData);
            Assert.AreEqual(correctData, db.Fetch());
            Assert.AreEqual(correctData.Length, db.Fetch().Length);
        }

        [Test]
        public void Test_Constructor_With_Incorrect_Data()
        {
            Assert.Throws<InvalidOperationException>(()=>new Database(incorrectData));
        }
        
        [Test]
        public void Test_Constructor_With_Edge_Empty()
        {
            Database db = new Database(emptyData) ;
            Assert.AreEqual(0, db.Fetch().Length);
            Assert.AreEqual(emptyData, db.Fetch());
        }
        [Test]
        public void Test_Constructor_With_Edge_16()
        {
            Database db = new Database(edge16) ;
            Assert.AreEqual(edge16[8], db.Fetch()[8]);
            Assert.AreEqual(edge16, db.Fetch());
        }

        [Test]
        public void Test_Add_And_Fetch()
        {
            database.Add(555);
            Assert.AreEqual(555, database.Fetch()[0]);
        }
        
        [Test]
        public void Test_Add_With_Incorrect()
        {
            var dbEdge = new Database(edge16);
            Assert.Throws<InvalidOperationException>(() => dbEdge.Add(555));
        }
        [Test]
        public void Test_Remove_With_Correct()
        {
            var dbEdge = new Database(edge16);
            dbEdge.Remove();
            Assert.AreEqual(edge16[14], dbEdge.Fetch()[14]);
        }

        [Test]
        public void Test_Remove_With_Incorrect()
        {
            var dbEdge = new Database(emptyData );
            Assert.Throws<InvalidOperationException>(() => dbEdge.Remove());
        }
        [Test]
        public void Test_Remove_With_Incorrect_Consecutive()
        {
            var dbEdge = new Database(new int[2] {1,3});
            dbEdge.Remove();
            dbEdge.Remove();
            Assert.Throws<InvalidOperationException>(() => dbEdge.Remove());
        }

        [Test]
        public void Test_Fetch_Only()
        {
            var dbEdge = new Database(correctData);
            Assert.AreEqual(correctData.Length, dbEdge.Fetch().Length);
            Assert.AreEqual(correctData[3], dbEdge.Fetch()[3]);
            Assert.AreEqual(correctData, dbEdge.Fetch());
            Assert.AreEqual(correctData.Length, dbEdge.Count);
        }
    }
}
