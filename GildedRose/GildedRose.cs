using System.Runtime.CompilerServices;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQualityAndSellIn()
        {
            foreach (var item in items)
            {
                item.Update();

            }
        }
    }
}
