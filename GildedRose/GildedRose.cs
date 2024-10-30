namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQualityAndSellIn()
        {
            const string NAME1 = "Aged Brie";
            const string NAME2 = "Backstage passes to a TAFKAL80ETC concert";
            const string NAME3 = "Sulfuras, Hand of Ragnaros";

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name == NAME1)
                {
                    items[i].IncrementQuality();
                }
                else if (items[i].Name == NAME2)
                {
                    items[i].IncrementQuality();

                    if (items[i].SellIn < 11)
                    {
                        items[i].IncrementQuality();
                    }

                    if (items[i].SellIn < 6)
                    {
                        items[i].IncrementQuality(2);
                    }

                }
                else if (items[i].Name != NAME3)
                {
                    items[i].DecrementQuality();
                }

                if (items[i].Name != NAME3)
                {
                    items[i].SellIn = items[i].SellIn - 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name == NAME2)
                    {
                        items[i].Quality = 0;
                    }

                    if (items[i].Name == NAME1)
                    {
                        items[i].IncrementQuality();
                    }
                    else if (items[i].Name != NAME2 && items[i].Name != NAME3)
                    {
                        items[i].DecrementQuality();
                    }
                }
            }
        }
    }
}
