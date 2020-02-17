using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class FireballSprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int spriteSheetWidth, spriteSheetHeight;
        private int currentFrame = 0, frameDelay = 0, frameDelayMax = 7;
        private Vector2 location;
        private int xVelocity = -7, yVelocity;

        public FireballSprite(Texture2D spriteTexture, SpriteSheetData data, string direction, Vector2 loc)
        {
            spriteSheet = spriteTexture;
            spriteSheetWidth = data.Width;
            spriteSheetHeight = data.Height;
            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
            location = loc;

            if (direction.Equals("up"))
            {
                yVelocity = -2;
            }
            else if (direction.Equals("down"))
            {
                yVelocity = 2;
            }
        }

        public void Update()
        {
            frameDelay++;
            if (frameDelay == frameDelayMax)
            {
                currentFrame++;
                location.X += xVelocity;
                location.Y += yVelocity;
                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color spriteTint)
        {
            int width = spriteSheet.Width / spriteSheetColumns;
            int height = spriteSheet.Height / spriteSheetRows;
            int row = (int)((float)currentFrame / (float)spriteSheetColumns);
            int column = currentFrame % spriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetWidth, spriteSheetHeight);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}
