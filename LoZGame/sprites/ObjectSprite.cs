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
            lifeTime = 0;
            FrameDelay = 5;
            Texture = texture;
            Data = data;
            totalFrames = Data.Rows * Data.Columns;
            frameWidth = (int)((float)Texture.Width / (float)Data.Columns);
            frameHeight = (int)((float)Texture.Height / (float)Data.Rows);
            Scale = 1;
            CurrentFrame = 0;
            frame = new Rectangle(0, 0, frameWidth, frameHeight);
        }

        public void SetFrame(int frame)
        {
            int row = (int)((float)frame / (float)Data.Columns);
            int column = frame % Data.Columns;
            if (frame >= totalFrames)
            {
                this.frame = new Rectangle(0, 0, frameWidth, frameHeight);
            }
            else
            {
                this.frame = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            }
        }

        public void Update()
        {
            lifeTime++;
            if (lifeTime >= FrameDelay)
            {
                NextFrame();
                lifeTime = 0;
            }
        }

        public void Draw(Vector2 location, Color tint, float depth) 
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, Data.DrawWidth * Scale, Data.DrawHeight * Scale);
            LoZGame.Instance.SpriteBatch.Draw(Texture, destination, frame, tint, 0.0f, Vector2.Zero, SpriteEffects.None, depth);
        }

        public void Draw(Vector2 location, Color tint, float rotation, SpriteEffects effect, float depth)
        {
            int width = Data.DrawWidth * Scale;
            int height = Data.DrawHeight * Scale;
            Vector2 origin = new Vector2(frame.Width / 2, frame.Height / 2);
            Rectangle destination = new Rectangle((int)location.X - (width / 2), (int)location.Y - (height / 2), width, height);
            LoZGame.Instance.SpriteBatch.Draw(Texture, destination, frame, tint, rotation, origin, effect, depth);
        }

        public void Draw(Rectangle location, Color tint, float rotation, SpriteEffects effect, float depth)
        {
            Vector2 origin = new Vector2(frame.Width / 2, frame.Height / 2);
            LoZGame.Instance.SpriteBatch.Draw(Texture, location, frame, tint, rotation, origin, effect, depth);
        }

        public void NextFrame()
        {
            CurrentFrame++;
            if (CurrentFrame >= totalFrames)
            {
                CurrentFrame = 0;

            }
            int row = (int)((float)CurrentFrame / (float)Data.Columns);
            int column = CurrentFrame % Data.Columns;

            frame = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
        }
    }
}