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

        private const float VireGrav = .2f;
        private const float PolsVoiceGrav = .075f;

        private const int snakeUpdateTime = 10;
        private const int swordBeamSuccessRate = 20;

        private const int BubbleFavorCardinal = 2;
        private const int DodongoFavorCardinal = 5;
        private const int FireSnakeFavorCardinal = 3;
        private const int FireSnakeFavorDiagonal = 3;
        private const int DigDoggerFavorCardinal = 9;
        private const int DigDoggerFavorDiagonal = 9;
        private const int GelFavorCardinal = 3;
        private const int GoriyaFavorCardinal = 2;
        private const int KeeseFavorCardinal = 3;
        private const int KeeseFavorDiagonal = 3;
        private const int RopeFavorCardinal = 2;
        private const int StalfosFavorCardinal = 3;
        private const int WallMasterFavorCardinal = 3;
        private const int WizzrobeFavorCardinal = 2;
        private const int ZolFavorCardinal = 3;
        private const int DarknutFavorCardinal = 3;
        private const int VireFavorCardinal = 3;
        private const int LikelikeFavorCardinal = 3;
        private const int PolsVoiceFavorCardinal = 3;

        private const int NrmlMiniPatraOffset = 110;

        public int FireSnakeLength => FireSnakeLgth;

        public int MaxDirectionChange => MaxDirectionChng;

        public int MinDirectionChange => MinDirectionChng;

        public int LinkPixelBuffer => LinkPixelBuff;

        public int DirectionChange => DirectionChng;

        public int DeathTimerMaximum => DeathTimerMax;

        public int SpawnTimerMaximum => SpawnTimerMax;

        public int DodongoMaximumFrame => DodongoMaxFrame;

        public float VireGravity => VireGrav;

        public float PolsVoiceGravity => PolsVoiceGrav;

        public int BubbleFavorCardinalValue => BubbleFavorCardinal;

        public int DodongoFavorCardinalValue => DodongoFavorCardinal;

        public int FireSnakeFavorCardinalValue => FireSnakeFavorCardinal;

        public int FireSnakeFavorDiagonalValue => FireSnakeFavorDiagonal;

        public int DigDoggerFavorCardinalValue => DigDoggerFavorCardinal;

        public int DigDoggerFavorDiagonalValue => DigDoggerFavorDiagonal;

        public int GelFavorCardinalValue => GelFavorCardinal;

        public int GoriyaFavorCardinalValue => GoriyaFavorCardinal;

        public int KeeseFavorCardinalValue => KeeseFavorCardinal;

        public int KeeseFavorDiagonalValue => KeeseFavorDiagonal;

        public int RopeFavorCardinalValue => RopeFavorCardinal;

        public int StalfosFavorCardinalValue => StalfosFavorCardinal;

        public int WallMasterFavorCardinalValue => WallMasterFavorCardinal;

        public int WizzrobeFavorCardinalValue => WizzrobeFavorCardinal;

        public int ZolFavorCardinalValue => ZolFavorCardinal;

        public int DarknutFavorCardinalValue => DarknutFavorCardinal;

        public int VireFavorCardinalValue => VireFavorCardinal;

        public int UpdateSegmentTime => snakeUpdateTime;

        public int ProjectileSuccess => swordBeamSuccessRate;

        public int LikelikeFavorCardinalValue => LikelikeFavorCardinal;

        public int PolsVoiceFavorCardinalValue => PolsVoiceFavorCardinal;

        public int NormalMiniPatraOffset => NrmlMiniPatraOffset;

    }
}