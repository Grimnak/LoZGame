namespace LoZClone
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
        private Texture2D gameOverSpriteSheet;
        private SpriteData gameOverData;
        private Texture2D pauseScreenSprite;
        private Texture2D creditsSpriteSheet;
        private Texture2D optionsSpriteSheet;
        private SpriteData optionsData;
        private Texture2D profilesSpriteSheet;
        private SpriteData profilesData;

        private static readonly ScreenSpriteFactory InstanceValue = new ScreenSpriteFactory();

        public static ScreenSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        public void LoadAllTextures(ContentManager content)
        {
            titleSpriteSheet = content.Load<Texture2D>("LoZTitle");
            titleData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), titleSpriteSheet, 1, 7);
            enterSpriteSheet = content.Load<Texture2D>("pressEnter");
            enterData = new SpriteData(new Vector2(enterWidth, enterHeight), enterSpriteSheet, 1, 1);
            gameOverSpriteSheet = content.Load<Texture2D>("gameOver");
            pauseScreenSprite = content.Load<Texture2D>("PauseMenu");
            creditsSpriteSheet = content.Load<Texture2D>("Credits");
            optionsSpriteSheet = content.Load<Texture2D>("Options");
            profilesSpriteSheet = content.Load<Texture2D>("profileSelection");
            optionsData = new SpriteData(new Vector2(GameData.Instance.GameStateDataConstants.OptionsWindowWidth, GameData.Instance.GameStateDataConstants.OptionsWindowHeight), optionsSpriteSheet, 1, 1);
            profilesData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), profilesSpriteSheet, 1, 1);
            gameOverData = new SpriteData(new Vector2(LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight), gameOverSpriteSheet, 1, 1);
    }

        public ISprite TitleScreen()
        {
            return new ObjectSprite(titleSpriteSheet, titleData);
        }

        public ISprite PressEnter()
        {
            return new ObjectSprite(enterSpriteSheet, enterData);
        }

        public ISprite PauseScreen()
        {
            return new ObjectSprite(pauseScreenSprite, gameOverData);
        }

        public ISprite CreditsScreen()
        {
            return new ObjectSprite(creditsSpriteSheet, gameOverData);
        }

        public ISprite OptionsScreen()
        {
            return new ObjectSprite(optionsSpriteSheet, optionsData);
        }

        public ISprite ProfilesScreen()
        {
            return new ObjectSprite(profilesSpriteSheet, profilesData);
        }

        public ISprite GameOverScreen()
        {
            return new ObjectSprite(gameOverSpriteSheet, gameOverData);
        }
    }
}