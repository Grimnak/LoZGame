using LoZClone.Interfaces;
using LoZClone.Sprites.Sc;
using LoZClone.Sprites.ScreenSpriteClasses;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class ScreenSpriteFactory
    {
        private const int DRAWSCALE = 1;
        private static readonly int titleScreenWidth = 800;
        private static readonly int titleScreenHeight = 480;

        public int TitleScreenWidth
        {
            get { return titleScreenWidth; }
        }

        public int TitleScreenHeight
        {
            get { return titleScreenHeight; }
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
        private readonly SpriteSheetData titleData = new SpriteSheetData("LoZTitle", titleScreenWidth, titleScreenHeight, 1, 7);

        private static readonly ScreenSpriteFactory InstanceValue = new ScreenSpriteFactory();

        public static ScreenSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        public void LoadAllTextures(ContentManager content)
        {
            this.titleSpriteSheet = content.Load<Texture2D>(this.titleData.FilePath);
        }

        public TitleSprite TitleScreen()
        {
            return new TitleSprite(this.titleSpriteSheet, this.titleData, DRAWSCALE);
        }
    }
}
