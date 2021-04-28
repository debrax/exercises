namespace GildedRose
{
    public abstract class ItemUpdater
    {
        public abstract void UpdateItem(UpdatableItem item);
    }

    public class BrieUpdater : ItemUpdater
    {
        public override void UpdateItem(UpdatableItem item)
        {
            item.DecreaseSellIn();

            item.IncreaseQuality();

            if (item.IsSellDatePassed())
                item.IncreaseQuality();
        }
    }

    public class BackstagePassesUpdater : ItemUpdater
    {
        public override void UpdateItem(UpdatableItem item)
        {
            item.IncreaseQuality();

            if (item.IsSellDateWithinDays(10))
                item.IncreaseQuality();

            if (item.IsSellDateWithinDays(5))
                item.IncreaseQuality();

            item.DecreaseSellIn();

            if (item.IsSellDatePassed())
                item.ResetQuality();
        }
    }

    public class DefaultItemUpdater : ItemUpdater
    {
        public override void UpdateItem(UpdatableItem item)
        {
            item.DecreaseQuality();

            item.DecreaseSellIn();

            if (item.IsSellDatePassed())
                item.DecreaseQuality();
        }
    }

    public class SulfurasUpdater : ItemUpdater
    {
        public override void UpdateItem(UpdatableItem item) { }
    }
}
