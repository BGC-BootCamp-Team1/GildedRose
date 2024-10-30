using GildedRose.Strategy;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRoseCLZ
    {
        private IList<Item> items;
        private IDictionary<string, IUpdateStrategy> strategies;

        public GildedRoseCLZ(IList<Item> items)
        {
            this.items = items;
            strategies = new Dictionary<string, IUpdateStrategy>
            {
                { "Aged Brie", new AgedBrieUpdateStrategy() },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassesUpdateStrategy() },
                { "Sulfuras, Hand of Ragnaros", new SulfurasUpdateStrategy() }
            };

        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                if (strategies.ContainsKey(item.Name))
                {
                    strategies[item.Name].Update(item);
                }
                else
                {
                    new DefaultUpdateStrategy().Update(item);
                }
            }

        }
    }
}
