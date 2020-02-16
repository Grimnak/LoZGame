using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LinkAttackDownSprite : ISprite
    {
        private Texture2D linkSprite;
        private int linkSpriteRows, linkSpriteColumns;
        private int linkSpriteWidth, linkSpriteHeight;

        private Texture2D swordSprite;
        private int swordSpriteRows, swordSpriteColumns;
        private int swordSpriteWidth, swordSpriteHeight;
        private int currentFrame = 2;

        public LinkAttackDownSprite(Texture2D linkTexture, SpriteSheetData linkData, Texture2D swordTexture, SpriteSheetData swordData)
        {
            linkSprite = linkTexture;
            linkSpriteRows = linkData.Rows;
            linkSpriteColumns = linkData.Columns;
            linkSpriteWidth = linkData.Width;
            linkSpriteHeight = linkData.Height;

            swordSprite = swordTexture;
            swordSpriteRows = swordData.Rows;
            swordSpriteColumns = swordData.Columns;
            swordSpriteWidth = swordData.Width;
            swordSpriteHeight = swordData.Height;
        }

        public void Update()
        {
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
