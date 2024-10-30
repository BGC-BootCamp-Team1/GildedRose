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
            const string name1 = "Aged Brie";
            const string name2 = "Backstage passes to a TAFKAL80ETC concert";
            const string name3 = "Sulfuras, Hand of Ragnaros";
            const int QUALITY_MIN = 0;
            const int QUALITY_MAX = 50;

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != name1 && items[i].Name != name2)
                {
                    if (items[i].Quality > QUALITY_MIN)
                    {
                        if (items[i].Name != name3)
                        {
                            items[i].Quality = items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (items[i].Quality < QUALITY_MAX)
                    {
                        items[i].Quality = items[i].Quality + 1;

                        if (items[i].Name == name2)
                        {
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < QUALITY_MAX)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }

                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < QUALITY_MAX)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != name3)
                {
                    items[i].SellIn = items[i].SellIn - 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != name1)
                    {
                        if (items[i].Name != name2)
                        {
                            if (items[i].Quality > QUALITY_MIN)
                            {
                                if (items[i].Name != name3)
                                {
                                    items[i].Quality = items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < QUALITY_MAX)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
