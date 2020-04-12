﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenSpriteFactory
    {
        private const int DRAWSCALE = 1;
        private static readonly int enterWidth = 232;
        private static readonly int enterHeight = 44;

        public int EnterWidth => enterWidth;

        public int EnterHeight => enterHeight;

        private Texture2D titleSpriteSheet;
        private SpriteData titleData;
        private Texture2D enterSpriteSheet;
        private SpriteData enterData;
        private Texture2D levelOneMasterSpriteSheet;
        private Texture2D levelTwoMasterSpriteSheet;
        private Texture2D inventorySpriteSheet;
        private SpriteData inventoryData;
        private Texture2D gameOverSpriteSheet;
        private SpriteData gameOverData;

        private static readonly ScreenSpriteFactory InstanceValue = new ScreenSpriteFactory();

        public static ScreenSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        public void LoadAllTextures(ContentManager content)
        {
            this.titleSpriteSheet = content.Load<Texture2D>("LoZTitle");
            this.titleData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), titleSpriteSheet, 1, 7);
            this.enterSpriteSheet = content.Load<Texture2D>("pressEnter");
            this.enterData = new SpriteData(new Vector2(enterWidth, enterHeight), enterSpriteSheet, 1, 1);
            this.levelOneMasterSpriteSheet = content.Load<Texture2D>("level-1");
            this.levelTwoMasterSpriteSheet = content.Load<Texture2D>("level-2");
            this.inventorySpriteSheet = content.Load<Texture2D>("Inventory");
            this.inventoryData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), inventorySpriteSheet, 1, 1);
            this.gameOverSpriteSheet = content.Load<Texture2D>("gameOver");
            this.gameOverData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), gameOverSpriteSheet, 1, 1);
    }

        public ISprite TitleScreen()
        {
            return new ObjectSprite(this.titleSpriteSheet, this.titleData);
        }

        public ISprite PressEnter()
        {
            return new ObjectSprite(this.enterSpriteSheet, this.enterData);
        }

        public LevelMasterSprite CreateLevelOneMaster()
        {
            return new LevelMasterSprite(this.levelOneMasterSpriteSheet, new Vector2(LoZGame.Instance.Dungeon.CurrentRoomX, LoZGame.Instance.Dungeon.CurrentRoomY));
        }

        public LevelMasterSprite CreateLevelTwoMaster()
        {
            return new LevelMasterSprite(this.levelTwoMasterSpriteSheet, new Vector2(LoZGame.Instance.Dungeon.CurrentRoomX, LoZGame.Instance.Dungeon.CurrentRoomY));

        }

        public ISprite GameOverScreen()
        {
            return new ObjectSprite(this.gameOverSpriteSheet, this.gameOverData);
        }
    }
}