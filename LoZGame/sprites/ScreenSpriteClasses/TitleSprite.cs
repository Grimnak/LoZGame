using LoZClone.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone.Sprites.ScreenSpriteClasses
{
    internal class TitleSprite : ISprite
    {
        private readonly Texture2D Texture;
        private readonly SpriteSheetData Data;
        private Rectangle frame;
        private readonly int scale;
        private float layer;
        private Vector2 Size;
        private int frameDelay;
        private int frameDelayMax = 5;
        private int currentFrame;

        public TitleSprite(Texture2D texture, SpriteSheetData data, int scale)
        {
            this.Texture = texture;
            this.Data = data;
            this.scale = scale;
            this.frameDelay = 0;
            this.currentFrame = 0;
        }

        public void Update()
        {
            this.frameDelay++;
            if (this.frameDelay == this.frameDelayMax)
            {
                this.currentFrame++;
                if (this.currentFrame > 7)
                {
                    this.currentFrame = 0;
                }
                this.frameDelay = 0;
            }
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            int width = this.Data.Width / this.Data.Columns;
            int height = this.Data.Height / this.Data.Rows;
            int row = (int)((float)this.currentFrame / (float)this.Data.Columns);
            int column = this.currentFrame % this.Data.Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, this.Data.Width, this.Data.Height);
            this.layer = 1 - (1 / (location.Y + this.Data.Height));
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, spriteTint, 0.0f, new Vector2(0,0), SpriteEffects.None, layer);
        }
    }
}
