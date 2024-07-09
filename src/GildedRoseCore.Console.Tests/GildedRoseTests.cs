using System;
using System.Collections.Generic;
using GildedRoseCore.Console;
using Xunit;

namespace Tests
{
    public class GildedRoseTests
    {
        // - At the end of each day our system lowers both values for every item
        [Fact]
        public void TestTheTruth()
        {
            // Given the Item has Sellin days of 5
            var fooItem = new Item { Name = "Foo", Quality = 5, SellIn = 5 };
            var sut = new GildedRose(new List<Item> { fooItem });

            // When the Quality update occures
            sut.UpdateQuality();

            // Then the Sellin is 4
            Assert.Equal(4, fooItem.SellIn);
        }
    }
}
