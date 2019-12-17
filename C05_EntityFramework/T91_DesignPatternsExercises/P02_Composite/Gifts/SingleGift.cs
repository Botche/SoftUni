﻿using System;

namespace P02_Composite.Gifts
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        {

        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");

            return price;
        }
    }
}
