﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Food.Dessert
{
    public class Cake : Dessert
    {
        private const decimal CakePrice = 5m;

        private const double CakeCalories = 1000;

        private const double CakeGrams = 250;

        public Cake(string name)
            : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }
    }
}