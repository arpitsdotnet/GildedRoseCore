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
            new BackstagePassesItem(item).Update();
        }

        public void AgedBrieUpdate(Item item)
        {
            new AgedBrieItem(item).Update();
        }

        public void SulfurasUpdate(Item item)
        {
            new SulfurasItem(item).Update();
        }

        public void NormalUpdate(Item item)
        {
            new NormalItem(item).Update();
        }
    }

}
