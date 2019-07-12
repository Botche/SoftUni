using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int n = numbers.Count;
            for (int i = 0; i < n/2; i++)
            {
                numbers[i] = numbers[i] + numbers[numbers.Count -1];
                numbers.RemoveAt(numbers.Count -1 );
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
