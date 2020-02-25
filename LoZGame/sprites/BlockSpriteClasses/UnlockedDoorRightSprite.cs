namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UnlockedDoorRightSprite : IBlockSprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows;
        private readonly int spriteSheetColumns;
        private int currentFrame = 0;
        private int frameDelay = 0;
        private readonly int frameDelayMax = 10;
        private readonly int spriteWidth;
        private readonly int spriteHeight;

        public Vector2 Location { get; set; }

        public UnlockedDoorRightSprite(Texture2D spriteTexture, Vector2 loc, SpriteSheetData data)
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
            this.frameDelay++;
            if (this.frameDelay == this.frameDelayMax)
            {
                if (this.currentFrame < 2)
                {
                    this.currentFrame++;
                }
                else
                {
                    this.currentFrame = 0;
                }

                this.frameDelay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int row = (int)((float)this.currentFrame / (float)this.spriteSheetColumns);

            Rectangle sourceRectangle = new Rectangle(0, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteWidth, this.spriteHeight);

            spriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}