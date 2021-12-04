namespace GildedRose.ItemUpdate
{
    internal static class GildedRoseItemFactory
    {
        public static GildedRoseItem Create(Item item)
        {
            switch (item.Name)
            {
                case ItemName.AgedBrie:
                    return new AgedBrie(item);

                case ItemName.BackstagePasses:
                    return new BackstagePasses(item);

                case ItemName.Sulfuras:
                    return new Sulfuras(item);

                case ItemName.ConjuredManaCake:
                    return new ConjuredItem(item);

                default:
                    return new DefaultItem(item);
            }
        }
    }

    internal static class ItemName
    {
        public const string AgedBrie = "Aged Brie";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string ConjuredManaCake = "Conjured Mana Cake";
    }
}
