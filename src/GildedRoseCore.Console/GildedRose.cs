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
                        {
                            DecreaseQualityByOne(item);
                        }
                    }
                }
                else
                {
                    if (item.Quality < MAX_QUALITY)
                    {
                        IncreaseQualityByOne(item);

                        if (item.Name == Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < MAX_QUALITY)
                                {
                                    IncreaseQualityByOne(item);
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < MAX_QUALITY)
                                {
                                    IncreaseQualityByOne(item);
                                }
                            }
                        }
                    }
                }

                if (item.Name != Constants.SULFURAS_HAND_OF_RAGNAROS)
                {
                    DecreaseSellInByOne(item);
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != Constants.AGED_BRIE)
                    {
                        if (item.Name != Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != Constants.SULFURAS_HAND_OF_RAGNAROS)
                                {
                                    DecreaseQualityByOne(item);
                                }
                            }
                        }
                        else
                        {
                            DecreaseQualityByQuality(item);
                        }
                    }
                    else
                    {
                        if (item.Quality < MAX_QUALITY)
                        {
                            IncreaseQualityByOne(item);
                        }
                    }
                }
            }
        }

        private void DecreaseQualityByQuality(Item item)
        {
            item.Quality = item.Quality - item.Quality;
        }

        private void DecreaseSellInByOne(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private void DecreaseQualityByOne(Item item)
        {
            item.Quality = item.Quality - 1;
        }

        private void IncreaseQualityByOne(Item item)
        {
            item.Quality = item.Quality + 1;
        }
    }
}
