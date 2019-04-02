using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ");

            for (int i = 0; i < usernames.Length; i++)
            {
                string username = usernames[i];
                bool isValid = false;

                if (username.Length>=3 && username.Length<=16)
                {
                    for (int j = 0; j < username.Length; j++)
                    {
                        char ch = username[j];
                        if(char.IsLetterOrDigit(ch)
                            || ch=='-'
                            || ch=='_')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if(isValid)
                    Console.WriteLine(username);
            }
        }
    }
}
