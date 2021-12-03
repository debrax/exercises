namespace GildedRose.ItemUpdate
{
    internal abstract class GildedRoseItem
    {
        protected readonly Item item;

        protected GildedRoseItem(Item item)
        {
            this.item = item;
        }

        public abstract void Update();

        protected void DecreaseSellIn() => item.SellIn--;

        protected void IncreaseValue()
        {
            if (item.Quality < 50)
                item.Quality++;
        }

        protected void DecreaseQuality()
        {
            if (item.Quality > 0)
                item.Quality--;
        }

        protected bool IsExpired() => item.SellIn < 0;
    }

    internal class AgedBrie : GildedRoseItem
    {
        public AgedBrie(Item item) : base(item) { }

        public override void Update()
        {
            DecreaseSellIn();
            IncreaseValue();

            if (IsExpired())
                IncreaseValue();
        }
    }

    internal class BackstagePasses : GildedRoseItem
    {
        public BackstagePasses(Item item) : base(item) { }

        public override void Update()
        {
            DecreaseSellIn();
            IncreaseValue();

            if (IsExpiredWithinDays(10))
                IncreaseValue();

            if (IsExpiredWithinDays(5))
                IncreaseValue();

            if (IsExpired())
                ResetQuality();
        }

        private bool IsExpiredWithinDays(int days) => item.SellIn < days;
        private void ResetQuality() => item.Quality = 0;
    }

    internal class Sulfuras : GildedRoseItem
    {
        public Sulfuras(Item item) : base(item) { }

        public override void Update() { }
    }

    internal class ConjuredItem : GildedRoseItem
    {
        public ConjuredItem(Item item) : base(item) { }

        public override void Update()
        {
            DecreaseSellIn();
            DecreaseQuality();
            DecreaseQuality();

            if (IsExpired())
            {
                DecreaseQuality();
                DecreaseQuality();
            }
        }
    }

    internal class DefaultItem : GildedRoseItem
    {
        public DefaultItem(Item item) : base(item) { }

        public override void Update()
        {
            DecreaseSellIn();
            DecreaseQuality();

            if (IsExpired())
                DecreaseQuality();
        }
    }
}