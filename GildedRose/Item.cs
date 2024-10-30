using System;
using GildedRose.UpdateStrategy;

namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public IUpdate UpdateStrategy
        {
            get
            {
                if (Name == "Aged Brie")
                    return new AgeBrieUpdateStrategy();
                else if (Name == "Backstage passes to a TAFKAL80ETC concert")
                    return new TAFKAL80ETCConcertUpdateStrategy();
                else if (Name == "Sulfuras, Hand of Ragnaros")
                    return new SulfurasUpdateStrategy();
                else
                    return new DefaultUpdateStrategy();
            }
        }

        private const int QUALITY_MAX = 50;
        private const int QUALITY_MIN = 0;

        internal void IncrementQuality(int incrementNumber = 1)
        {
            this.Quality = Math.Min(this.Quality + 1, QUALITY_MAX);
        }
        internal void DecrementQuality(int decrementNumber = 1)
        {
            this.Quality = Math.Max(this.Quality - decrementNumber, QUALITY_MIN);
        }

        internal void Update()
        {
            UpdateStrategy.Update(this);
        }
    }
}
