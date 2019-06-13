using System;

namespace GenericBoxOfInteger
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            for (int i = 0; i < length; i++)
            {
                var input = int.Parse(Console.ReadLine());

                var box = new Box<int>(input);

                Console.WriteLine(box.ToString());
            }
        }
    }
}
