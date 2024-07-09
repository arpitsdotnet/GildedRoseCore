namespace GildedRoseCore.Console
{
    public class ConjuredItem : UpdatableItem
    {
        public ConjuredItem(Item item) : base(item)
        {

        }

        public override void Update()
        {
            item.Quality = item.Quality - 2;
            item.SellIn = item.SellIn - 1;
        }
    }
}
