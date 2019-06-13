using System;

namespace GenericBoxOfString
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            for (int i = 0; i < length; i++)
            {
                var input = Console.ReadLine();

                var box = new Box<string>(input);

                Console.WriteLine(box.ToString());
            }
        }
    }
}
