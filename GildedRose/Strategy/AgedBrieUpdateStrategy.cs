using GildedRose;

namespace GildedRose.Strategy
{
    public class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}
