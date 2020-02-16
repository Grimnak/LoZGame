using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LinkUseItemRightSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int spriteSheetWidth, spriteSheetHeight;
        private int currentFrame = 2, frameDelay = 0, frameDelayMax = 15;

        public LinkUseItemRightSprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            spriteSheet = spriteTexture;
            spriteSheetWidth = data.Width;
            spriteSheetHeight = data.Height;
            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
        }

        public void Update()
        {
            frameDelay++;
            if (frameDelay == frameDelayMax)
            {
                currentFrame = 0;
                frameDelay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
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