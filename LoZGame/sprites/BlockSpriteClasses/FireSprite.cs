using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class FireSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int currentFrame, totalFrames;
        private int currentUpdate;
        private int updatesPerFrame = 5;

        public FireSprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            spriteSheet = spriteTexture;
            currentFrame = 0;
            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
            totalFrames = spriteSheetRows * spriteSheetColumns;
        }

        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == updatesPerFrame)
            {
                currentUpdate = 0;
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
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

