using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCore.Console
{
    public class GildedRose
    {
        private readonly IList<Item> _items = new List<Item>();

        public GildedRose(List<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            //2. Constants Variables for Numbers
            const int MAX_QUALITY = 50;

            foreach (var item in _items)
            {
                if (item.Name != Constants.AGED_BRIE && item.Name != Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Constants.SULFURAS_HAND_OF_RAGNAROS)
                            item.Quality = item.Quality - 1;
                    }
                }
                else if (item.Quality < MAX_QUALITY)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT)
                    {
                        if (item.SellIn < 11)
                            item.Quality = item.Quality + 1;

                        if (item.SellIn < 6)
                            item.Quality = item.Quality + 1;
                    }
                }

                if (item.Name != Constants.SULFURAS_HAND_OF_RAGNAROS)
                    item.SellIn = item.SellIn - 1;

                if (item.SellIn < 0)
                {
                    if (item.Name != Constants.AGED_BRIE)
                    {
                        if (item.Name != Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT)
                        {
                            if (item.Quality > 0 && item.Name != Constants.SULFURAS_HAND_OF_RAGNAROS)
                                item.Quality = item.Quality - 1;
                        }
                        else
                            item.Quality = item.Quality - item.Quality;
                    }
                    else if (item.Quality < MAX_QUALITY)
                        item.Quality = item.Quality + 1;
                }
            }
        }
    }
}
