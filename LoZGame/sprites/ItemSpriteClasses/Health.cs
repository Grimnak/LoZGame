namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Health : IItemSprite
    {
        private static readonly int FrameChange = 10;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private readonly int scale;

        public Vector2 Location { get; set; }

        public Health(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;
            this.firstFrame = new Rectangle(0, 0, 7, 8);
            this.secondFrame = new Rectangle(0, 8, 7, 8);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.Location = loc;
            this.scale = scale;
        }

        private void NextFrame()
        {
            if (this.currentFrame == this.firstFrame)
            {
                this.currentFrame = this.secondFrame;
            }
            else
            {
                this.currentFrame = this.firstFrame;
            }
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > 200)
            {
                this.lifeTime = 0;
            }

            if (this.lifeTime % FrameChange == 0)
            {
                this.NextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.firstFrame.Width * this.scale, this.firstFrame.Height * this.scale);
            spriteBatch.Draw(this.texture, dest, this.currentFrame, Color.White);
        }
    }
}