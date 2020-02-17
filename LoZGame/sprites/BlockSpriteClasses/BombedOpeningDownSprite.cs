using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class BombedOpeningDownSprite : IBlockSprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int spriteWidth, spriteHeight;
        public Vector2 location { get; set; }

        public BombedOpeningDownSprite(Texture2D spriteTexture, Vector2 loc, SpriteSheetData data)
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

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
