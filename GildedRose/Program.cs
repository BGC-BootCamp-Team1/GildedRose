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

            for (var day = 0; day < 31; day++)
            {
                outputStrArray.Add("-------- day " + day + " --------");
                outputStrArray.Add("name, sellIn, quality");

                for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
                {
                    outputStrArray.Add(items[itemIndex].Name + ", " + items[itemIndex].SellIn + ", " + items[itemIndex].Quality);
                }

                outputStrArray.Add(string.Empty);
                app.UpdateQualityAndSellIn();
            }
            return string.Join("\n", outputStrArray);
        }
    }
}
