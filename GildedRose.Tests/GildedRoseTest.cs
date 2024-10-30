using GildedRose;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void TestConsoleOutputString()
        {
            string expectedOutputDay2 = @"-------- day 2 --------
name, sellIn, quality
+5 Dexterity Vest, 8, 18
Aged Brie, 0, 2
Elixir of the Mongoose, 3, 5
Sulfuras, Hand of Ragnaros, 0, 80
Sulfuras, Hand of Ragnaros, -1, 80
Backstage passes to a TAFKAL80ETC concert, 13, 22
Backstage passes to a TAFKAL80ETC concert, 8, 50
Backstage passes to a TAFKAL80ETC concert, 3, 50";
            expectedOutputDay2 = expectedOutputDay2.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);

            string outputStr = Program.GenerateGildedRoseConsoleOutput();
            Assert.Equal(10516, outputStr.Count());
            Assert.Equal(expectedOutputDay2, FindSectionByDay(outputStr, 2));
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
