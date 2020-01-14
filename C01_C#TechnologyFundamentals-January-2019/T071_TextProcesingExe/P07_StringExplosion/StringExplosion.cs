using System;
using System.Text;

namespace StringExplocion
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int explosion = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '>')
                {
                    explosion += str[i + 1] - 48;
                    sb.Append(str[i]);
                    for (int j = i + 1; j <= i + explosion; j++)
                    {
                        if (str[j] == '>')
                        {
                            sb.Append(str[j]);
                            explosion += str[j + 1] - 48 + 1;
                            j++;
                            if (j == str.Length - 1)
                                break;
                        }
                        if (j == str.Length - 1)
                            break;
                    }
                    if (i + explosion >= str.Length - 1)
                        break;
                    else
                        i += explosion;
                }
                else
                {
                    sb.Append(str[i]);
                }
                explosion = 0;
            }
            Console.WriteLine(sb);
        }
    }
}
