using Microsoft.Xna.Framework;

namespace LoZClone
{
    public struct GameStateDataConstants
    {
        private const float doorFloorDepth = 0.02f;

        private const int CloseInventoryTranSpeed = 5;
        private const int MaxCreditsTime = 10980;
        private const int DeathTimerMaximum = 85;
        private const int GameOverT = 500;

        private const int OpenInventoryLO = -174;
        private const int OpenInventoryTranSpeed = 5;

        private const int TitleFrameDelay = 10;
        private const int TitleDrawXValue = 284;

        private const int WinGameStMaxDungeons = 8;
        private const int WinGameStMaxLO = 440;
        private const int WinStSpriteWidth = 236;
        private const int WinStSpriteHeight = 160;

        private const int optionsWindowHeight = 350;
        private const int optionsWindowWidth = 430;
        private const int optionsHeightOffset = 225;
        private const int optionsWidthOffset = 185;
        private const int optionsTextWidthOffset = 10;
        private const int optionsTextX = 380;
        private const int optionsDifficultyY = 327;
        private const int optionsCheatsY = 385;
        private const int optionsDebugY = 443;
        private const int optionsMusicY = 501;
        private const int optionsTextLeading = 58; // What is Leading? https://techterms.com/definition/leading
        private const int optionsSelectorY = 325;

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

        public int OptionsWindowHeight => optionsWindowHeight;

        public int OptionsWindowWidth => optionsWindowWidth;

        public int OptionsHeightOffset => optionsHeightOffset;

        public int OptionsWidthOffset => optionsWidthOffset;

        public int OptionsDifficultyY => optionsDifficultyY;

        public int OptionsSelectorY => optionsSelectorY;

        public int OptionsTextLeading => optionsTextLeading;

        public int OptionsCheatsY => optionsCheatsY;

        public int OptionsDebugY => optionsDebugY;

        public int OptionsMusicY => optionsMusicY;

        public int OptionsTextX => optionsTextX;

        public float DoorFloorDepth => doorFloorDepth;

        public int PlayerTransitionMaxDistance => playerTransitionMaxDistance;

        public int CreditsMAX => MaxCreditsTime;
    }
}
