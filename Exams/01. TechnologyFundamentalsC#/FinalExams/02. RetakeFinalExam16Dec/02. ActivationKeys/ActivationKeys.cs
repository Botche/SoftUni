using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("&");
            StringBuilder sb = new StringBuilder();
            Regex pattern = new Regex(@"^[A-Za-z0-9]+$");
            List<string> codes = new List<string>();

            int length = input.Length;
            foreach (var str in input)
            {
                int count = 0;
                bool match = pattern.IsMatch(str);
                if (str.Length == 16 && match == true)
                {
                    count = 0;
                    for (int i = 0; i < str.Length; i++)
                    {
                        char ch = str[i];
                        if (char.IsLetter(ch))
                        {
                            if (ch > 96)
                                ch = (char)(ch-32);
                            sb.Append(ch);
                        }
                        else if(char.IsDigit(ch))
                        {
                            ch = (char)(57 - ch + 48);
                            sb.Append(ch);
                        }
                        count++;
                        if(count==4 && i != str.Length - 1)
                        {
                            sb.Append("-");
                            count = 0;
                        }
                    }
                    codes.Add(sb.ToString());
                }
                else if (str.Length == 25 && match == true)
                {
                    count = 0;
                    for (int i = 0; i < str.Length; i++)
                    {
                        char ch = str[i];
                        if (char.IsLetter(ch))
                        {
                            if (ch > 96)
                                ch = (char)(ch - 32);
                            sb.Append(ch);
                        }
                        else if (char.IsDigit(ch))
                        {
                            ch = (char)(57 - ch + 48);
                            sb.Append(ch);
                        }
                        count++;
                        if (count == 5 && i!= str.Length-1)
                        {
                            sb.Append("-");
                            count = 0;
                        }
                    }
                    codes.Add(sb.ToString());
                }
                sb.Clear();
            }
            Console.WriteLine(string.Join(", ",codes));
        }
    }
}
