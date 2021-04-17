using Xunit;
using FluentAssertions;
using GildedRose.App;
using System.Collections.Generic;

namespace GildedRose.Test
{
    // Blackbox tests from real observed data (snapshots)
    public class SnapshotTests
    {
        [Fact]
        public void Items_ShouldMatchSnapshot_WhenUpdatedOnce()
        {
            var items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20 },
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };

            UpdateItems(items);

            ItemShouldMatch(items[0], 9, 19);
            ItemShouldMatch(items[1], 1, 1);
            ItemShouldMatch(items[2], 4, 6);
            ItemShouldMatch(items[3], 0, 80);
            ItemShouldMatch(items[4], -1, 0);
            ItemShouldMatch(items[5], 2, 5);
        }

        [Fact]
        public void Items_ShouldMatchSnapshot_WhenUpdatedTwice()
        {
            // TODO
        }

        private void UpdateItems(IList<Item> items)
        {
            var app = new Program();
            app.Items = items;
            app.UpdateQuality();
        }

        private void ItemShouldMatch(Item item, int sellIn, int quality)
        {
            item.SellIn.Should().Be(sellIn);
            item.Quality.Should().Be(quality);
        }
    }
}