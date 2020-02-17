using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DoorRightSprite : IBlockSprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int currentFrame = 0, frameDelay = 0, frameDelayMax = 10;
        private int spriteWidth, spriteHeight;
        public Vector2 location { get; set; }

        public DoorRightSprite(Texture2D spriteTexture, Vector2 loc, SpriteSheetData data)
        {
            spriteSheet = spriteTexture;
            spriteWidth = data.Width;
            spriteHeight = data.Height;
            location = loc;

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

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = spriteSheet.Width / spriteSheetColumns;
            int height = spriteSheet.Height / spriteSheetRows;
            int row = (int)((float)currentFrame / (float)spriteSheetColumns);

            Rectangle sourceRectangle = new Rectangle(0, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}