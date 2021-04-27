using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using App;
using Xunit;

namespace Test
{
    // Characterization test: proof of non-regression by camparing outputs for same input
    public class ApprovalTest
    {
        [Fact]
        public void RealItemsOutput_ShouldMatchLegacyOutput()
        {
            var realItems = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
                // this conjured item does not work properly yet
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };

            var app = new GildedRose(realItems);
            app.UpdateQuality();
            var output = BuildOutput(realItems);

            output.Should().Be(RealItemsOutput);
        }

        private static string BuildOutput(IList<Item> items) =>
            string.Join("\n", items.Select(item => $"{item.Name}, {item.SellIn}, {item.Quality}"));

        private const string RealItemsOutput = "+5 Dexterity Vest, 9, 19\nAged Brie, 1, 1\nElixir of the Mongoose, 4, 6\nSulfuras, Hand of Ragnaros, 0, 80\nSulfuras, Hand of Ragnaros, -1, 80\nBackstage passes to a TAFKAL80ETC concert, 14, 21\nBackstage passes to a TAFKAL80ETC concert, 9, 50\nBackstage passes to a TAFKAL80ETC concert, 4, 50\nConjured Mana Cake, 2, 5";
    }
}