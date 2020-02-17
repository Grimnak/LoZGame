using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class TurquoiseStatueRightSprite : IBlockSprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int spriteWidth, spriteHeight;
        private int currentFrame = 1;
        public Vector2 location { get; set; }

        public TurquoiseStatueRightSprite(Texture2D spriteTexture, Vector2 loc, SpriteSheetData data)
        {
            spriteSheet = spriteTexture;
            spriteWidth = data.Width;
            spriteHeight = data.Height;
            location = loc;

            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = spriteSheet.Width / spriteSheetColumns;
            int height = spriteSheet.Height / spriteSheetRows;
            int column = (int)((float)currentFrame / (float)spriteSheetRows);

            Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
