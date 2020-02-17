namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class SwordBeamExplosion : IProjectile
    {
        private static readonly int width = 10;
        private static readonly int height = 12;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle frameFour;
        private Rectangle currentFrame;
        readonly int dX;
        readonly int dY;
        private int lifeTime;
        private readonly int scale;
        private readonly string direction;
        private readonly float rotation;
        private readonly int instance;
        private bool expired;
        private readonly SpriteEffects effect;

        public Vector2 location { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        private static readonly int frameDelay = 4;
        private static readonly float speed = (float)2.5;
        private static readonly int maxLifeTime = 60;

        public SwordBeamExplosion(Texture2D texture, Vector2 location, string direction, int scale, int instance)
        {
            location = new Vector2(location.X - width * scale, location.Y - height * scale);
            this.texture = texture;
            this.frameOne = new Rectangle(0, 0, width, height);
            this.frameTwo = new Rectangle(0, 12, width, height);
            this.frameThree = new Rectangle(0, 24, width, height);
            this.frameFour = new Rectangle(0, 36, width, height);
            this.currentFrame = this.frameOne;
            this.lifeTime = maxLifeTime;
            this.scale = scale;
            this.direction = direction;
            this.location = new Vector2(location.X, location.Y);
            if (this.direction.Equals("NorthEast"))
            {
                this.effect = SpriteEffects.FlipHorizontally;
                this.rotation = 0;
                this.dX = 1;
                this.dY = -1;
            }
            else if (this.direction.Equals("NorthWest"))
            {
                this.effect = this.effect = SpriteEffects.None;
                this.rotation = 0;
                this.dX = -1;
                this.dY = -1;
            }
            else if (this.direction.Equals("SouthEast"))
            {
                this.location = new Vector2(this.location.X + width * scale, this.location.Y + height * scale);
                this.effect = SpriteEffects.None;
                this.rotation = MathHelper.Pi;
                this.dX = 1;
                this.dY = 1;
            }
            else
            {
                this.rotation = 0;
                this.effect = SpriteEffects.FlipVertically;
                this.dX = -1;
                this.dY = 1;
            }

            this.instance = instance;
            this.hostile = false;
            this.expired = false;
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
            else if (this.currentFrame == this.frameThree)
            {
                this.currentFrame = this.frameFour;
            }
            else
            {
                this.currentFrame = this.frameOne;
            }
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime % frameDelay == 0)
            {
                this.nextFrame();
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }

            this.location = new Vector2(this.location.X + (this.dX * speed), this.location.Y + (this.dY * speed));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.currentFrame, Color.White, this.rotation, new Vector2(0, 0), this.scale, this.effect, 0f);
        }
    }
}
