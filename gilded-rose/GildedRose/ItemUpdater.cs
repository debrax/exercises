namespace GildedRose
{
    public abstract class ItemUpdater
    {
        public abstract void UpdateItem(Item item);

        protected static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        protected static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
                item.Quality++;
        }
    }

    public class BrieUpdater : ItemUpdater
    {
        public override void UpdateItem(Item item)
        {
            DecreaseSellIn(item);

            IncreaseQuality(item);

            if (item.SellIn < 0)
                IncreaseQuality(item);
        }
    }

    public class BackstagePassesUpdater : ItemUpdater
    {
        public override void UpdateItem(Item item)
        {
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
                ResetQuality(item);
            }
        }

        private static void ResetQuality(Item item)
        {
            item.Quality = 0;
        }
    }

    public class DefaultItemUpdater : ItemUpdater
    {
        public override void UpdateItem(Item item)
        {
            DecreaseQuality(item);
            DecreaseSellIn(item);
            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }

    public class SulfurasUpdater : ItemUpdater
    {
        public override void UpdateItem(Item item) { }
    }
}
