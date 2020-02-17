using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class EnemySpawnSprite : IBlockSprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int currentFrame, totalFrames;
        private int currentUpdate;
        private int updatesPerFrame = 5;
        private int spriteWidth, spriteHeight;
        public Vector2 location { get; set; }

        public EnemySpawnSprite(Texture2D spriteTexture, Vector2 loc, SpriteSheetData data)
        {
            spriteSheet = spriteTexture;
            spriteWidth = data.Width;
            spriteHeight = data.Height;
            location = loc;
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