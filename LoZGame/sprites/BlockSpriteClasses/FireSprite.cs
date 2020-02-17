namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FireSprite : ISprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows;
        private readonly int spriteSheetColumns;
        private int currentFrame;
        private readonly int totalFrames;
        private int currentUpdate;
        private readonly int updatesPerFrame = 5;

        public FireSprite(Texture2D spriteTexture, SpriteSheetData data)
        {
            this.spriteSheet = spriteTexture;
            this.currentFrame = 0;
            this.spriteSheetRows = data.Rows;
            this.spriteSheetColumns = data.Columns;
            this.totalFrames = this.spriteSheetRows * this.spriteSheetColumns;
        }

        public void Update()
        {
            this.currentUpdate++;
            if (this.currentUpdate == this.updatesPerFrame)
            {
                this.currentUpdate = 0;
                this.currentFrame++;
                if (this.currentFrame == this.totalFrames)
                    this.currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int row = (int)((float)this.currentFrame / (float)this.spriteSheetColumns);

            Rectangle sourceRectangle = new Rectangle(0, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}

