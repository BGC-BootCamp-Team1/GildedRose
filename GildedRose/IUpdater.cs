namespace GildedRose
{
    public interface IUpdater
    {
        public void Update(Item item);
    }

    public class AgedBrieUpdater : IUpdater
    {
        public void Update(Item item)
        {
            item.IncreaseQuality();
            item.SellIn--;
            if (item.SellIn < 0) item.IncreaseQuality();
        }
    }

    public class BackstagePassesUpdater : IUpdater
    {
        public void Update(Item item)
        {
            item.IncreaseQuality();
            if (item.SellIn < 11) item.IncreaseQuality();
            if (item.SellIn < 6) item.IncreaseQuality();
            item.SellIn--;
            if (item.SellIn < 0) item.Quality = 0;
        }
    }

    public class SulfurasUpdater : IUpdater
    {
        public void Update(Item item) { }
    }

    public class DefaultUpdater : IUpdater
    {
        public void Update(Item item)
        {
            item.DecreaseQuality();
            item.SellIn--;
            if (item.SellIn < 0) item.DecreaseQuality();
        }
    }
}
