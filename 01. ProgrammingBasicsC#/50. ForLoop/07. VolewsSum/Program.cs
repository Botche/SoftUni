using System;

namespace volewsSum
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            int sum = 0;
            for (var i= 0;i<a.Length;i++)
            {
                if (a[i] == 'a')
                    sum += 1;
                else if (a[i] == 'e')
                    sum += 2;
                else if (a[i] == 'i')
                    sum += 3;
                else if (a[i] == 'o')
                    sum += 4;
                else if (a[i] == 'u')
                    sum += 5;
            }
            Console.WriteLine(sum);
        }
    }
}
