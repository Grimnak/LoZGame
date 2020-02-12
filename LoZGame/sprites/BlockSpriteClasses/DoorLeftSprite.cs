using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DoorLeftSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int currentFrame = 0, frameDelay = 0, frameDelayMax = 10;

        public DoorLeftSprite(Texture2D spriteTexture, SpriteSheetData data)
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
                if (currentFrame < 2)
                {
                    currentFrame++;
                }
                else
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int width = spriteSheet.Width / spriteSheetColumns;
            int height = spriteSheet.Height / spriteSheetRows;
            int row = (int)((float)currentFrame / (float)spriteSheetColumns);

            Rectangle sourceRectangle = new Rectangle(0, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}