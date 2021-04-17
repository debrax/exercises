using Xunit;
using FluentAssertions;
using System;

namespace RomanFormatter
{
    public class RomanFormatterTests
    {
        [Fact]
        public void RomanNotation_ShouldThrow_WhenIntegerNegative()
        {
            Action conversion = () => RomanFormatter.ToRomanNotation(-1);
            conversion.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void RomanNotation_ShouldThrow_WhenIntegerNull()
        {
            Action conversion = () => RomanFormatter.ToRomanNotation(0);
            conversion.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        public void RomanNotation_ShouldBeUnitNotation_WhenUnits(int integer, string notation)
        {
            RomanFormatter.ToRomanNotation(integer).Should().Be(notation);
        }

        [Theory]
        [InlineData(10, "X")]
        [InlineData(20, "XX")]
        [InlineData(30, "XXX")]
        [InlineData(40, "XL")]
        [InlineData(50, "L")]
        [InlineData(60, "LX")]
        [InlineData(70, "LXX")]
        [InlineData(80, "LXXX")]
        [InlineData(90, "XC")]
        public void RomanNotation_ShouldBeTenNotation_WhenTens(int integer, string notation)
        {
            RomanFormatter.ToRomanNotation(integer).Should().Be(notation);
        }

        [Theory]
        [InlineData(100, "C")]
        [InlineData(200, "CC")]
        [InlineData(300, "CCC")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(600, "DC")]
        [InlineData(700, "DCC")]
        [InlineData(800, "DCCC")]
        [InlineData(900, "CM")]
        public void RomanNotation_ShouldBeHundredNotation_WhenHundreds(int integer, string notation)
        {
            RomanFormatter.ToRomanNotation(integer).Should().Be(notation);
        }

        [Theory]
        [InlineData(1000, "M")]
        [InlineData(2000, "MM")]
        [InlineData(3000, "MMM")]
        [InlineData(5000, "MMMMM")]
        [InlineData(9000, "MMMMMMMMM")]
        [InlineData(10000, "MMMMMMMMMM")]
        public void RomanNotation_ShouldBeThousandNotation_WhenThousands(int integer, string notation)
        {
            RomanFormatter.ToRomanNotation(integer).Should().Be(notation);
        }

        [Theory]
        [InlineData(481, "CDLXXXI")] // Clovis King of the Franks
        [InlineData(800, "DCCC")] // Charlemagne coronation
        [InlineData(1095, "MXCV")] // First crusade
        [InlineData(1492, "MCDXCII")] // America discovery
        [InlineData(1789, "MDCCLXXXIX")] // French revolution
        [InlineData(1804, "MDCCCIV")] // Napoleon coronation
        [InlineData(1945, "MCMXLV")] // End of second world war
        public void RomanNotation_ShouldBeMatchingNotation_WhenRealDate(int integer, string notation)
        {
            RomanFormatter.ToRomanNotation(integer).Should().Be(notation);
        }
    }
}
