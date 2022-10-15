using System.Collections.Generic;
using System.Linq;
using Katas.GildedRoseKata;
using Xunit;

namespace Katas.Tests
{    
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(2, 10)]
        [InlineData(-1, 49)]
        [InlineData(42, 42)]
        [InlineData(-999, 52)]
        public void ShouldUpdateQuality_SULFURAS_HAND_OF_RAGNAROS(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.SULFURAS_HAND_OF_RAGNAROS, sellIn, quality) };

            var item = items.First();
            Assert.Equal(sellIn, item.SellIn);

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality, items.First().Quality);
            Assert.Equal(sellIn, items.First().SellIn);
        }

        [Fact]
        public void ShouldUpdateQuality_MANGOOSE_ELIXIR()
        {
            var items = new List<Item> { new Item(GildedRose.MANGOOSE_ELIXIR, 5, 7) };

            var item = items.First();
            Assert.Equal(5, item.SellIn);

            var itemsToUpdate = items.Take(1).ToList();
            var sut = new GildedRose(itemsToUpdate);

            sut.UpdateQuality();

            Assert.Equal(6, itemsToUpdate.First().Quality);
            Assert.Equal(4, itemsToUpdate.First().SellIn);
        }

        [Theory]
        [InlineData(2, 10)]
        [InlineData(-1, 49)]
        public void ShouldUpdateQuality_AGED_BRIE_IncrementQuality_DecreaseSellIn(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.AGED_BRIE, sellIn, quality) };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality + 1, items.Single().Quality);
            Assert.Equal(sellIn - 1, items.Single().SellIn);
        }

        [Theory]
        [InlineData(-10, 24)]
        [InlineData(-1, 0)]
        public void ShouldUpdateQuality_AGED_BRIE_IncrementQuality_TWOTIMES_DecreaseSellIn(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.AGED_BRIE, sellIn, quality) };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality + 2, items.Single().Quality);
            Assert.Equal(sellIn - 1, items.Single().SellIn);
        }

        [Theory]
        [InlineData(2, 51)]
        [InlineData(-1, 51)]
        public void ShouldUpdateQuality_AGED_BRIE_Quality_Over_50(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.AGED_BRIE, sellIn, quality) };

            var item = items.First();
            Assert.Equal(sellIn, item.SellIn);

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality, items.First().Quality);
            Assert.Equal(sellIn - 1, items.First().SellIn);
        }


        [Theory]
        [InlineData(5, 15)]
        // Quality < 50         => SellIn + 1
        // SellIn < 6 and < 11  => SellIn + 2
        public void ShouldUpdateQuality_BACKSTAGE_TO_TAFKAL80ETC_QUALITY_UNDER_50_SELLIN_UNDER_6_AND_11(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.BACKSTAGE_TO_TAFKAL80ETC, sellIn, quality) };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality + 3, items.Single().Quality);
            Assert.Equal(sellIn - 1, items.Single().SellIn);
        }

        [Theory]
        [InlineData(5, 60)]
        public void ShouldUpdateQuality_BACKSTAGE_TO_TAFKAL80ETC(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.BACKSTAGE_TO_TAFKAL80ETC, sellIn, quality) };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality, items.Single().Quality);
            Assert.Equal(sellIn - 1, items.Single().SellIn);
        }

        [Theory]
        [InlineData(8, 15)]
        public void ShouldUpdateQuality_BACKSTAGE_TO_TAFKAL80ETC_SELLIN_UNDER_11(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.BACKSTAGE_TO_TAFKAL80ETC, sellIn, quality) };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality + 2, items.Single().Quality);
            Assert.Equal(sellIn - 1, items.Single().SellIn);
        }

        [Theory]
        [InlineData(15, 15)]
        public void ShouldUpdateQuality_BACKSTAGE_TO_TAFKAL80ETC_QUALITY_UNDER_50_SELLIN_OVER_11(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.BACKSTAGE_TO_TAFKAL80ETC, sellIn, quality) };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality + 1, items.Single().Quality);
            Assert.Equal(sellIn - 1, items.Single().SellIn);
        }

        [Theory]
        [InlineData(-1, 51)]
        public void ShouldUpdateQuality_BACKSTAGE_TO_TAFKAL80ETC_RESET_QUALITY_WHEN_SELLIN_UNDER_0(int sellIn, int quality)
        {
            var items = new List<Item> {
                new Item(GildedRose.BACKSTAGE_TO_TAFKAL80ETC, sellIn, quality) };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(0, items.Single().Quality);
            Assert.Equal(sellIn - 1, items.Single().SellIn);
        }
    }
}
