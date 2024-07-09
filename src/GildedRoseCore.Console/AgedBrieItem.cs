namespace GildedRoseCore.Console
{
    public class AgedBrieItem
    {
        private readonly Item item;

        public AgedBrieItem(Item item)
        {
            this.item = item;
        }

        public void Update()
        {
            if (item.SellIn < 0 && item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.Quality < 50) item.Quality = item.Quality + 1;
        }
}
}
