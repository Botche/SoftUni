using System;

namespace metrics
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            string b = Console.ReadLine();
            string c = Console.ReadLine();
            if(b=="m")
            {
                if(c == "mm")
                {
                    a *= 1000;
                }
                if (c == "cm")
                {
                    a *= 100;
                }
                if (c == "mi")
                {
                    a *= 0.000621371192;
                }
                if (c == "in")
                {
                    a *= 39.3700787;
                }
                if (c == "km")
                {
                    a *= 0.001;
                }
                if (c == "ft")
                {
                    a *= 3.2808399;
                }
                if (c == "yd")
                {
                    a *= 1.0936133;
                }
            }
            if (b == "mm")
            {
                a /= 1000;
                if (c == "mm")
                {
                    a *= 1000;
                }
                if (c == "cm")
                {
                    a *= 100;
                }
                if (c == "mi")
                {
                    a *= 0.000621371192;
                }
                if (c == "in")
                {
                    a *= 39.3700787;
                }
                if (c == "km")
                {
                    a *= 0.001;
                }
                if (c == "ft")
                {
                    a *= 3.2808399;
                }
                if (c == "yd")
                {
                    a *= 1.0936133;
                }
            }
            if (b == "cm")
            {
                a /= 100;
                if (c == "mm")
                {
                    a *= 1000;
                }
                if (c == "cm")
                {
                    a *= 100;
                }
                if (c == "mi")
                {
                    a *= 0.000621371192;
                }
                if (c == "in")
                {
                    a *= 39.3700787;
                }
                if (c == "km")
                {
                    a *= 0.001;
                }
                if (c == "ft")
                {
                    a *= 3.2808399;
                }
                if (c == "yd")
                {
                    a *= 1.0936133;
                }
            }
            if (b == "mi")
            {
                a /= 0.000621371192 ;
                if (c == "mm")
                {
                    a *= 1000;
                }
                if (c == "cm")
                {
                    a *= 100;
                }
                if (c == "mi")
                {
                    a *= 0.000621371192;
                }
                if (c == "in")
                {
                    a *= 39.3700787;
                }
                if (c == "km")
                {
                    a *= 0.001;
                }
                if (c == "ft")
                {
                    a *= 3.2808399;
                }
                if (c == "yd")
                {
                    a *= 1.0936133;
                }
            }
            if (b == "in")
            {
                a /= 39.3700787;
                if (c == "mm")
                {
                    a *= 1000;
                }
                if (c == "cm")
                {
                    a *= 100;
                }
                if (c == "mi")
                {
                    a *= 0.000621371192;
                }
                if (c == "in")
                {
                    a *= 39.3700787;
                }
                if (c == "km")
                {
                    a *= 0.001;
                }
                if (c == "ft")
                {
                    a *= 3.2808399;
                }
                if (c == "yd")
                {
                    a *= 1.0936133;
                }
            }
            if (b == "km")
            {
                a /= 0.001;
                if (c == "mm")
                {
                    a *= 1000;
                }
                if (c == "cm")
                {
                    a *= 100;
                }
                if (c == "mi")
                {
                    a *= 0.000621371192;
                }
                if (c == "in")
                {
                    a *= 39.3700787;
                }
                if (c == "km")
                {
                    a *= 0.001;
                }
                if (c == "ft")
                {
                    a *= 3.2808399;
                }
                if (c == "yd")
                {
                    a *= 1.0936133;
                }
            }
            if (b == "ft")
            {
                a /= 3.2808399;
                if (c == "mm")
                {
                    a *= 1000;
                }
                if (c == "cm")
                {
                    a *= 100;
                }
                if (c == "mi")
                {
                    a *= 0.000621371192;
                }
                if (c == "in")
                {
                    a *= 39.3700787;
                }
                if (c == "km")
                {
                    a *= 0.001;
                }
                if (c == "ft")
                {
                    a *= 3.2808399;
                }
                if (c == "yd")
                {
                    a *= 1.0936133;
                }
            }
            if (b == "yd")
            {
                a /= 1.0936133;
                if (c == "mm")
                {
                    a *= 1000;
                }
                if (c == "cm")
                {
                    a *= 100;
                }
                if (c == "mi")
                {
                    a *= 0.000621371192;
                }
                if (c == "in")
                {
                    a *= 39.3700787;
                }
                if (c == "km")
                {
                    a *= 0.001;
                }
                if (c == "ft")
                {
                    a *= 3.2808399;
                }
                if (c == "yd")
                {
                    a *= 1.0936133;
                }
            }
            Console.WriteLine($"{a}:f8");
        }
    }
}
