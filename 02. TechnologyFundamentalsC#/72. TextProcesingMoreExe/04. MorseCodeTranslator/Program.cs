using System;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                string letter = words[i];
                if(letter == "|")
                {
                    sb.Append(" ");
                }
                else
                {
                    switch(letter)
                    {
                        case ".-":
                            sb.Append("A");
                            break;
                        case "-...":
                            sb.Append("B");
                            break;
                        case "-.-.":
                            sb.Append("C");
                            break;
                        case "-..":
                            sb.Append("D");
                            break;
                        case ".":
                            sb.Append("E");
                            break;
                        case "..-.":
                            sb.Append("F");
                            break;
                        case "--.":
                            sb.Append("G");
                            break;
                        case "....":
                            sb.Append("H");
                            break;
                        case "..":
                            sb.Append("I");
                            break;
                        case ".---":
                            sb.Append("J");
                            break;
                        case "-.-":
                            sb.Append("K");
                            break;
                        case ".-..":
                            sb.Append("L");
                            break;
                        case "--":
                            sb.Append("M");
                            break;
                        case "-.":
                            sb.Append("N");
                            break;
                        case "---":
                            sb.Append("O");
                            break;
                        case ".--.":
                            sb.Append("P");
                            break;
                        case "--.-":
                            sb.Append("Q");
                            break;
                        case ".-.":
                            sb.Append("R");
                            break;
                        case "...":
                            sb.Append("S");
                            break;
                        case "-":
                            sb.Append("T");
                            break;
                        case "..-":
                            sb.Append("U");
                            break;
                        case "...-":
                            sb.Append("V");
                            break;
                        case ".--":
                            sb.Append("W");
                            break;
                        case "-..-":
                            sb.Append("X");
                            break;
                        case "-.--":
                            sb.Append("Y");
                            break;
                        case "--..":
                            sb.Append("Z");
                            break;
                    }
                }
            }
            Console.WriteLine(sb);
        }
    }
}
