namespace GildedRoseCore.Console
{
    public class NormalItem : UpdatableItem
    {
        private readonly Item item;

        public NormalItem(Item item)
        {
            this.item = item;
        }

        public override void Update()
        {
            if (item.Quality > 0) item.Quality = item.Quality - 1;
            item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0 && item.Quality > 0) item.Quality = item.Quality - 1;
        }
    }

}
