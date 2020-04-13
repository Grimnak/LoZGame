namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ObjectSprite : ISprite
    {
        private Rectangle frame;
        private int totalFrames;
        private int frameWidth;
        private int frameHeight;
        private int lifeTime;

        public int FrameDelay { get; set; }

        public int Scale { get; set; }

        public Texture2D Texture { get; set; }

        public SpriteData Data { get; set; }

        public int CurrentFrame { get; set; }

        public int TotalFrames => totalFrames;

        public ObjectSprite(Texture2D texture, SpriteData data)
        {
            this.lifeTime = 0;
            this.FrameDelay = 5;
            this.Texture = texture;
            this.Data = data;
            this.totalFrames = this.Data.Rows * this.Data.Columns;
            this.frameWidth = (int)((float)this.Texture.Width / (float)this.Data.Columns);
            this.frameHeight = (int)((float)this.Texture.Height / (float)this.Data.Rows);
            this.Scale = 1;
            this.CurrentFrame = 0;
            this.frame = new Rectangle(0, 0, this.frameWidth, this.frameHeight);
        }

        public void SetFrame(int frame)
        {
            int row = (int)((float)frame / (float)this.Data.Columns);
            int column = frame % this.Data.Columns;
            if (frame >= this.totalFrames)
            {
                this.frame = new Rectangle(0, 0, this.frameWidth, this.frameHeight);
            }
            else
            {
                this.frame = new Rectangle(this.frameWidth * column, this.frameHeight * row, this.frameWidth, this.frameHeight);
            }
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime >= this.FrameDelay)
            {
                this.NextFrame();
                this.lifeTime = 0;
            }
        }

        public void Draw(Vector2 location, Color tint, float depth) 
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, this.Data.DrawWidth * this.Scale, this.Data.DrawHeight * this.Scale);
            LoZGame.Instance.SpriteBatch.Draw(Texture, destination, this.frame, tint, 0.0f, Vector2.Zero, SpriteEffects.None, depth);
        }

        public void Draw(Vector2 location, Color tint, float rotation, SpriteEffects effect, float depth)
        {
            int width = this.Data.DrawWidth * this.Scale;
            int height = this.Data.DrawHeight * this.Scale;
            Vector2 origin = new Vector2(this.frame.Width / 2, this.frame.Height / 2);
            Rectangle destination = new Rectangle((int)location.X - (width / 2), (int)location.Y - (height / 2), width, height);
            LoZGame.Instance.SpriteBatch.Draw(Texture, destination, this.frame, tint, rotation, origin, effect, depth);
        }

        public void Draw(Rectangle location, Color tint, float rotation, SpriteEffects effect, float depth)
        {
            int width = this.Data.DrawWidth * this.Scale;
            int height = this.Data.DrawHeight * this.Scale;
            Vector2 origin = new Vector2(this.frame.Width / 2, this.frame.Height / 2);
            LoZGame.Instance.SpriteBatch.Draw(Texture, location, this.frame, tint, rotation, origin, effect, depth);
        }

        public void NextFrame()
        {
            this.CurrentFrame++;
            if (this.CurrentFrame >= this.totalFrames)
            {
                this.CurrentFrame = 0;

            }
            int row = (int)((float)this.CurrentFrame / (float)this.Data.Columns);
            int column = this.CurrentFrame % this.Data.Columns;

            this.frame = new Rectangle(this.frameWidth * column, this.frameHeight * row, this.frameWidth, this.frameHeight);
        }
    }
}