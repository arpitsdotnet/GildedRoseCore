namespace GildedRoseCore.Console
{
    public class AgedBrieItem : UpdatableItem
    {
        private readonly Item item;

        public AgedBrieItem(Item item)
        {
            this.item = item;
        }

        public override void Update()
        {
            if (item.SellIn < 0 && item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.Quality < 50) item.Quality = item.Quality + 1;
        }
    }
}
