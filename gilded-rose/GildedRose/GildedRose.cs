using GildedRose.ItemUpdate;
using System.Collections.Generic;

namespace GildedRose
{
    /// <summary>
    /// New item updater (refactoring started from the legacy copy).
    /// </summary>
    public class GildedRose
    {
        private readonly IEnumerable<Item> items;

        public GildedRose(IEnumerable<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                var gildedRoseItem = GildedRoseItemFactory.Create(item);
                gildedRoseItem.Update();
            }
        }
    }
}
