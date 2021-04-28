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
            switch (item.Name)
            {
                case "Aged Brie":
                    IncreaseQuality(item);
                    DecreaseSellIn(item);
                    if (item.SellIn < 0)
                    {
                        IncreaseQuality(item);
                    }
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    IncreaseQuality(item);
                    if (item.SellIn < 11)
                    {
                        IncreaseQuality(item);
                    }
                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item);
                    }
                    DecreaseSellIn(item);
                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    DecreaseQuality(item);
                    DecreaseSellIn(item);
                    if (item.SellIn < 0)
                    {
                        DecreaseQuality(item);
                    }
                    break;
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
