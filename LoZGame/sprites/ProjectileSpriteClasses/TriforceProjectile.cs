namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class TriforceProjectile : IProjectile
    {
        private static readonly int linkSize = 32;
        private static readonly int width = 10;
        private static readonly int height = 16;
        private static readonly int frameChange = 10;

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

        public Vector2 location { get; set; }

        public static int LifeTime => 200;

        public TriforceProjectile(Texture2D texture, Vector2 loc, int scale, int instance)
        {
            this.texture = texture;
            this.firstFrame = new Rectangle(275, 0, width, height);
            this.secondFrame = new Rectangle(275, 16, width, height);
            this.currentFrame = this.firstFrame;
            this.lifeTime = LifeTime;
            this.location = new Vector2(loc.X + (linkSize - width) / (2 * scale), loc.Y - linkSize);
            this.scale = scale;
            this.expired = false;
            this.instance = instance;
            this.isStatic = false;
            this.hostile = false;
        }

        private void nextFrame()
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

            if (this.lifeTime % frameChange == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.currentFrame, Color.White, 0, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}
