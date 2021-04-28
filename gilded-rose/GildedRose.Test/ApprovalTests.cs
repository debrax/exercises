using ApprovalTests;
using ApprovalTests.Reporters;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Test
{
    [UseReporter(typeof(VisualStudioReporter))]
    public class ApprovalTests
    {
        [Fact]
        public void AllItems()
        {
            var itemNames = new[]
            {
                "+5 Dexterity Vest",
                "Aged Brie",
                "Elixir of the Mongoose",
                "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert",
                "Conjured Mana Cake"
            };
            var items = GenerateItems(itemNames).ToList();

            var app = new GildedRose(items);
            app.UpdateQuality();

            Approvals.VerifyAll(items, ItemFormatter);
        }

        private static IEnumerable<Item> GenerateItems(string[] names)
        {
            foreach (var name in names)
            {
                for (var sellIn = 15; sellIn >= -5; sellIn--)
                {
                    for (var quality = -25; quality <= 100; quality += 25)
                    {
                        yield return new Item { Name = name, SellIn = sellIn, Quality = quality };
                    }
                }
            }
        }

        private static string ItemFormatter(Item item) => $"{item.Name}, {item.SellIn}, {item.Quality}";
    }
}
