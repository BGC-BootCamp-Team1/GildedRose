using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    DecreaseQualityIfNameNotSulfuras(item);
                }
                else
                {
                    item.IncreaseQuality();
                    UpdateBackstagePasses(item);
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    UpdateExpiredItems(item);
                }
            }
        }

        private void UpdateExpiredItems(Item item)
        {
            if (item.Name != "Aged Brie")
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    DecreaseQualityIfNameNotSulfuras(item);
                }
                else
                {
                    item.Quality = 0;
                }
            }
            else
            {
                item.IncreaseQuality();
            }
        }

        private void UpdateBackstagePasses(Item item)
        {
            if (item.Quality < 50)
            {
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        item.IncreaseQuality();
                    }

                    if (item.SellIn < 6)
                    {
                        item.IncreaseQuality();
                    }
                }
            }
        }

        private void DecreaseQualityIfNameNotSulfuras(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}
