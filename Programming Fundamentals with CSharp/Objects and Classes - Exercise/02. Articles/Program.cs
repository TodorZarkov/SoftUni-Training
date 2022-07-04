using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(", ").ToArray();
            Article article = new Article(line[0], line[1], line[2]);
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(": ", 2).ToArray();
                if (command[0] == "Edit")
                    article.Edit(command[1]);
                else if (command[0] == "ChangeAuthor")
                    article.ChangeAuthor(command[1]);
                else if (command[0] == "Rename")
                    article.Rename(command[1]);
            }
            Console.WriteLine(article);
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        private string Title { get; set; }
        private string Content { get; set; }
        private string Author { get; set; }
        public void Edit(string newContent)
        {
            this.Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }
        override public string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
