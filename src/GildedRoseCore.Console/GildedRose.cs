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
                switch (item.Name)
                {
                    case Constants.AGED_BRIE: new AgedBrieItem(item).Update(); break;
                    case Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT: new BackstagePassesItem(item).Update(); break;
                    case Constants.SULFURAS_HAND_OF_RAGNAROS: new SulfurasItem(item).Update(); break;
                    default: new NormalItem(item).Update(); break;
                };
            }
        }
    }

}
