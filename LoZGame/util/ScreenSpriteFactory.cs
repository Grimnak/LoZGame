using LoZClone;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class ScreenSpriteFactory
    {
        private const int DRAWSCALE = 1;
        private static readonly int titleScreenWidth = 800;
        private static readonly int titleScreenHeight = 480;
        private static readonly int enterWidth = 232;
        private static readonly int enterHeight = 44;

        public int TitleScreenWidth
        {
            get { return titleScreenWidth; }
        }

        public int TitleScreenHeight
        {
            get { return titleScreenHeight; }
        }

        public int EnterWidth
        {
            get { return enterWidth; }
        }

        public int EnterHeight
        {
            get { return enterHeight; }
        }

        public static int GetScreenWidth(IScreen screen)
        {
            return titleScreenWidth;
        }

        public static int GetScreenHeight(IScreen screen)
        {
            return titleScreenHeight;
        }

        private Texture2D titleSpriteSheet;
        private SpriteData titleData;
        private Texture2D enterSpriteSheet;
        private SpriteData enterData;

        private static readonly ScreenSpriteFactory InstanceValue = new ScreenSpriteFactory();

        public static ScreenSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        public void LoadAllTextures(ContentManager content)
        {
            this.titleSpriteSheet = content.Load<Texture2D>("LoZTitle");
            titleData = new SpriteData(new Vector2(titleScreenWidth, titleScreenHeight), titleSpriteSheet, 1, 7);
            this.enterSpriteSheet = content.Load<Texture2D>("pressEnter");
            enterData = new SpriteData(new Vector2(enterWidth, enterHeight), enterSpriteSheet, 1, 1);
    }

        public ISprite TitleScreen()
        {
            return new Sprite(this.titleSpriteSheet, this.titleData);
        }

        public ISprite PressEnter()
        {
            return new Sprite(this.enterSpriteSheet, this.enterData);
        }
    }
}
