using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
<<<<<<< HEAD:LoZGame/sprites/BlockSpriteClasses/LadderTileSprite.cs
    public class LadderTileSprite : ISprite
=======
    public class WaterTileSprite : ISprite
>>>>>>> blocks update:LoZGame/sprites/BlockSpriteClasses/WaterTileSprite.cs
    {
        private Texture2D spriteSheet;
        private int spriteSheetRows, spriteSheetColumns;
        private int scale;

<<<<<<< HEAD:LoZGame/sprites/BlockSpriteClasses/LadderTileSprite.cs
        public LadderTileSprite(Texture2D spriteTexture, SpriteSheetData data, int scale)
=======
        public WaterTileSprite(Texture2D spriteTexture, SpriteSheetData data, int scale)
>>>>>>> blocks update:LoZGame/sprites/BlockSpriteClasses/WaterTileSprite.cs
        {
            spriteSheet = spriteTexture;

            spriteSheetRows = data.Rows;
            spriteSheetColumns = data.Columns;
            this.scale = scale;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int width = spriteSheet.Width / spriteSheetColumns;
            int height = spriteSheet.Height / spriteSheetRows;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}
