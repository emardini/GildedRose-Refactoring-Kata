using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void WhenAnItemIsUpdatedThenTheNameDoesNotChange()
    {
        var item = new Item  { Name = "foo", SellIn = 0, Quality = 0 };
        item.UpdateQualityItem();
        item.Name.Should().Be("foo");
    }

    [Theory]
    [InlineData("Aged Brie", 1, 49, 0, 50)]  
    [InlineData("Aged Brie", 0, 49, -1, 50)]
    [InlineData("Aged Brie", 0, 48, -1, 50)]
    [InlineData("Aged Brie", 0, 1, -1, 3)]
    [InlineData("Aged Brie", 0, 50, -1, 50)]
    [InlineData("Aged Brie", 1, 50, 0, 50)]
    [InlineData("Aged Brie", 1, 0, 0, 1)]

    [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 47, -1, 0)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 47, 0, 50)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 47, 9, 49)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 47, 10, 48)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 50, 10, 50)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", -1, 47, -2, 0)]

    [InlineData("Sulfuras, Hand of Ragnaros", -1, 47, -1, 47)]
    [InlineData("Sulfuras, Hand of Ragnaros", -1, -1, -1, -1)]
    [InlineData("Sulfuras, Hand of Ragnaros", 2, 4, 2, 4)]

    [InlineData("Default", 1, 1, 0, 0)]
    [InlineData("Default", 2, 2, 1, 1)]
    [InlineData("Default", 0, 4, -1, 2)]
    [InlineData("Default", 10, 0, 9, 0)]

    public void SellinAndQualityAreProperlyUpdated(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item {Name = name, SellIn = sellIn, Quality = quality } ;

        item.UpdateQualityItem();

        var expectedItem = new Item { Name = name, SellIn=expectedSellIn, Quality = expectedQuality };

        item.Should().BeEquivalentTo(expectedItem);
    }
}