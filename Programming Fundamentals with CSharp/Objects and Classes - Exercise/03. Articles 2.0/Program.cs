using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine().Split(", ").ToArray();
                Article article = new Article(line[0], line[1], line[2]);
                articles.Add(article);
            }
            foreach (Article article  in articles)
            {
                Console.WriteLine(article);
            }
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
        
        override public string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}