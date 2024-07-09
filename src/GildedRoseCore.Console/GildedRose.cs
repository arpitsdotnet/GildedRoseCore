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
                CreateUpdatableItem(item).Update();
            }
        }

        public UpdatableItem CreateUpdatableItem(Item item)
        {
            switch (item.Name)
            {
                case Constants.AGED_BRIE: return new AgedBrieItem(item);
                case Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT: return new BackstagePassesItem(item);
                case Constants.SULFURAS_HAND_OF_RAGNAROS: return new SulfurasItem(item);
                default: return new NormalItem(item);
            };
        }
    }

}
