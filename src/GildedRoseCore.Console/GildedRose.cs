using System;
using System.Collections.Generic;
using System.Linq;
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

        public Dictionary<string, Func<Item, UpdatableItem>> UpdatableItemsTable = new Dictionary<string, Func<Item, UpdatableItem>>
        {
            { Constants.AGED_BRIE , (item)=> new AgedBrieItem(item) },
            { Constants.BACKSTAGE_PASSES_TO_A_TAFKAL80ETC_CONCERT , (item)=> new BackstagePassesItem(item) },
            { Constants.SULFURAS_HAND_OF_RAGNAROS , (item)=> new SulfurasItem(item) },
            { Constants.DEFAULT , (item)=> new NormalItem(item) }
        };

        public UpdatableItem CreateUpdatableItem(Item item)
        {
            return UpdatableItemsTable.First((kvp) => (kvp.Key.Equals(item.Name) || kvp.Key.Equals(Constants.DEFAULT))).Value(item);
        }
    }

}
