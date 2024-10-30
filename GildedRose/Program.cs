using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string outputStr = GenerateGildedRoseConsoleOutput();
            Console.Write(outputStr);
            
        }

        public static string GenerateGildedRoseConsoleOutput()
        {
            List<string> outputStrArray = ["OMGHAI!"];

            IList<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20,
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49,
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49,
                },
            };

            var app = new GildedRose(items);
            const int Days = 31;
            for (var i = 0; i < Days; i++)
            {
                outputStrArray.Add("-------- day " + i + " --------");
                outputStrArray.Add("name, sellIn, quality");

                for (var j = 0; j < items.Count; j++)
                {
                    outputStrArray.Add(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
                }

                outputStrArray.Add(string.Empty);
                app.UpdateQuality();
            }
            return string.Join("\n", outputStrArray);
        }
    }
}
