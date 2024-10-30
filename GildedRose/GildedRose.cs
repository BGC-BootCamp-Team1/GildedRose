using System.Collections.Generic;
using System.Diagnostics;

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
                UpdateItemQuality(item);
                UpdateSellIn(item);

                if (item.SellIn < 0)
                {
                    UpdateExpiredItems(item);
                }
            }
        }

        private static void UpdateSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }
        }

        private void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    item.IncreaseQuality();
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    item.IncreaseQuality();
                    UpdateBackstagePasses(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    item.DecreaseQuality();
                    break;
            }
        }

        private void UpdateExpiredItems(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    item.IncreaseQuality();
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    item.Quality = 0;
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    item.DecreaseQuality();
                    break;
            }
        }

        private void UpdateBackstagePasses(Item item)
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
