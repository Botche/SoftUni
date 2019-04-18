using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0;  i < n;  i++)
            {
                string[] data = Console.ReadLine().Split(", " );
                Article article = new Article
                {
                    Title = data[0]
                    ,
                    Content = data[1]
                    ,
                    Author = data[2]
                };
                articles.Add(article);
            }
            string sort = Console.ReadLine();
            List<Article> sortedOne = new List<Article>();
            switch(sort)
            {
                case "title":
                    sortedOne = articles.OrderBy(x => x.Title).ToList();
                    break;
                case "content":
                    sortedOne = articles.OrderBy(x => x.Content).ToList();
                    break;
                case "author":
                    sortedOne = articles.OrderBy(x => x.Author).ToList();
                    break;
            }
            foreach (var item in sortedOne)
            {
                Console.WriteLine($"{item.Title} - {item.Content}: {item.Author}");
            }
        }
        
        class Article
        {
            public string Title;
            public string Content;
            public string Author;
        }
    }
}
