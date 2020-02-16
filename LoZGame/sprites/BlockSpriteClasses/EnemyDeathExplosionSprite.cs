using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class EnemyDeathExplosionSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int currentFrame, totalFrames;
        private int currentUpdate;
        private int updatesPerFrame = 5;
        private int scale;

        public EnemyDeathExplosionSprite(Texture2D spriteTexture, SpriteSheetData data, int scale)
        {
            spriteSheet = spriteTexture;
            currentFrame = 0;
            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
            totalFrames = spriteSheetRows * spriteSheetColumns;
            this.scale = scale;
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
            int column = (int)((float)currentFrame / (float)spriteSheetRows);

            Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}
