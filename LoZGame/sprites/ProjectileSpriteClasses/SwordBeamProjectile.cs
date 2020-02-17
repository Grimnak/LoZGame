namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class SwordBeamProjectile : IProjectile
    {
        private static readonly int linkSize = 32;
        private static readonly int width = 15;
        private static readonly int height = 16;
        private static readonly int offset = 4;

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
        private Vector2 tip;
        private Vector2 origin;
        private static readonly int delay = 10;

        public Vector2 location { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        private readonly ExplosionManager explosion;

        private static readonly int frameDelay = 4;
        private static readonly int speed = 5;
        private static readonly int maxLifeTime = 40;
        private static readonly int xBound = 800;
        private static readonly int yBound = 480;

        public SwordBeamProjectile(Texture2D texture, IPlayer player, int scale, int instance, ExplosionManager explosion)
        {
            this.origin = new Vector2(width / 2, height / 2);
            this.texture = texture;
            this.frameOne = new Rectangle(0, 0, width, height);
            this.frameTwo = new Rectangle(0, 16, width, height);
            this.frameThree = new Rectangle(0, 32, width, height);
            this.frameFour = new Rectangle(0, 48, width, height);
            this.explosion = explosion;
            this.currentFrame = this.frameOne;
            this.lifeTime = maxLifeTime;
            this.scale = scale;
            this.direction = player.CurrentDirection;
            Vector2 loc = player.CurrentLocation;
            this.hostile = false;

            if (this.direction.Equals("Up"))
            {
                this.location = new Vector2(loc.X + (linkSize - width * scale / 2), loc.Y);
                this.rotation = MathHelper.Pi;
                this.dX = 0;
                this.dY = -1;
                this.tip = new Vector2(width - offset, 0);
            }
            else if (this.direction.Equals("Left"))
            {
                this.location = new Vector2(loc.X, loc.Y + (linkSize - width * scale / 2));
                this.rotation = 1 * MathHelper.PiOver2;
                this.dX = -1;
                this.dY = 0;
                this.tip = new Vector2(-1 * offset, width);
            }
            else if (this.direction.Equals("Right"))
            {
                this.location = new Vector2(loc.X + linkSize, loc.Y + (linkSize - width * scale / 2));
                this.rotation = -1 * MathHelper.PiOver2;
                this.dX = 1;
                this.dY = 0;
                this.tip = new Vector2(height * scale - offset, width);
            }
            else
            {
                this.location = new Vector2(loc.X + (linkSize - width * scale / 2), loc.Y + linkSize);
                this.rotation = 0;
                this.dX = 0;
                this.dY = 1;
                this.tip = new Vector2(width - offset, height * scale);
            }

            this.instance = instance;
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

        private void checkBounds()
        {
            if (this.location.X >= xBound - height || this.location.X <= 0 || this.location.Y >= yBound - height || this.location.Y <= 0)
            {
                this.lifeTime = 0;
            }
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime < maxLifeTime - delay)
            {
                if (this.lifeTime % frameDelay == 0)
                {
                    this.nextFrame();
                }

                if (this.lifeTime <= 0)
                {
                    this.explosion.addExplosion(this.explosion.SwordExplosion, new Vector2(this.location.X + this.tip.X, this.location.Y + this.tip.Y));
                    this.expired = true;
                }

                this.location = new Vector2(this.location.X + (this.dX * speed), this.location.Y + (this.dY * speed));
                this.checkBounds();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.lifeTime < maxLifeTime - delay)
            {
                spriteBatch.Draw(this.texture, this.location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, 0f);
            }
        }
    }
}
