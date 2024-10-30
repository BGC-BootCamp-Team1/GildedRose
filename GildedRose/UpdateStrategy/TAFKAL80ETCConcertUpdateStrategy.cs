namespace GildedRose.UpdateStrategy
{
    internal class TAFKAL80ETCConcertUpdateStrategy : IUpdate
    {
        public void Update(Item item)
        {
            item.IncrementQuality();

            if (item.SellIn < 11)
            {
                item.IncrementQuality();
            }

            if (item.SellIn < 6)
            {
                item.IncrementQuality(2);
            }
            item.SellIn = item.SellIn - 1;

            item.Quality = (item.SellIn < 0) ? 0 : item.Quality;
        }
    }
}