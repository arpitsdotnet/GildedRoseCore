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

            foreach (var item in _items)
            {
                if (item.Name == Constants.AGED_BRIE) AgedBrieUpdate(item);
                else if (item.Name == Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT) BackstagePassesUpdate(item);
                else if (item.Name == Constants.SULFURAS_HAND_OF_RAGNAROS) SulfurasUpdate(item);
                else NormalUpdate(item);
            }
        }

        public void BackstagePassesUpdate(Item item)
        {
            if (item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.Quality < 50 && item.SellIn < 11) item.Quality = item.Quality + 1;
            if (item.Quality < 50 && item.SellIn < 6) item.Quality = item.Quality + 1;
            if (item.SellIn <= 0) item.Quality = item.Quality - item.Quality;
        }

        public void AgedBrieUpdate(Item item)
        {
            new AgedBrieItem(item).Update();
        }

        public void SulfurasUpdate(Item item)
        {
        }

        public void NormalUpdate(Item item)
        {
            if (item.Quality > 0) item.Quality = item.Quality - 1;
            item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0 && item.Quality > 0) item.Quality = item.Quality - 1;
        }
    }
}
