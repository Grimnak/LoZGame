namespace LoZClone
{
    public struct GameStateDataConstants
    {
        private const float doorFloorDepth = 0.02f;

        private const int CloseInventoryTranSpeed = 5;

        private const int DeathTimerMaximum = 85;
        private const int GameOverT = 500;

        private const int OpenInventoryLO = -174;
        private const int OpenInventoryTranSpeed = 5;

        private const int TitleFrameDelay = 10;
        private const int TitleDrawXValue = 284;

        private const int WinGameStMaxDungeons = 3;
        private const int WinGameStMaxLO = 440;
        private const int WinStSpriteWidth = 236;
        private const int WinStSpriteHeight = 160;

        private const int playerTransitionMaxDistance = 200;

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

        public int TransitionRoomStateTransitionTime => 2 * LoZGame.Instance.UpdateSpeed;

        public int WinStateMaxDungeons => WinGameStMaxDungeons;

        public int WinStateMaxLockout => WinGameStMaxLO;

        public int WinStateSpriteWidth => WinStSpriteWidth;

        public int WinStateSpriteHeight => WinStSpriteHeight;

        public float DoorFloorDepth => doorFloorDepth;

        public int PlayerTransitionMaxDistance => playerTransitionMaxDistance;
    }
}
