using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose(IList<Item> Items)
{
    readonly IList<Item> Items = Items;

    public void UpdateQuality()
    {
        Items.AsParallel().ForAll(GildedRoseUpdater.UpdateQualityItem);
    }
}