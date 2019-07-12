using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var customStack = new StackOfStrings();

            Console.WriteLine(customStack.IsEmpty());

            var st = new Stack<string>();

            st.Push("Pesho0");
            st.Push("Pesho1");
            st.Push("Pesho2");
            st.Push("Pesho3");

            customStack.AddRange(st);

            Console.WriteLine(customStack.IsEmpty());
            foreach (var str in customStack)
            {
                Console.WriteLine(str);
            }

        }
    }
}
