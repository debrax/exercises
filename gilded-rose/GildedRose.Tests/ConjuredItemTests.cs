using Xunit;
using GildedRose.ItemUpdate;
using FluentAssertions;

namespace GildedRose.Tests
{
    public class ConjuredItemTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void ConjuredItemUpdate_DecrementsSellInBy1(int sellIn)
        {
            var item = SetupConjuredItem(sellIn, 0);
            new ConjuredItem(item).Update();
            item.SellIn.Should().Be(sellIn - 1);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void ConjuredItemUpdate_DecrementsQualityBy2_BeforeExpiration(int sellIn)
        {
            var item = SetupConjuredItem(sellIn, 2);
            new ConjuredItem(item).Update();
            item.Quality.Should().Be(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void ConjuredItemUpdate_DecrementsQualityBy4_AfterExpiration(int sellIn)
        {
            var item = SetupConjuredItem(sellIn, 4);
            new ConjuredItem(item).Update();
            item.Quality.Should().Be(0);
        }

        private static Item SetupConjuredItem(int sellIn, int quality) => new Item
        {
            Name = ItemName.ConjuredManaCake,
            SellIn = sellIn,
            Quality = quality
        };
    }
}