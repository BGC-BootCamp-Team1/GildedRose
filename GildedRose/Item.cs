using System;
namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void IncreaseQuality()
        {
            if (Quality < 50) Quality ++;
        }

        public void DecreaseQuality()
        {
            if (Quality > 0) Quality --;
        }
    }
}
