namespace GildedRoseKata;

public static class GildedRoseUpdater
{
    public static void UpdateQualityItem(this Item item)
    {
        if (item.Name == "Aged Brie")
        {
            UpdateAgedBrie(item);
            return;
        }

        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            UpdateBackstagePasses(item);
            return;
        }

        if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
            return;
        }

        UpdateDefault(item);
    }

    private static void UpdateDefault(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }

        item.SellIn--;


        if (item.SellIn < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }

    private static void UpdateBackstagePasses(Item item)
    {
        if (item.SellIn <= 0)
        {
            item.SellIn--;
            item.Quality = 0;
            return;
        }

        if (item.Quality < 50)
        {
            item.Quality++;

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }

        item.SellIn--;

        return;
    }

    private static void UpdateAgedBrie(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }

        item.SellIn--;

        if (item.SellIn < 0)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        return;
    }
}