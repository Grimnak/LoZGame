namespace LoZGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class TriforceProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int Width = 10;
        private static readonly int Height = 16;
        private static readonly int FrameChange = 10;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private readonly int scale;
        private readonly int instance;
        private bool expired;
        private readonly bool isStatic;
        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public Vector2 Location { get; set; }

        public static int LifeTime => 200;

        public TriforceProjectile(Texture2D texture, Vector2 loc, int scale, int instance)
        {
            this.texture = texture;
            this.firstFrame = new Rectangle(275, 0, Width, Height);
            this.secondFrame = new Rectangle(275, 16, Width, Height);
            this.currentFrame = this.firstFrame;
            this.lifeTime = LifeTime;
            this.Location = new Vector2(loc.X + ((LinkSize - Width) / (2 * scale)), loc.Y - LinkSize);
            this.scale = scale;
            this.expired = false;
            this.instance = instance;
            this.isStatic = false;
            this.hostile = false;
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

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public void Update()
        {
            this.lifeTime--;

            if (this.isStatic)
            {
                if (this.lifeTime <= 0)
                {
                    this.lifeTime = 200;
                }
            }
            else
            {
                if (this.lifeTime <= 0)
                {
                    this.expired = true;
                }
            }

            if (this.lifeTime % FrameChange == 0)
            {
                this.NextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.currentFrame, Color.White, 0, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}