using Xunit;
using FluentAssertions;
using GildedRose.App;
using System.Collections.Generic;

namespace GildedRose.Test
{
    // Unit tests for the given business rules
    public class FunctionalTests
    {
        // "At the end of each day our system lowers SellIn for every item"
        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(0)]
        public void ItemSellIn_ShouldDecrementOnce_WhenUpdated(int sellIn)
        {
            var item = new Item { SellIn = sellIn };
            UpdateItem(item);
            item.SellIn.Should().Be(sellIn - 1);
        }

        // "At the end of each day our system lowers Quality for every item"
        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void ItemQuality_ShouldDecrementOnce_WhenUpdatedBeforeSellDate(int sellIn)
        {
            var item = new Item { SellIn = sellIn, Quality = TestQuality };
            UpdateItem(item);
            item.Quality.Should().Be(TestQuality - 1);
        }

        // "Once the sell by date has passed, Quality degrades twice as fast"
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void ItemQuality_ShouldDecrementTwice_WhenUpdatedAfterSellDate(int sellIn)
        {
            var item = new Item { SellIn = sellIn, Quality = TestQuality };
            UpdateItem(item);
            item.Quality.Should().Be(TestQuality - 2);
        }

        // "The quality of an item is never negative"
        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 0)]
        public void ItemQuality_ShouldNeverBeNegative_WhenDecremented(int sellIn, int quality)
        {
            var item = new Item { SellIn = sellIn, Quality = quality };
            UpdateItem(item);
            item.Quality.Should().Be(0);
        }

        // "Aged Brie actually increases in Quality the older it gets"
        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void AgedBrieQuality_ShouldIncrement_WhenUpdated(int sellIn)
        {
            var item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = TestQuality };
            UpdateItem(item);
            item.Quality.Should().Be(TestQuality + 1);
        }

        // "The Quality of an item is never more than 50"
        [Fact]
        public void ItemQuality_ShouldNotBeMoreThan50_WhenIncremented()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 };
            UpdateItem(item);
            item.Quality.Should().Be(50);
        }

        // "Sulfuras, being a legendary item, never has to be sold or decreases in Quality"
        [Fact]
        public void SulfurasQuality_ShouldNotDecrement_WhenUpdated()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80 };
            UpdateItem(item);
            item.Quality.Should().Be(80);
        }

        // "Backstage passes increases in Quality by 2 when there are 10 days or less"
        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void BackstagePassesQuality_ShouldIncrementBy2_WhenUpdatedBeforeSellDate(int sellIn)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = TestQuality
            };
            UpdateItem(item);
            item.Quality.Should().Be(TestQuality + 2);
        }

        // "Backstage passes increases in Quality by 3 when there are 5 days or less"
        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void BackstagePassesQuality_ShouldIncrementBy3_WhenUpdatedBeforeSellDate(int sellIn)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = TestQuality
            };
            UpdateItem(item);
            item.Quality.Should().Be(TestQuality + 3);
        }

        // "Backstage passes quality drops to 0 after the concert"
        [Fact]
        public void BackstagePassesQuality_ShouldDropTo0_WhenUpdatedAfterSellDate()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = TestQuality
            };
            UpdateItem(item);
            item.Quality.Should().Be(0);
        }

        // "Conjured items degrade in Quality twice as fast as normal items"
        [Fact]
        public void ConjuredItemQuality_ShouldDecrementTwiceMore_WhenUpdated()
        {
            // TODO
        }

        private void UpdateItem(Item item)
        {
            var app = new Program();
            app.Items = new List<Item> { item };
            app.UpdateQuality();
        }

        private const int TestQuality = 10;
    }
}