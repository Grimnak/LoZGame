﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TurquoiseStatueRightSprite : ISprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows;
        private readonly int spriteSheetColumns;
        private readonly int spriteWidth;
        private readonly int spriteHeight;
        private readonly int currentFrame = 1;

        public Vector2 Location { get; set; }

        public TurquoiseStatueRightSprite(Texture2D spriteTexture, Vector2 loc, SpriteSheetData data)
        {
            this.spriteSheet = spriteTexture;
            this.spriteWidth = data.Width;
            this.spriteHeight = data.Height;
            this.Location = loc;

            this.spriteSheetRows = data.Rows;
            this.spriteSheetColumns = data.Columns;
        }

        public void Update()
        {
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int column = (int)((float)this.currentFrame / (float)this.spriteSheetRows);

            Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, this.spriteWidth, this.spriteHeight);

            LoZGame.Instance.SpriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}