using System;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string articleTitle = Console.ReadLine();
            string articleContent = Console.ReadLine();
            string comments = Console.ReadLine();

            //Header
            Console.WriteLine("<h1>");
            Console.WriteLine(articleTitle);
            Console.WriteLine("</h1>");

            //Article
            Console.WriteLine("<article>");
            Console.WriteLine(articleContent);
            Console.WriteLine("</article>");


            while (comments!="end of comments")
            {
                //Divs
                Console.WriteLine("<div>");
                Console.WriteLine(comments);
                Console.WriteLine("</div>");

                comments = Console.ReadLine();
            }
        }
    }
}
