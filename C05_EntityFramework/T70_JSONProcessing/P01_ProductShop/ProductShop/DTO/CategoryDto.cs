﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTO
{
    class CategoryDto
    {
        public string Category { get; set; }

        public int ProductsCount { get; set; }

        public string AveragePrice { get; set; }

        public string TotalRevenue { get; set; }
    }
}
