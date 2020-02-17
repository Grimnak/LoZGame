namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BombExplosion : IProjectile
    {
        private static readonly int maxLifeTime = 90;
        private static readonly int dissipateOne = 20;
        private static readonly int dissipateTwo = 5;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle currentFrame;
        private int lifeTime;
        private readonly int scale;
        private readonly float rotation;
        private readonly int instance;
        private bool expired;

        public Vector2 location { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public BombExplosion(Texture2D texture, Vector2 location, int scale, int instance)
        {
            this.texture = texture;
            this.location = location;
            this.frameOne = new Rectangle(0, 0, 48, 48);
            this.frameTwo = new Rectangle(0, 48, 48, 48);
            this.frameThree = new Rectangle(0, 96, 48, 48);
            this.currentFrame = this.frameOne;
            this.lifeTime = maxLifeTime;
            this.scale = scale;
            this.hostile = true;
            this.instance = instance;
            this.expired = false;
            this.rotation = 0;
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        private void nextFrame()
        {
            if (this.currentFrame == this.frameOne)
            {
                this.currentFrame = this.frameTwo;
            }
            else if (this.currentFrame == this.frameTwo)
            {
                this.currentFrame = this.frameThree;
            }
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime == dissipateOne || this.lifeTime == dissipateTwo)
            {
                this.nextFrame();
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.currentFrame, Color.White, this.rotation, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}
