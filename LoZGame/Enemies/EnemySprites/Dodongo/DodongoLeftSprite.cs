using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DodongoLeftSprite : IDodongoSprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int spriteSheetWidth, spriteSheetHeight;
        private int currentFrame = 0, frameDelay = 0, frameDelayMax = 7;

        public DodongoLeftSprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            spriteSheet = spriteTexture;
            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
        }

        public void Update()
        {
            frameDelay++;
            if (frameDelay == frameDelayMax)
            {
                currentFrame++;
                if (currentFrame > 2)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int width = spriteSheet.Width / spriteSheetColumns;
            int height =spriteSheet.Height / spriteSheetRows;
            int column = (int)((float)currentFrame / (float)spriteSheetRows);

            Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }

        public void Attack() { }
    }
}
