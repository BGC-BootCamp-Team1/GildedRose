namespace GildedRose.UpdateStrategy
{
    internal class AgeBrieUpdateStrategy : IUpdate
    {
        public void Update(Item item)
        {
            item.IncrementQuality();
            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.IncrementQuality();
            }
        }
    }
}