namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private string bookName = "A Long name with Spaces - and Symbols..";
        private string author = "Tolkin & Co";

        private Book book;

        private string text = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content.";

        [SetUp]
        public void Init()
        {
            book = new Book(bookName, author);
        }



        [TestCase("A Long name with Spaces - and Symbols..", "Tolkin & Co")]
        [TestCase(" ", "  ")]
        public void Constructor(string bookName, string author)
        {
            Book book = new Book(bookName, author);
            Assert.AreEqual(bookName, book.BookName);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void fieldBookName(string name)
        {
            Assert.Throws< ArgumentException>(()=> new Book(name, author));
        }

        [TestCase("")]
        [TestCase(null)]
        public void fieldAuthor(string name)
        {
            Assert.Throws<ArgumentException>(() => new Book(bookName, name));
        }


        [Test]
        public void methodAddFootnote()
        {
            book.AddFootnote(1, text);
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void methodAddFootnoteInvalid()
        {
            book.AddFootnote(1, text);
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "some note"));
        }

        [Test]
        public void methodFindFootnote()
        {
            book.AddFootnote(1, text);
            string footNoteData = book.FindFootnote(1);
            Assert.AreEqual("Footnote #1: "+text, footNoteData);

        }

        [Test]
        public void methodFindFootnoteInvalid()
        {
            book.AddFootnote(1, text);
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(2));

        }

        [Test]
        public void methodAlterFootnote()
        {
            book.AddFootnote(1, text);
            book.AlterFootnote(1,"small note");
            Assert.AreEqual("Footnote #1: " + "small note", book.FindFootnote(1));

        }

        [Test]
        public void methodAlterFootnoteInvalid()
        {
            book.AddFootnote(1, text);
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(2,"small note"));

        }
    }
}