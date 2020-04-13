namespace LoZClone
{
    public struct EnemyMiscConstants
    {
        private const int MinDirectionChng = 60;
        private const int MaxDirectionChng = 180;
        private const int DirectionChng = 40;
        private const int DeathTimerMax = 30;
        private const int FireSnakeLgth = 5;
        private const int LinkPixelBuff = 5;
        private const int DodongoMaxFrame = 2;
        private const int KeeseIdleMax = 5;
        private const int GelIdleMin = 18;
        private const int GelIdleMax = 30;
        private const int GelMovementT = 17;
        private const int ZolMaxWait = 12;

        public int FireSnakeLength => FireSnakeLgth;

        public int MaxDirectionChange => MaxDirectionChng;

        public int MinDirectionChange => MinDirectionChng;

        public int LinkPixelBuffer => LinkPixelBuff;

        public int DirectionChange => DirectionChng;

        public int DeathTimerMaximum => DeathTimerMax;

        public int DodongoMaximumFrame => DodongoMaxFrame;

        public int KeeseIdleMaximum => KeeseIdleMax;

        public int GelMinIdle => GelIdleMin;

        public int GelMaxIdle => GelIdleMax;

        public int GelMovementTime => GelMovementT;

        public int ZolMaximumWait => ZolMaxWait;

        public double SpikeCrossVertBoundary => (BlockSpriteFactory.Instance.TileHeight * 3.5) + (BlockSpriteFactory.Instance.TopOffset / 2) + (LoZGame.Instance.InventoryOffset / 2);

        public double SpikeCrossHorizontalBoundary => (BlockSpriteFactory.Instance.TileWidth * 6) + (BlockSpriteFactory.Instance.HorizontalOffset / 2);
    }
}