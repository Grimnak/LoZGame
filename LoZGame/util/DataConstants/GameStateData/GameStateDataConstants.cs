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

        private const int TriforceGameStMaxDungeons = 9;
        private const int TriforceGameStMaxLO = 430;
        private const int TriforceStSpriteWidth = 236;
        private const int TriforceStSpriteHeight = 160;

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
        private const int profilesSelectorX = 225;
        private const int profiles1SelectorY = 235;
        private const int profiles2SelectorY = 370;
        private const int profiles3SelectorY = 510;
        private const int profilesDungeonTextX = 550;
        private const int profiles1DungeonTextY = 235;
        private const int profiles2DungeonTextY = 370;
        private const int profiles3DungeonTextY = 510;

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

        public int TriforceStateMaxDungeons => TriforceGameStMaxDungeons;

        public int TriforceStateMaxLockout => TriforceGameStMaxLO;

        public int TriforceStateSpriteWidth => TriforceStSpriteWidth;

        public int TriforceStateSpriteHeight => TriforceStSpriteHeight;

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

        public int ProfilesSelectorX => profilesSelectorX;

        public int Profiles1SelectorY => profiles1SelectorY;

        public int Profiles2SelectorY => profiles2SelectorY;

        public int Profiles3SelectorY => profiles3SelectorY;

        public int ProfilesDungeonTextX => profilesDungeonTextX;

        public int Profiles1DungeonTextY => profiles1DungeonTextY;

        public int Profiles2DungeonTextY => profiles2DungeonTextY;

        public int Profiles3DungeonTextY => profiles3DungeonTextY;
    }
}
