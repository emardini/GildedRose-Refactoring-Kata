using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.ComponentModel;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void Foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(-1, -1)]
    public void WhenItemIsConjuredQualityLessThanTwoThenQualityWontDecrease(int initialQuality, int expectedQuality)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Item 001", SellIn = 0, Quality = initialQuality } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(expectedQuality, Items[0].Quality);
    }

    [Theory]
    [InlineData(2, 0)]
    [InlineData(10, 8)]
    public void WhenItemIsConjuredQualityMoreOrEqualThanTwoThenQualityDecreaseByTwo(int initialQuality, int expectedQuality)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Item 001", SellIn = 0, Quality = initialQuality } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(expectedQuality, Items[0].Quality);
    }


    [Theory]
    [InlineData(-1, -1)]
    [InlineData(0, 0)]
    [InlineData(10, 10)]
    [InlineData(80, 80)]
    public void WhenItemIsSulfurasQualityDoesNotChange(int initialQuality, int expectedQuality)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = initialQuality } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(expectedQuality, Items[0].Quality);
    }

    [Theory]
    [InlineData(-1, -1)]
    [InlineData(0, 0)]
    [InlineData(10, 10)]
    [InlineData(80, 80)]
    public void WhenItemIsSulfurasSellingDoesNotChange(int initialSellin, int expectedSellIn)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = initialSellin, Quality = 10 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(expectedSellIn, Items[0].SellIn);
    }


    [Theory]
    [InlineData(0, 1)]
    [InlineData(-1, 0)]
    [InlineData(-5, -4)]
    [InlineData(49, 50)]
    [InlineData(50, 50)]
    public void WhenItemIsAgedBrieQualityLessThanFiftyAndSellinMoreThanZeroIncreaseByOne(int initialQuality, int expectedQuality )
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = initialQuality } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(expectedQuality, Items[0].Quality);
    }
}