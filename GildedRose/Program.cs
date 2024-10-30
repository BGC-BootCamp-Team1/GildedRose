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
            const int DAYS = 31;
            const string INITIAL_MESSAGE = "OMGHAI!";
            List<string> outputStrArray = [INITIAL_MESSAGE];
            IList<Item> items = InitializeItems();

            var app = new GildedRoseClass(items);
            for (var i = 0; i < DAYS; i++)
            {
                AddDayHeader(outputStrArray, i);
                AddItemsStatus(outputStrArray, items);
                app.UpdateQuality();
            }
            return string.Join("\n", outputStrArray);
        }

        private static void AddItemsStatus(List<string> outputStrArray, IList<Item> items)
        {
            for (var j = 0; j < items.Count; j++)
            {
                outputStrArray.Add($"{items[j].Name}, {items[j].SellIn}, {items[j].Quality}");
            }

            outputStrArray.Add(string.Empty);
        }

        private static void AddDayHeader(List<string> outputStrArray, int i)
        {
            outputStrArray.Add("-------- day " + i + " --------");
            outputStrArray.Add("name, sellIn, quality");
        }

        private static IList<Item> InitializeItems()
        {
            return new List<Item>
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
        }
    }
}
