using System.Collections.Generic;
using System.Diagnostics;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        private IDictionary<string, IUpdater> updaters;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
            updaters = new Dictionary<string, IUpdater>{
                { "Aged Brie", new AgedBrieUpdater() },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassesUpdater() },
                { "Sulfuras, Hand of Ragnaros", new SulfurasUpdater() }
            };
        }

        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                if (updaters.ContainsKey(item.Name))
                {
                    updaters[item.Name].Update(item);
                }
                else
                {
                    new DefaultUpdater().Update(item);
                }
            }
        }
    }
}
