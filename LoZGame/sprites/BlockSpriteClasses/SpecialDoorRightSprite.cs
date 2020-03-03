namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpecialDoorRightSprite : ISprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows;
        private readonly int spriteSheetColumns;
        private readonly int spriteWidth;
        private readonly int spriteHeight;

        public Vector2 Location { get; set; }

        public SpecialDoorRightSprite(Texture2D spriteTexture, Vector2 loc, SpriteSheetData data)
        {
            this.spriteSheet = spriteTexture;
            this.spriteWidth = data.Width;
            this.spriteHeight = data.Height;
            this.Location = loc;

            this.spriteSheetRows = data.Rows;
            this.spriteSheetColumns = data.Columns;
        }

        public void Update()
        {
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(this.spriteWidth * 1.5), this.spriteHeight * 2);

            LoZGame.Instance.SpriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint, 0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
        }
    }
}