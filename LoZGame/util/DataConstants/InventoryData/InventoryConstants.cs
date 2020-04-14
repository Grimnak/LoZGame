namespace LoZClone
{
    public struct InventoryConstants
    {
        private const int MaxBombs = 8;
        private const int MaxSelectionX = 4;
        private const int MaxSelectionY = 2;
        private const int ClockLockoutMax = 600;
        private const int HeartClms = 8;
        private const int InvClms = 4;
        private const int InvSelectionItems = 8;
        private const int ItemSelectOffset = 5;
        private const int HPPerHeart = 4;

        public int MaximumBombs => MaxBombs;

        public int MaximumSelectionX => MaxSelectionX;

        public int MaximumSelectionY => MaxSelectionY;

        public int ClockLockoutMaximum => ClockLockoutMax;

        public int HeartColumns => HeartClms;

        public int InventorySelectionItems => InvSelectionItems;

        public int ItemSelectorOffset => ItemSelectOffset;

        public int InventoryColumns => InvClms;

        public int HealthPerHeart => HPPerHeart;
    }
}
