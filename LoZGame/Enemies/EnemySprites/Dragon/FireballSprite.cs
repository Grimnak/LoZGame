namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FireballSprite
    {
        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        private const int MaxLife = 240;
        private int lifeTime = 0;
        private readonly Texture2D spriteSheet;
        private readonly int spriteSheetRows;
        private readonly int spriteSheetColumns;
        private readonly int spriteSheetWidth;
        private readonly int spriteSheetHeight;
        private readonly int instance;
        private bool expired;
        private int currentFrame = 0;
        private readonly int scale;
        private readonly int frameDelayMax = 7;
        private Vector2 location;
        private readonly int xVelocity = -7;
        private readonly int yVelocity;

        public FireballSprite(Texture2D spriteTexture, SpriteSheetData data, string direction, Vector2 loc, int projectileId, int scale)
        {
            this.spriteSheet = spriteTexture;
            this.spriteSheetWidth = data.Width;
            this.spriteSheetHeight = data.Height;
            this.spriteSheetRows = data.Rows;
            this.spriteSheetColumns = data.Columns;
            this.location = loc;
            this.instance = projectileId;
            this.expired = false;
            this.scale = scale;

            if (direction.Equals("up"))
            {
                this.yVelocity = -2;
            }
            else if (direction.Equals("down"))
            {
                this.yVelocity = 2;
            }
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime == MaxLife)
            {
                this.expired = true;
            }

            if (this.lifeTime % this.frameDelayMax == 0)
            {
                this.currentFrame++;
                this.location.X += this.xVelocity;
                this.location.Y += this.yVelocity;
                if (this.currentFrame > 3)
                {
                    this.currentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, int scale, Color spriteTint)
        {
            int width = this.spriteSheet.Width / this.spriteSheetColumns;
            int height = this.spriteSheet.Height / this.spriteSheetRows;
            int row = (int)((float)this.currentFrame / (float)this.spriteSheetColumns);
            int column = this.currentFrame % this.spriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)this.location.X, (int)this.location.Y, this.spriteSheetWidth * scale, this.spriteSheetHeight * scale);

            spriteBatch.Draw(this.spriteSheet, destinationRectangle, sourceRectangle, spriteTint);
        }
    }
}