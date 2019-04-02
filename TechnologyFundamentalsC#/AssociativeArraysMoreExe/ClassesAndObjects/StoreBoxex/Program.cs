using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxex
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();
            List<Item> items = new List<Item>();
            List<Box> boxes = new List<Box>();
            while (data[0] != "end")
            {
                double PriceOfOneBox = 0.00;
                int serialNumber = int.Parse(data[0]);
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                double itemPrice = double.Parse(data[3]);

                PriceOfOneBox = itemQuantity * itemPrice;

                Box box = new Box();
                box.SerialNumber = serialNumber;
                box.ItemQuantity = itemQuantity;
                box.PriceOfBox = PriceOfOneBox;
                box.Item = new Item();
                box.Item.Name = itemName;
                box.Item.Price = itemPrice;
                boxes.Add(box);

                data = Console.ReadLine().Split();
            }
            List<Box> SortedList = boxes.OrderBy(o => o.PriceOfBox).ToList();
            SortedList.Reverse();
            foreach (var box in SortedList)
            {
                Console.WriteLine($"{ box.SerialNumber}");
                Console.WriteLine($"-- { box.Item.Name} - ${ box.Item.Price:f2}: { box.ItemQuantity}");
                Console.WriteLine($"-- ${ box.PriceOfBox:f2}");
            }
        }

        class Item
        {
            public string Name;
            public double Price;
        }

        class Box
        {
            public Box()
            {
                Item item = new Item();
            }
            public int SerialNumber;
            public Item Item;
            public int ItemQuantity;
            public double PriceOfBox;
        }
    }
}
