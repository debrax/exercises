using FluentAssertions;
using Xunit;

namespace GildedRose.Test
{
    public class BrieUpdaterTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void BrieUpdater_DecreasesSellIn(int sellIn)
        {
            var updater = new BrieUpdater();
            var item = new Item { Name = "Aged Brie", SellIn = sellIn };
            updater.UpdateItem(new UpdatableItem(item));
            item.SellIn.Should().Be(sellIn - 1);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void BrieUpdater_IncreasesQualityOnce_BeforeSellIn(int sellIn)
        {
            var quality = 10;
            var updater = new BrieUpdater();
            var item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            updater.UpdateItem(new UpdatableItem(item));
            item.Quality.Should().Be(quality + 1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void BrieUpdater_IncreasesQualityTwice_AfterSellIn(int sellIn)
        {
            var quality = 10;
            var updater = new BrieUpdater();
            var item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            updater.UpdateItem(new UpdatableItem(item));
            item.Quality.Should().Be(quality + 2);
        }
    }
}
