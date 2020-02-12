using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class TurquoiseStatueRightSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int currentFrame = 1;

        public TurquoiseStatueRightSprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            spriteSheet = spriteTexture;

            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int width = spriteSheet.Width / spriteSheetColumns;
            int height = spriteSheet.Height / spriteSheetRows;
            int column = (int)((float)currentFrame / (float)spriteSheetRows);

            Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}
