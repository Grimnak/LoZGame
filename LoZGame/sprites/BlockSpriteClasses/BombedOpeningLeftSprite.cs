using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class BombedOpeningLeftSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;

        public BombedOpeningLeftSprite(Texture2D spriteTexture, SpriteSheetData data)
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

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}
