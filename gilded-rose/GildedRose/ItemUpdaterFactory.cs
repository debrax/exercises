namespace GildedRose
{
    public static class ItemUpdaterFactory
    {
        public static ItemUpdater CreateItemUpdater(Item item)
        {
            switch (item.Name)
            {
                case ItemType.AgedBrie:
                    return new BrieUpdater();

                case ItemType.BackstagePasses:
                    return new BackstagePassesUpdater();

                case ItemType.Sulfuras:
                    return new SulfurasUpdater();

                case ItemType.Conjured:
                    return new ConjuredItemUpdater();

                default:
                    return new DefaultItemUpdater();
            }
        }
    }

    public static class ItemType
    {
        public const string AgedBrie = "Aged Brie";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string Conjured = "Conjured Mana Cake";
    }
}
