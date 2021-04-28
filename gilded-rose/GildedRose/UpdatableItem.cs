namespace GildedRose
{
    // Decorator of item for encapsulation
    public class UpdatableItem
    {
        private readonly Item _item;

        public UpdatableItem(Item item)
        {
            _item = item;
        }

        public void DecreaseSellIn()
        {
            _item.SellIn--;
        }

        public void IncreaseQuality()
        {
            if (_item.Quality < 50)
                _item.Quality++;
        }

        public void ResetQuality()
        {
            _item.Quality = 0;
        }

        public void DecreaseQuality()
        {
            if (_item.Quality > 0)
                _item.Quality--;
        }

        public int SellIn() => _item.SellIn;

        public bool IsSellDateWithinDays(int days) => _item.SellIn <= days;

        public bool IsSellDatePassed() => _item.SellIn < 0;
    }
}