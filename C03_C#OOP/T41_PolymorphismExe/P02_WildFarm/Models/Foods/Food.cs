﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }

    }
}
