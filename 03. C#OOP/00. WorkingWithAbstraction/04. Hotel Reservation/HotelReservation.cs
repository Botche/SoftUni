using System;

namespace HotelReservation
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];
            PriceCalculator.Season season1 = new PriceCalculator.Season();
            switch (season)
            {
                case "Spring":
                    season1 = PriceCalculator.Season.Spring;
                    break;
                case "Summer":
                    season1 = PriceCalculator.Season.Summer;
                    break;
                case "Autumn":
                    season1 = PriceCalculator.Season.Autumn;
                    break;
                case "Winter":
                    season1 = PriceCalculator.Season.Winter;
                    break;
                default:
                    break;
            }
            PriceCalculator.TypeDiscount typeDiscount = PriceCalculator.TypeDiscount.None;
            if (input.Length==4)
            {
                string typeDisc = input[3];
                switch (typeDisc)
                {
                    case "VIP":
                        typeDiscount = PriceCalculator.TypeDiscount.Vip;
                        break;
                    case "SecondVisit":
                        typeDiscount = PriceCalculator.TypeDiscount.SecondVisit;
                        break;
                    default:
                        typeDiscount = PriceCalculator.TypeDiscount.None;
                        break;
                }
            }
            Console.WriteLine($"{PriceCalculator.CalculatePrice(pricePerDay, numberOfDays, season1, typeDiscount):f2}");
        }
    }
}
