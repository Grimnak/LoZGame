namespace LoZClone
{
    public struct EnemyMiscConstants
    {
        private const int MinDirectionChng = 60;
        private const int MaxDirectionChng = 180;
        private const int DirectionChng = 40;
        private const int DeathTimerMax = 30;
        private const int SpawnTimerMax = 15;
        private const int FireSnakeLgth = 5;
        private const int LinkPixelBuff = 5;
        private const int DodongoMaxFrame = 2;
        private const int KeeseIdleMax = 5;
        private const int GelIdleMin = 18;
        private const int GelIdleMax = 30;
        private const int GelMovementT = 17;
        private const int ZolIdleMin = 18;
        private const int ZolIdleMax = 30;
        private const int ZolMovementT = 17;

        private const int snakeUpdateTime = 10;
        private const int swordBeamSuccessRate = 20;

        private const int DodongoFavorCardinal = 5;
        private const int FireSnakeFavorCardinal = 9;
        private const int FireSnakeFavorDiagonal = 9;
        private const int GelFavorCardinal = 3;
        private const int GoriyaFavorCardinal = 2;
        private const int KeeseFavorCardinal = 3;
        private const int KeeseFavorDiagonal = 3;
        private const int RopeFavorCardinal = 2;
        private const int StalfosFavorCardinal = 3;
        private const int WallMasterFavorCardinal = 3;
        private const int ZolFavorCardinal = 3;
        private const int DarknutFavorCardinal = 3;
        private const int VireFavorCardinal = 5;
        private const int LikelikeFavorCardinal = 5;

        public int FireSnakeLength => FireSnakeLgth;

        public int MaxDirectionChange => MaxDirectionChng;

        public int MinDirectionChange => MinDirectionChng;

        public int LinkPixelBuffer => LinkPixelBuff;

        public int DirectionChange => DirectionChng;

        public int DeathTimerMaximum => DeathTimerMax;

        public int SpawnTimerMaximum => SpawnTimerMax;

        public int DodongoMaximumFrame => DodongoMaxFrame;

        public int KeeseIdleMaximum => KeeseIdleMax;

        public int GelMinIdle => GelIdleMin;

        public int GelMaxIdle => GelIdleMax;

        public int GelMovementTime => GelMovementT;

        public int ZolMinIdle => ZolIdleMin;

        public int ZolMaxIdle => ZolIdleMax;

        public int ZolMovementTime => ZolMovementT;

        public int DodongoFavorCardinalValue => DodongoFavorCardinal;

        public int FireSnakeFavorCardinalValue => FireSnakeFavorCardinal;

        public int FireSnakeFavorDiagonalValue => FireSnakeFavorDiagonal;

        public int GelFavorCardinalValue => GelFavorCardinal;

        public int GoriyaFavorCardinalValue => GoriyaFavorCardinal;

        public int KeeseFavorCardinalValue => KeeseFavorCardinal;

        public int KeeseFavorDiagonalValue => KeeseFavorDiagonal;

        public int RopeFavorCardinalValue => RopeFavorCardinal;

        public int StalfosFavorCardinalValue => StalfosFavorCardinal;

        public int WallMasterFavorCardinalValue => WallMasterFavorCardinal;

        public int ZolFavorCardinalValue => ZolFavorCardinal;

        public int DarknutFavorCardinalValue => DarknutFavorCardinal;

        public int VireFavorCardinalValue => VireFavorCardinal;

        public double SpikeCrossVertBoundary => (BlockSpriteFactory.Instance.TileHeight * 3.5) + (BlockSpriteFactory.Instance.TopOffset / 2) + (LoZGame.Instance.InventoryOffset / 2);

        public double SpikeCrossHorizontalBoundary => (BlockSpriteFactory.Instance.TileWidth * 6) + (BlockSpriteFactory.Instance.HorizontalOffset / 2);

        public int UpdateSegmentTime => snakeUpdateTime;

        public int ProjectileSuccess => swordBeamSuccessRate;

        public int LikelikeFavorCardinalValue => LikelikeFavorCardinal;
    }
}