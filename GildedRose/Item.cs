using System;
namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

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
    }
}
