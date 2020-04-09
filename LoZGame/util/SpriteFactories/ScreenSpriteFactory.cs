namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenSpriteFactory
    {
        private const int DRAWSCALE = 1;
        private static readonly int screenWidth = screenWidth;
        private static readonly int screenHeight = LoZGame.Instance.GraphicsDevice.Viewport.Height;
        private static readonly int enterWidth = 232;
        private static readonly int enterHeight = 44;

        public int TitleScreenWidth => screenWidth;

        public int TitleScreenHeight => screenHeight;

        public int EnterWidth => enterWidth;

        public int EnterHeight => enterHeight;

        public static int GetScreenWidth(IScreen screen)
        {
            return screenWidth;
        }

        public static int GetScreenHeight(IScreen screen)
        {
            return screenHeight;
        }

        private Texture2D titleSpriteSheet;
        private SpriteData titleData;
        private Texture2D enterSpriteSheet;
        private SpriteData enterData;
        private Texture2D levelOneMasterSpriteSheet;

        private static readonly ScreenSpriteFactory InstanceValue = new ScreenSpriteFactory();

        public static ScreenSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        public void LoadAllTextures(ContentManager content)
        {
            this.titleSpriteSheet = content.Load<Texture2D>("LoZTitle");
            this.titleData = new SpriteData(new Vector2(screenWidth, screenHeight), titleSpriteSheet, 1, 7);
            this.enterSpriteSheet = content.Load<Texture2D>("pressEnter");
            this.enterData = new SpriteData(new Vector2(enterWidth, enterHeight), enterSpriteSheet, 1, 1);
            this.levelOneMasterSpriteSheet = content.Load<Texture2D>("LevelOneMaster");
    }

        public ISprite TitleScreen()
        {
            return new ObjectSprite(this.titleSpriteSheet, this.titleData);
        }

        public ISprite PressEnter()
        {
            return new ObjectSprite(this.enterSpriteSheet, this.enterData);
        }

        public LevelOneMasterSprite CreateLevelOneMaster()
        {
            return new LevelOneMasterSprite(this.levelOneMasterSpriteSheet, new Vector2(LoZGame.Instance.Dungeon.CurrentRoomX, LoZGame.Instance.Dungeon.CurrentRoomY));
        }

        public ISprite CreateInventory()
        {
            return new ObjectSprite(this.titleSpriteSheet, this.titleData);
        }
    }
}