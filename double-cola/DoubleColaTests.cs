using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoubleCola
{
    [TestClass]
    public class DoubleColaTests
    {
        [DataTestMethod]
        [DataRow(null)] // Null considered as no drinker
        [DataRow(new string[0])]
        public void NthDrinker_IsNobody_WhenNoDrinker(string[] drinkers)
        {
            var doubleCola = new DoubleCola(drinkers);
            doubleCola.GetNthColaDrinker(1).Should().Be(DoubleCola.Nobody);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)] // Negatives considered as no cola drunk
        [DataRow(int.MinValue)]
        public void NthDrinker_IsNobody_WhenNoColaDrunk(int n)
        {
            var doubleCola = new DoubleCola(new[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" });
            doubleCola.GetNthColaDrinker(n).Should().Be(DoubleCola.Nobody);
        }

        [DataTestMethod]
        [DataRow(1, "Sheldon")]
        [DataRow(9, "Penny")]
        [DataRow(59, "Rajesh")]
        [DataRow(141, "Howard")]
        [DataRow(7230702951, "Leonard")]
        public void NthDrinker_IsExpected(long n, string expected)
        {
            var doubleCola = new DoubleCola(new[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" });
            doubleCola.GetNthColaDrinker(n).Should().Be(expected);
        }
    }
}
