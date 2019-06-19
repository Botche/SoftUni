using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var doubleCustom= new CustomDoublyLinkedList<string>();

            doubleCustom.AddFirst("asd");
            doubleCustom.AddFirst("asd1");
            doubleCustom.AddFirst("asd2");
            doubleCustom.AddFirst("asd3");
            doubleCustom.AddFirst("asd4");

            foreach (var item in doubleCustom)
            {
                Console.WriteLine(item);
            }
        }
    }
}
