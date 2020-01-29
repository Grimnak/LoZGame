using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class Sprite : ISprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int currentFrame, totalFrames, frameDelay, frameDelayMax = 5;
        private Rectangle sourceRectangle = new Rectangle();
        private Rectangle destinationRectangle = new Rectangle();

        public Sprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            spriteSheet = spriteTexture;
            SetSpriteLocation(data.Width, data.Height);
            SetSourceRectangleDefaults(spriteSheet.Width, spriteSheet.Height);

            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
            currentFrame = 0;
            totalFrames = data.Rows * data.Columns;
        }

        public void SetSpriteLocation(int xPos, int yPos)
        {
            destinationRectangle.X = xPos;
            destinationRectangle.Y = yPos;
        }

        public void SetSpriteSize(int width, int height)
        {
            destinationRectangle.Width = width;
            destinationRectangle.Height = height;
        }

        public void SetSourceRectangleDefaults(int width, int height)
        {
            sourceRectangle.X = 0;
            sourceRectangle.Y = 0;
            sourceRectangle.Width = width;
            sourceRectangle.Height = height;
        }

        public void Update()
        {
            frameDelay++;
            if (frameDelay == frameDelayMax)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color spriteTint)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
            spriteBatch.End();
        }
    }
}
