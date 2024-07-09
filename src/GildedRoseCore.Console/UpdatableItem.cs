namespace GildedRoseCore.Console
{
    public class UpdatableItem
    {
        public readonly Item item;

        public UpdatableItem(Item item)
        {
            this.item = item;
        }

        public virtual void Update()
        {
            return;
        }
    }

}
