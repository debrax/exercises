using System;
using System.IO;
using FluentAssertions;
using GildedRose.App;
using Xunit;

namespace GildedRose.Test
{
    public class ApprovalTest
    {
        [Fact]
        public void ShouldMatchResult()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                Program.Main(null);
                var output = writer.ToString();

                output.Should().Be(Result);
            }
        }

        private const string Result = null;
    }
}