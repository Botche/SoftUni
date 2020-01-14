using System;
using System.Linq;

namespace arrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] action = command
                    .Split()
                    .ToArray();
                int index = 0;
                if (action[0] == "exchange")
                {
                    index = int.Parse(action[1]);
                    if (index >= arr.Length || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        arr = Exchange(index, arr);
                    }
                }
                else if (action[0] == "max")
                {
                    string evenOrOdd = action[1];
                    if (evenOrOdd == "even")
                        PrintMaxEven(arr);
                    else
                        PrintMaxOdd(arr);
                }
                else if (action[0] == "min")
                {
                    string evenOrOdd = action[1];
                    if (evenOrOdd == "even")
                        PrintMinEven(arr);
                    else
                        PrintMinOdd(arr);
                }
                else if (action[0] == "first")
                {
                    int count = int.Parse(action[1]);
                    string evenOrOdd = action[2];
                    if (evenOrOdd == "even")
                        PrintFirstCountEvens(arr, count);
                    else
                        PrintFirstCountOdds(arr, count);
                }
                else if (action[0] == "last")
                {
                    int count = int.Parse(action[1]);
                    string evenOrOdd = action[2];
                    if (evenOrOdd == "even")
                        PrintLastCountEvens(arr, count);
                    else
                        PrintLastCountOdds(arr, count);
                }
                command = Console.ReadLine();
            }
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                    Console.Write(arr[i]);
                else
                    Console.Write(arr[i] + ", ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        private static void PrintLastCountEvens(int[] arr, int count)
        {
            if (count > arr.Length || count < 0)
                Console.WriteLine("Invalid count");
            else
            {
                int[] newArr = new int[count];
                int counter = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == 0)
                    {
                        newArr[counter] = arr[i];
                        counter++;
                    }
                    if (count == counter)
                        break;
                }
                if (counter == 0)
                    Console.WriteLine("[]");
                else
                {
                    Console.Write("[");
                    for (int i = counter - 1; i >= 0; i--)
                    {
                        if (i == 0)
                            Console.Write(newArr[i]);
                        else
                            Console.Write(newArr[i] + ", ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
            }

        }

        private static void PrintLastCountOdds(int[] arr, int count)
        {

            if (count > arr.Length)
                Console.WriteLine("Invalid count");
            else
            {
                int[] newArr = new int[count];
                int counter = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == 1)
                    {
                        newArr[counter] = arr[i];
                        counter++;
                    }
                    if (count  == counter)
                        break;
                }
                if (counter == 0)
                    Console.WriteLine("[]");
                else
                {
                    Console.Write("[");
                    for (int i = counter - 1; i >= 0; i--)
                    {
                        if (i == 0)
                            Console.Write(newArr[i]);
                        else
                            Console.Write(newArr[i] + ", ");
                    }
                    Console.Write("]");
                    Console.WriteLine();

                }
            }
        }

        private static void PrintFirstCountOdds(int[] arr, int count)
        {
            if (count > arr.Length || count < 0)
                Console.WriteLine("Invalid count");
            else
            {
                int[] newArr = new int[count+1];
                int counter = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 1)
                    {
                        newArr[counter] = arr[i];
                        counter++;
                    }
                    if (count == counter)
                        break;
                }
                if (counter == 0)
                    Console.WriteLine("[]");
                else
                {
                    Console.Write("[");
                    for (int i = 0; i < counter; i++)
                    {
                        if (i == counter - 1)
                            Console.Write(newArr[i]);
                        else
                            Console.Write(newArr[i] + ", ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
            }
        }

        private static void PrintFirstCountEvens(int[] arr, int count)
        {
            if (count > arr.Length || count < 0)
                Console.WriteLine("Invalid count");
            else
            {
                int[] newArr = new int[count];
                int counter = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0 )
                    {
                        newArr[counter] = arr[i];
                        counter++;
                    }
                    if (count == counter)
                        break;
                }
                if (counter==0)
                    Console.WriteLine("[]");
                else
                {
                    Console.Write("[");
                    for (int i = 0; i < counter; i++)
                    {
                        if (i == counter - 1)
                            Console.Write(newArr[i]);
                        else
                            Console.Write(newArr[i] + ", ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
            }

        }

        private static void PrintMinEven(int[] arr)
        {
            {
                int min = int.MaxValue;
                int rightestIndex = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (min >= arr[i] && arr[i] % 2 == 0)
                    {
                        min = arr[i];
                        rightestIndex = i;
                    }
                }
                if (min == int.MaxValue)
                    Console.WriteLine("No matches");
                else
                    Console.WriteLine(rightestIndex);
            }

        }

        private static void PrintMinOdd(int[] arr)
        {
            int min = int.MaxValue;
            int rightestIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min >= arr[i] && arr[i] % 2 == 1)
                {
                    min = arr[i];
                    rightestIndex = i;
                }
            }
            if (min == int.MaxValue)
                Console.WriteLine("No matches");
            else
                Console.WriteLine(rightestIndex);
        }

        private static void PrintMaxOdd(int[] arr)
        {
            int max = int.MinValue;
            int rightestIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max <= arr[i] && arr[i] % 2 == 1)
                {
                    max = arr[i];
                    rightestIndex = i;
                }
            }
            if (max == int.MinValue)
                Console.WriteLine("No matches");
            else
                Console.WriteLine(rightestIndex);
        }

        private static void PrintMaxEven(int[] arr)
        {
            int max = int.MinValue;
            int rightestIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max <= arr[i] && arr[i] % 2 == 0)
                {
                    max = arr[i];
                    rightestIndex = i;
                }
            }
            if (max == int.MinValue)
                Console.WriteLine("No matches");
            else
                Console.WriteLine(rightestIndex);
        }

        private static int[] Exchange(int index, int[] arr)
        {
            int[] newArr = new int[arr.Length];

            int count = 0;
            for (int i = index + 1; i < arr.Length; i++)
            {
                newArr[count++] = arr[i];
            }
            for (int i = 0; i <= index; i++)
            {
                newArr[count++] = arr[i];
            }

            arr = newArr;
            newArr = new int[arr.Length];
            return arr;

        }
    }
}
