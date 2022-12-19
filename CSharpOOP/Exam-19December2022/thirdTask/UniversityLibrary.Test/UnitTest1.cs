namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class Tests
    {
        UniversityLibrary library;
        TextBook book;
        TextBook book2;
        TextBook bookSame;

        string title = "Ime s - tire & znaci.";
        string author = "Petko Nikolov";
        string category = "Science";
        string title2 = "a";
        string author2 = "b";
        string category2 = "c";


        [SetUp]
        public void Setup()
        {
            library = new UniversityLibrary();
            book = new TextBook(title, author, category);
            book2 = new TextBook(title2, author2, category2);
            bookSame = new TextBook(title, author, category);
        }

        [Test]
        public void Constructor()
        {
            UniversityLibrary libraryin = new UniversityLibrary();
            Assert.AreEqual(0, libraryin.Catalogue.Count);
            Assert.AreEqual(new List<TextBook>().GetType(), libraryin.Catalogue.GetType());
        }

        [Test]
        public void CatalogueProperty()
        {
            library.Catalogue.Add(book);
            Assert.IsTrue(library.Catalogue.Contains(book));

            Assert.AreEqual(0, book.InventoryNumber);
            Assert.AreEqual(1, library.Catalogue.Count);
        }

        [Test]
        public void CataloguePropertyII()
        {
            library.AddTextBookToLibrary(book);
            library.AddTextBookToLibrary(book2);
            Assert.IsTrue(library.Catalogue.FirstOrDefault(b => b.InventoryNumber == book.InventoryNumber) != null);
            Assert.IsTrue(library.Catalogue.FirstOrDefault(b => b.InventoryNumber == book2.InventoryNumber) != null);

            library.Catalogue.Remove(book);
            Assert.IsTrue(library.Catalogue.FirstOrDefault(b => b.InventoryNumber == book.InventoryNumber) == null);

        }

        [Test]
        public void AddTextBookToLibraryMethod()
        {
            string result = library.AddTextBookToLibrary(book);
            Assert.
                AreEqual($"Book: {title} - 1\r\nCategory: {category}\r\nAuthor: {author}", result);

            Assert.AreEqual(1, book.InventoryNumber);

            Assert.IsTrue(library.Catalogue.Contains(book));
            Assert.AreEqual(book.InventoryNumber, library.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1).InventoryNumber);

            Assert.AreEqual(1, book.InventoryNumber);

            string result2 = library.AddTextBookToLibrary(book2);
            Assert.
                AreEqual($"Book: {title2} - 2\r\nCategory: {category2}\r\nAuthor: {author2}", result2);

            Assert.AreEqual(2, library.Catalogue.Count);

            string result3 = library.AddTextBookToLibrary(bookSame);
            Assert.
                AreEqual($"Book: {title} - 3\r\nCategory: {category}\r\nAuthor: {author}", result3);

            Assert.AreEqual(3, library.Catalogue.Count);


        }

        [Test]
        public void AddTextBookToLibraryMethodEdge()
        {
            Assert.Throws<NullReferenceException>(()=> library.AddTextBookToLibrary(null));
        }

        [TestCase("","","")]
        [TestCase("a","","")]
        [TestCase("a","","c")]
        [TestCase("a","","c")]
        public void AddTextBookToLibraryMethodEdgeII(string a, string b, string c)
        {
            string result = library.AddTextBookToLibrary(new TextBook(a,b,c));
            Assert.
                AreEqual($"Book: {a} - 1\r\nCategory: {c}\r\nAuthor:{b}", result);
        }



        [Test]
        public void LoanTextBookMethod()
        {
            library.AddTextBookToLibrary(book);
            library.AddTextBookToLibrary(book2);
            library.AddTextBookToLibrary(bookSame);

            string reslut = library.LoanTextBook(book.InventoryNumber, "Stamat");
            Assert.AreEqual($"{book.Title} loaned to Stamat.", reslut);

            Assert.AreEqual("Stamat", book.Holder);



            string reslut2 = library.LoanTextBook(book2.InventoryNumber, "Pesho");
            Assert.AreEqual($"{book2.Title} loaned to Pesho.", reslut2);

            Assert.AreEqual("Stamat", book.Holder);



        }

        [Test]
        public void LoanTextBookMethodII()
        {
            library.AddTextBookToLibrary(book);
            library.AddTextBookToLibrary(book2);
            library.AddTextBookToLibrary(bookSame);

            string reslut = library.LoanTextBook(bookSame.InventoryNumber, "Stamat");
            Assert.AreEqual($"{bookSame.Title} loaned to Stamat.", reslut);

            Assert.AreEqual("Stamat", bookSame.Holder);

            string resultTwice = library.LoanTextBook(bookSame.InventoryNumber, "Pesho");
            Assert.AreEqual("Ime s - tire & znaci. loaned to Pesho.", resultTwice);

            Assert.AreEqual("Pesho", bookSame.Holder);


            string resultThird = library.LoanTextBook(book.InventoryNumber, "Pesho");
            Assert.AreEqual("Ime s - tire & znaci. loaned to Pesho.", resultThird);

            Assert.AreEqual("Pesho", bookSame.Holder);

        }

        [Test]
        public void LoanTextBookMethodInvalid()
        {
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(book.InventoryNumber, "Stamat");
            string result = library.LoanTextBook(book.InventoryNumber, "Stamat");

            Assert.AreEqual($"Stamat still hasn't returned {book.Title}!", result);

        }

        [Test]
        public void ReturnTextBookMethod()
        {
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(book.InventoryNumber, "Stamat");
            string result = library.ReturnTextBook(book.InventoryNumber);
            Assert.AreEqual($"{title} is returned to the library.", result);
            Assert.AreEqual("", book.Holder);
        }


        [Test]
        public void TextbookCtor()
        {
            TextBook tb = new TextBook(title, author, category);
            Assert.AreEqual(title, tb.Title);
            Assert.AreEqual(author, tb.Author);
            Assert.AreEqual(category, tb.Category);
        }

        [Test]
        public void TextbookToString()
        {
            TextBook tb = new TextBook(title2, author2, category2);

            Assert.AreEqual("Book: a - 0\r\nCategory: c\r\nAuthor: b", tb.ToString());
        }
    }
}