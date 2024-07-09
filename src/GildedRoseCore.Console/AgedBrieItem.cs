namespace GildedRoseCore.Console
{
    public class AgedBrieItem : UpdatableItem
    {
        public AgedBrieItem(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if (item.SellIn < 0 && item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.Quality < 50) item.Quality = item.Quality + 1;
        }
    }
}
