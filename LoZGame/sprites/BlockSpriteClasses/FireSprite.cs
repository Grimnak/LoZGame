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
        private readonly int spriteWidth;
        private readonly int spriteHeight;

        public Vector2 Location { get; set; }

        public FireSprite(Texture2D spriteTexture, Vector2 loc, SpriteSheetData data)
        {
            this.spriteSheet = spriteTexture;
            this.spriteWidth = data.Width;
            this.spriteHeight = data.Height;
            this.Location = loc;
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

        public void Draw(Vector2 location, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int row = (int)((float)this.currentFrame / (float)this.spriteSheetRows);

            Rectangle sourceRectangle = new Rectangle(0, row * height, width, height);
            Rectangle destinationRectangle = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteWidth, this.spriteHeight);

            LoZGame.Instance.SpriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint, 0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
        }
    }
}