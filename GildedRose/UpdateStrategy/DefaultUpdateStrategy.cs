namespace GildedRose.UpdateStrategy
{
    internal class DefaultUpdateStrategy : IUpdate
    {
        public void Update(Item item)
        {
            item.DecrementQuality();
            item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0)
            {
                item.DecrementQuality();
            }
        }
    }
}