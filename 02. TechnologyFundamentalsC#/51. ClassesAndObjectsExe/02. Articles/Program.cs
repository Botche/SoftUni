using System;

namespace Articles
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] article = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());
            Article articleNew = new Article
            {
                Title = article[0],
                Contest = article[1],
                Author = article[2]
            };
            string[] data = new string[2];
            for (int i = 0; i < n; i++)
            {
                data = Console.ReadLine().Split(": ");
                switch (data[0])
                {
                    case "Edit":
                        articleNew.Contest = data[1];
                        break;
                    case "ChangeAuthor":
                        articleNew.Author = data[1];
                        break;
                    case "Rename":
                        articleNew.Title = data[1];
                        break;
                }
            }
            Console.WriteLine($"{articleNew.Title} - { articleNew.Contest}: {articleNew.Author}");
        }

        class Article
        {
            public string Title;
            public string Contest;
            public string Author;
        }
    }
}
