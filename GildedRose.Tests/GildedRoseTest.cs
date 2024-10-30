using GildedRoseNS;
using Xunit;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        //[Fact]
        //public void Test()
        //{
        //    string text = System.IO.File.ReadAllText("sample.approved.txt");

        //    Assert.Equal("Approved result", text);
        //}

        [Fact]
        public void UpdateQuality_NormalItem_DecreasesQualityAndSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(items);


            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(19, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_IncreasesQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_IncreasesQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_Sulfuras_NoChangeInQualityOrSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(10, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_QualityDropsToZeroAfterConcert()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }
        [Fact]
        public void UpdateQuality_MultipleItems_MultipleUpdates()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 }
            };
            GildedRose app = new GildedRose(items);

            // 调用多次 UpdateQuality 方法
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            Assert.Equal(5, items[0].SellIn);
            Assert.Equal(15, items[0].Quality);

            Assert.Equal(-3, items[1].SellIn);
            Assert.Equal(8, items[1].Quality);

            Assert.Equal(0, items[2].SellIn);
            Assert.Equal(2, items[2].Quality);

            Assert.Equal(0, items[3].SellIn);
            Assert.Equal(80, items[3].Quality);

            Assert.Equal(-1, items[4].SellIn);
            Assert.Equal(80, items[4].Quality);

            Assert.Equal(10, items[5].SellIn);
            Assert.Equal(25, items[5].Quality);

            Assert.Equal(5, items[6].SellIn);
            Assert.Equal(50, items[6].Quality);

            Assert.Equal(0, items[7].SellIn);
            Assert.Equal(50, items[7].Quality);
        }

    }
}
