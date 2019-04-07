using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            Regex pattern = new Regex(@"^(([A-Z][a-z' ]+):([A-Z ]+))");

            while (input != "end")
            {
                bool match = pattern.IsMatch(input);
                if (match == true)
                {
                    string[] data = input.Split(":");
                    StringBuilder sb = new StringBuilder();
                    string artist = data[0];
                    string album = data[1];

                    int keyToEncrypt = artist.Length;
                    for (int i = 0; i < artist.Length; i++)
                    {
                        char ch = artist[i];
                        if (ch == ' ' || ch == '\'')
                        {
                            sb.Append(ch);
                        }
                        else if (ch > 96)
                        {
                            if (ch + keyToEncrypt > 122)
                            {
                                ch = (char)(ch + keyToEncrypt - 122 + 96);
                                sb.Append(ch);
                            }
                            else
                            {
                                ch = (char)(ch + keyToEncrypt);
                                sb.Append(ch);
                            }
                        }
                        else
                        {
                            if (ch + keyToEncrypt > 90)
                            {
                                ch = (char)(ch + keyToEncrypt - 90 + 64);
                                sb.Append(ch);
                            }
                            else
                            {
                                ch = (char)(ch + keyToEncrypt);
                                sb.Append(ch);
                            }
                        }
                    }
                    sb.Append('@');
                    for (int i = 0; i < album.Length; i++)
                    {
                        char ch = album[i];
                        if (ch == ' ' || ch == '\'')
                        {
                            sb.Append(ch);
                        }
                        else if (ch + keyToEncrypt > 90)
                        {
                            ch = (char)(ch + keyToEncrypt - 90 + 64);
                            sb.Append(ch);
                        }
                        else
                        {
                            ch = (char)(ch + keyToEncrypt);
                            sb.Append(ch);
                        }
                    }
                    Console.WriteLine($"Successful encryption: {sb}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
