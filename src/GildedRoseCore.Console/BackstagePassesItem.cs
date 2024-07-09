namespace GildedRoseCore.Console
{
    public class BackstagePassesItem : UpdatableItem
    {
        public BackstagePassesItem(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if (item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.Quality < 50 && item.SellIn < 11) item.Quality = item.Quality + 1;
            if (item.Quality < 50 && item.SellIn < 6) item.Quality = item.Quality + 1;
            if (item.SellIn <= 0) item.Quality = item.Quality - item.Quality;
        }
    }

}
