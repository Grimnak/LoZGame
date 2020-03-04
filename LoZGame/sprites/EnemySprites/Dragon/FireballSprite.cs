namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FireballSprite : ISprite
    {
        private const int MaxLife = 240;
        private int lifeTime = 0;
        private readonly Texture2D spriteSheet;
        private Vector2 Size;
        private readonly int spriteSheetRows;
        private readonly int spriteSheetColumns;
        private readonly int spriteSheetWidth;
        private readonly int spriteSheetHeight;
        private int currentFrame = 0;
        private readonly int scale;

        public FireballSprite(Texture2D spriteTexture, SpriteSheetData data, string direction, int scale)
        {
            this.spriteSheet = spriteTexture;
            this.spriteSheetWidth = data.Width;
            this.spriteSheetHeight = data.Height;
            this.spriteSheetRows = data.Rows;
            this.spriteSheetColumns = data.Columns;
            this.scale = scale;
            this.Size = new Vector2(this.spriteSheetWidth * scale, this.spriteSheetHeight * scale);
        }

        public void Update()
        {
            this.currentFrame++;
            if (this.currentFrame > 3)
            {
                this.currentFrame = 0;
            }
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int row = (int)((float)this.currentFrame / (float)this.spriteSheetColumns);
            int column = this.currentFrame % this.spriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)this.Size.X, (int)this.Size.Y);

            LoZGame.Instance.SpriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}