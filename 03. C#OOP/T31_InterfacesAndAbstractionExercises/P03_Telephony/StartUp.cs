using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var smartPhone = new Smartphone();

            var phoneNumbers = Console.ReadLine().Split();

            var webSites = Console.ReadLine().Split();

            foreach (var phoneNumber in phoneNumbers)
            {
                Regex pattern = new Regex(@"^\d+$");
                if (pattern.IsMatch(phoneNumber))
                {
                    Console.WriteLine(smartPhone.Call(phoneNumber));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var webSite in webSites)
            {
                Regex pattern = new Regex(@"\d");
                if (pattern.IsMatch(webSite))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine(smartPhone.Browse(webSite));
                }
            }
        }
    }
}
