using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                UpdateItem(item);
            }
        }

        private void UpdateItem(Item item)
        {
            ItemUpdater itemUpdater;
            switch (item.Name)
            {
                case "Aged Brie":
                    itemUpdater = new BrieUpdater();
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    itemUpdater = new BackstagePassesUpdater();
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    itemUpdater = new SulfurasUpdater();
                    break;
                default:
                    itemUpdater = new DefaultItemUpdater();
                    break;
            }
            itemUpdater.UpdateItem(item);
        }
    }
}
