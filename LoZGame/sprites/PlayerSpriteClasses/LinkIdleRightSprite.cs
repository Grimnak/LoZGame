namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LinkIdleRightSprite : ISprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows;
        private readonly int spriteSheetColumns;
        private readonly int spriteSheetWidth;
        private readonly int spriteSheetHeight;
        private readonly int currentFrame = 0;

        public LinkIdleRightSprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            this.spriteSheet = spriteTexture;
            this.spriteSheetWidth = data.Width;
            this.spriteSheetHeight = data.Height;
            this.spriteSheetRows = data.Rows;
            this.spriteSheetColumns = data.Columns;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int row = (int)((float)this.currentFrame / (float)this.spriteSheetColumns);
            int column = this.currentFrame % this.spriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, this.spriteSheetWidth, this.spriteSheetHeight);

            spriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}
