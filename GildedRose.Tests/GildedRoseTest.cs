using GildedRose;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void TestConsoleOutputString()
        {
            string expectedDay2 = @"-------- day 2 --------
name, sellIn, quality
+5 Dexterity Vest, 8, 18
Aged Brie, 0, 2
Elixir of the Mongoose, 3, 5
Sulfuras, Hand of Ragnaros, 0, 80
Sulfuras, Hand of Ragnaros, -1, 80
Backstage passes to a TAFKAL80ETC concert, 13, 22
Backstage passes to a TAFKAL80ETC concert, 8, 50
Backstage passes to a TAFKAL80ETC concert, 3, 50".Replace("\r\n", "\n").Replace("\n", Environment.NewLine);

            string expectedDay6 = @"-------- day 6 --------
name, sellIn, quality
+5 Dexterity Vest, 4, 14
Aged Brie, -4, 10
Elixir of the Mongoose, -1, 0
Sulfuras, Hand of Ragnaros, 0, 80
Sulfuras, Hand of Ragnaros, -1, 80
Backstage passes to a TAFKAL80ETC concert, 9, 27
Backstage passes to a TAFKAL80ETC concert, 4, 50
Backstage passes to a TAFKAL80ETC concert, -1, 0".Replace("\r\n", "\n").Replace("\n", Environment.NewLine);

            string expectedDay17 = @"-------- day 17 --------
name, sellIn, quality
+5 Dexterity Vest, -7, 0
Aged Brie, -15, 32
Elixir of the Mongoose, -12, 0
Sulfuras, Hand of Ragnaros, 0, 80
Sulfuras, Hand of Ragnaros, -1, 80
Backstage passes to a TAFKAL80ETC concert, -2, 0
Backstage passes to a TAFKAL80ETC concert, -7, 0
Backstage passes to a TAFKAL80ETC concert, -12, 0".Replace("\r\n", "\n").Replace("\n", Environment.NewLine);

            string expectedDay30 = @"-------- day 30 --------
name, sellIn, quality
+5 Dexterity Vest, -20, 0
Aged Brie, -28, 50
Elixir of the Mongoose, -25, 0
Sulfuras, Hand of Ragnaros, 0, 80
Sulfuras, Hand of Ragnaros, -1, 80
Backstage passes to a TAFKAL80ETC concert, -15, 0
Backstage passes to a TAFKAL80ETC concert, -20, 0
Backstage passes to a TAFKAL80ETC concert, -25, 0".Replace("\r\n", "\n").Replace("\n", Environment.NewLine);

            string outputStr = Program.GenerateGildedRoseConsoleOutput();
            Assert.Equal(10516, outputStr.Count());
            Assert.Equal(expectedDay2, FindSectionByDay(outputStr, 2));
            Assert.Equal(expectedDay6, FindSectionByDay(outputStr, 6));
            Assert.Equal(expectedDay17, FindSectionByDay(outputStr, 17));
            Assert.Equal(expectedDay30, FindSectionByDay(outputStr, 30));
        }

        private string FindSectionByDay(string input, int day)
        {
            input = input.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            string dayHeader = $"-------- day {day} --------";
            int startIndex = input.IndexOf(dayHeader);

            int endIndex = input.IndexOf("-------- day ", startIndex + dayHeader.Length);
            if (endIndex == -1)
            {
                endIndex = input.Length;
            }

            return input.Substring(startIndex, endIndex - startIndex).Trim();
        }
    }
}
