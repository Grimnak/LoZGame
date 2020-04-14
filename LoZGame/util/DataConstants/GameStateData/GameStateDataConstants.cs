namespace LoZClone
{
    public struct GameStateDataConstants
    {
        private const int CloseInventoryTranSpeed = 5;

        private const int DeathTimerMaximum = 85;
        private const int GameOverT = 500;

        private const int OpenInventoryLO = -174;
        private const int OpenInventoryTranSpeed = 5;

        private const int TitleFrameDelay = 10;
        private const int TitleDrawXValue = 284;

        private const int TransitionRoomStTranSpeed = 8;

        private const int WinGameStMaxDungeons = 3;
        private const int WinGameStMaxLO = 440;
        private const int WinStSpriteWidth = 236;
        private const int WinStSpriteHeight = 160;

        public int CloseInventoryTransitionSpeed => CloseInventoryTranSpeed;

        public int DeathTimeMax => DeathTimerMaximum;

        public int GameOverTime => GameOverT;

        public int OpenInventoryLockout => OpenInventoryLO;

        public int OpenInventoryTransitionSpeed => OpenInventoryTranSpeed;

        public int TitleScreenFrameDelay => TitleFrameDelay;

        public double HorizontalHalfDungeon => BlockSpriteFactory.Instance.TileWidth * 5.5;

        public double VerticalHalfDungeon => BlockSpriteFactory.Instance.TileHeight * 6;

        public int TitleDrawX => TitleDrawXValue;

        public int TitleDrawY => LoZGame.Instance.InventoryOffset + 300;

        public int TransitionRoomStateTransitionSpeed => TransitionRoomStTranSpeed;

        public int WinStateMaxDungeons => WinGameStMaxDungeons;

        public int WinStateMaxLockout => WinGameStMaxLO;

        public int WinStateSpriteWidth => WinStSpriteWidth;

        public int WinStateSpriteHeight => WinStSpriteHeight;
    }
}
