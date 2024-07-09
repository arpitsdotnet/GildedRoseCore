using System;
using System.Collections.Generic;
using GildedRoseCore.Console;
using Xunit;

namespace Tests
{
    public class GildedRoseTests
    {
        [Fact]
        // - At the end of each day our system lowers the value of sellin for every item
        public void UpdateQuality_ShouldReduceSellinBy1_WhenNameIsOrdinary()
        {
            // Given the Item has Sellin days of 5
            var fooItem = CreateItem("Foo", 5, 5);
            var sut = CreateGildedRose(fooItem);

            // When the Quality update occures
            sut.UpdateQuality();

            // Then the Sellin is 4
            Assert.Equal(4, fooItem.SellIn);
        }


        [Fact]
        // - At the end of each day our system lowers the value of quality for every item
        public void UpdateQuality_ShouldReduceQualityBy1_WhenNameIsOrdinary()
        {
            // Given the Item has Quality of 5
            var fooItem = CreateItem("Foo", 5, 5);
            var sut = CreateGildedRose(fooItem);

            // When the Quality update occures
            sut.UpdateQuality();

            // Then the Quality is 4
            Assert.Equal(4, fooItem.Quality);
        }

        [Fact]
        // - Once the sell by date has passed, Quality degrades twice as fast
        public void UpdateQuality_ShouldReduceQualityBy2_WhenSellInHasPassed()
        {
            // Given the sell-by date has passed
            var zeroSellInItem = CreateItem("Foo", 5, 0);
            var sut = CreateGildedRose(zeroSellInItem);

            // When the Quality update occures
            sut.UpdateQuality();

            // Then the Quality twice as fast
            Assert.Equal(3, zeroSellInItem.Quality);
        }

        [Fact]
        // - The Quality of an item is never negative
        public void UpdateQuality_ShouldNotReduceQualityToNegative_WhenQualityIsZero()
        {
            // Given the quality of an item is 0
            var zeroQualityItem = CreateItem("Foo", 0, 5);
            var sut = CreateGildedRose(zeroQualityItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality is still 0
            Assert.Equal(0, zeroQualityItem.Quality);
        }

        [Fact]
        // - "Aged Brie" actually increases in Quality the older it gets
        public void UpdateQuality_ShouldIncreaseQualityBy1_WhenItemIsAgedBrie()
        {
            // Given the item name is Aged Brie and it's Quality is 1
            var agedBrieItem = CreateItem(Constants.AGED_BRIE, 1, 5);
            var sut = CreateGildedRose(agedBrieItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality is 2
            Assert.Equal(2, agedBrieItem.Quality);
        }

        [Fact]
        // - The Quality of an item is never more than 50
        public void UpdateQuality_ShouldNotIncreaseQuality_WhenAgedBrieQualityIs50()
        {
            // Given the quality of an item should not increase
            var agedBrieItem = CreateItem(Constants.AGED_BRIE, 50, 5);
            var sut = CreateGildedRose(agedBrieItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality is still 50
            Assert.Equal(50, agedBrieItem.Quality);
        }

        [Fact]
        // - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        public void UpdateQuality_ShouldNotDecreaseQuality_WhenItemIsSulfuras()
        {
            // Given the quality of an item should not decrease
            var sulfurasItem = CreateItem(Constants.SULFURAS_HAND_OF_RAGNAROS, 5, 5);
            var sut = CreateGildedRose(sulfurasItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality is still 5
            Assert.Equal(5, sulfurasItem.Quality);
            Assert.Equal(5, sulfurasItem.SellIn);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(11)]
        // - "Backstage passes", like aged brie,
        // - increases in Quality as it's SellIn value approaches;
        // - Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
        // - but Quality drops to 0 after the concert
        public void UpdateQuality_ShouldIncreaseQualityBy1_WhenItemIsBackstagePasses(int sellIn)
        {
            // Given the item is Backstage passes and the sell in value is greater than 10
            var backstagePassesItem = CreateItem(Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT, 10, sellIn);
            var sut = CreateGildedRose(backstagePassesItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality increases by 1
            Assert.Equal(11, backstagePassesItem.Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(8)]
        [InlineData(6)]
        // - "Backstage passes", like aged brie,
        // - increases in Quality as it's SellIn value approaches;
        // - Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
        // - but Quality drops to 0 after the concert
        public void UpdateQuality_ShouldIncreaseQualityBy2_WhenItemIsBackstagePassesLeftWith10DaysOrLess(int sellIn)
        {
            // Given the item is Backstage passes and the sell in value is greater than 5 and less or equal to 10
            var backstagePassesItem = CreateItem(Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT, 10, sellIn);
            var sut = CreateGildedRose(backstagePassesItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality increases by 2
            Assert.Equal(12, backstagePassesItem.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(3)]
        [InlineData(1)]
        // - "Backstage passes", like aged brie,
        // - increases in Quality as it's SellIn value approaches;
        // - Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
        // - but Quality drops to 0 after the concert
        public void UpdateQuality_ShouldIncreaseQualityBy3_WhenItemIsBackstagePassesLeftWith5DaysOrLess(int sellIn)
        {
            // Given the item is Backstage passes and the sell in value is greater than 5 and less or equal to 10
            var backstagePassesItem = CreateItem(Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT, 10, sellIn);
            var sut = CreateGildedRose(backstagePassesItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality increases by 2
            Assert.Equal(13, backstagePassesItem.Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        // - "Backstage passes", like aged brie,
        // - increases in Quality as it's SellIn value approaches;
        // - Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
        // - but Quality drops to 0 after the concert
        public void UpdateQuality_ShouldDecreaseQualityTo0_WhenItemIsBackstagePassesLeftWith0Days(int sellIn)
        {
            // Given the item is Backstage passes and the sell in value is greater than 5 and less or equal to 10
            var backstagePassesItem = CreateItem(Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT, 10, sellIn);
            var sut = CreateGildedRose(backstagePassesItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality increases by 2
            Assert.Equal(0, backstagePassesItem.Quality);
        }

        [Fact]
        // - An item can never have its Quality increase above 50,
        // - however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.

        public void UpdateQuality_ShouldNotIncreaseQualityBy80_WhenItemIsSulfuras()
        {
            // Given the quality of an item should not decrease
            var sulfurasItem = CreateItem(Constants.SULFURAS_HAND_OF_RAGNAROS, 80, 5);
            var sut = CreateGildedRose(sulfurasItem);

            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality is still 5
            Assert.Equal(80, sulfurasItem.Quality);
        }

        [Fact]
        // - "Conjured" items degrade in Quality twice as fast as normal items
        public void UpdateQuality_ShouldDecreaseQualityBy2_WhenItemConjured()
        {
            // Given the item is Conjured and it's quality is 4
            var conjuredItem = CreateItem(Constants.CONJURED_MANA_CAKE, 10, 5);
            var sut = CreateGildedRose(conjuredItem);
            
            // When the quality update occures
            sut.UpdateQuality();

            // Then the Quality of the item is 2
            Assert.Equal(8, conjuredItem.Quality);
            Assert.Equal(4, conjuredItem.SellIn);
        }



        private static Item CreateItem(string name, int quality, int sellin) =>
            new Item { Name = name, Quality = quality, SellIn = sellin };

        private static GildedRose CreateGildedRose(Item newItem) =>
            new GildedRose(new List<Item> { newItem });

    }
}
