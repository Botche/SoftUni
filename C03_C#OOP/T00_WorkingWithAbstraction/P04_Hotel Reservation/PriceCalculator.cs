using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay,int numberOfDays,Season season,TypeDiscount discount)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;

            decimal priceBeforeDiscount = numberOfDays * pricePerDay * multiplier;

            decimal discountedAmount = priceBeforeDiscount * discountMultiplier;

            decimal finalSum = priceBeforeDiscount - discountedAmount;

            return finalSum;
        }
        public enum Season
        {
            Spring=2,
            Summer=4,
            Autumn=1,
            Winter=3
        }
        public enum TypeDiscount
        {
            None,
            SecondVisit = 10,
            Vip = 20
        }
    }
}
