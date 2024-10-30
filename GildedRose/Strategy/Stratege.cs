using GildedRose.Stratege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class BackstagePassesUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn < 11 && item.Quality < 50)
                {
                    item.Quality++;
                }
                if (item.SellIn < 6 && item.Quality < 50)
                {
                    item.Quality++;
                }
            }
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }

    public class SulfurasUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            // Sulfuras does not change
        }
    }

    public class DefaultUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }

}
