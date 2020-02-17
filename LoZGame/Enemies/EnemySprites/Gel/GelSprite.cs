using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class GelSprite : IGelSprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows, spriteSheetColumns;
        private readonly int spriteSheetWidth, spriteSheetHeight;
        private int currentFrame = 0;
        private int frameDelay = 0;
        private readonly int frameDelayMax = 7;

        public GelSprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            this.spriteSheet = spriteTexture;
            this.spriteSheetWidth = data.Width;
            this.spriteSheetHeight = data.Height;
            this.spriteSheetRows = data.Rows;
            this.spriteSheetColumns = data.Columns;
        }

        public void Update()
        {
            this.frameDelay++;
            if (this.frameDelay == this.frameDelayMax)
            {
                this.currentFrame++;
                if (this.currentFrame > 1)
                {
                    this.currentFrame = 0;
                }
                this.frameDelay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int row = (int)((float)this.currentFrame / (float)this.spriteSheetColumns);
            int column = this.currentFrame % this.spriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, this.spriteSheetWidth, this.spriteSheetHeight);

            spriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}
