using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DodongoLeftSprite : IDodongoSprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows, spriteSheetColumns;
        private readonly int spriteSheetWidth, spriteSheetHeight;
        private int currentFrame = 0;
        private int frameDelay = 0;
        private readonly int frameDelayMax = 7;

        public DodongoLeftSprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            this.spriteSheet = spriteTexture;
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
            int height =this.spriteSheet.Height / this.spriteSheetRows;
            int column = (int)((float)this.currentFrame / (float)this.spriteSheetRows);

            Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }

        public void Attack() { }
    }
}
