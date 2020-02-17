using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class FireballSprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows, spriteSheetColumns;
        private readonly int spriteSheetWidth, spriteSheetHeight;
        private int currentFrame = 0;
        private int frameDelay = 0;
        private readonly int frameDelayMax = 7;
        private Vector2 location;
        private readonly int xVelocity = -7, yVelocity;

        public FireballSprite(Texture2D spriteTexture, SpriteSheetData data, string direction, Vector2 loc)
        {
            this.spriteSheet = spriteTexture;
            this.spriteSheetWidth = data.Width;
            this.spriteSheetHeight = data.Height;
            this.spriteSheetRows = data.Rows;
            this.spriteSheetColumns = data.Columns;
            this.location = loc;

            if (direction.Equals("up"))
            {
                this.yVelocity = -2;
            }
            else if (direction.Equals("down"))
            {
                this.yVelocity = 2;
            }
        }

        public void Update()
        {
            this.frameDelay++;
            if (this.frameDelay == this.frameDelayMax)
            {
                this.currentFrame++;
                this.location.X += this.xVelocity;
                this.location.Y += this.yVelocity;
                if (this.currentFrame > 3)
                {
                    this.currentFrame = 0;
                }
                this.frameDelay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int row = (int)((float)this.currentFrame / (float)this.spriteSheetColumns);
            int column = this.currentFrame % this.spriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)this.location.X, (int)this.location.Y, this.spriteSheetWidth, this.spriteSheetHeight);

            spriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}
