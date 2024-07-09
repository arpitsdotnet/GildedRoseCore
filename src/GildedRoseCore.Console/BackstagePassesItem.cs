namespace GildedRoseCore.Console
{
    public class BackstagePassesItem
    {
        private readonly Item item;

        public BackstagePassesItem(Item item)
        {
            this.item = item;
        }

        public void Update()
        {
            if (item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.Quality < 50 && item.SellIn < 11) item.Quality = item.Quality + 1;
            if (item.Quality < 50 && item.SellIn < 6) item.Quality = item.Quality + 1;
            if (item.SellIn <= 0) item.Quality = item.Quality - item.Quality;
        }
    }

}
