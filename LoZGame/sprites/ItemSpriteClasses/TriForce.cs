namespace LoZGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class TriForce : IItemSprite
    {
        private static readonly int FrameChange = 10;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private readonly int scale;
        private readonly float rotation;

        public Vector2 Location { get; set; }

        public TriForce(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;
            this.firstFrame = new Rectangle(275, 0, 10, 16);
            this.secondFrame = new Rectangle(275, 16, 10, 16);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.Location = loc;
            this.rotation = 0;
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

            if (this.lifeTime % FrameChange == 0)
            {
                this.NextFrame();
                this.lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.currentFrame, Color.White, this.rotation, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}