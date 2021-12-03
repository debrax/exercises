using ApprovalTests;
using ApprovalTests.Reporters;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// Golden master: copy of the legacy program output for non-regression,
    /// to compare with new output on every refactoring step.
    /// Has no domain value and does not replace other tests!
    /// </summary>
    [UseReporter(typeof(VisualStudioReporter))]
    public class GoldenMasterTest
    {
        [Fact]
        public void GeneratedItems()
        {
            var itemNames = new[]
            {
                "+5 Dexterity Vest",
                "Aged Brie",
                "Elixir of the Mongoose",
                "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert"
            };
            var items = GenerateItems(itemNames).ToList();

            // Run once at first for saving the legacy output in reference file
            //var app = new GildedRoseLegacy(items);

            // Run on any change to prevent regression
            var app = new GildedRose(items);
            app.UpdateQuality();

            Approvals.VerifyAll(items, ItemFormatter);
        }

        // Goal: generate enough cases for acceptable coverage.
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

        private static string ItemFormatter(Item item) => $"{item.Name};{item.SellIn};{item.Quality}";
    }
}
