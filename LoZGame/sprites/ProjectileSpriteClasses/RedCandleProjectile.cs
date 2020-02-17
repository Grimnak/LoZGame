namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class RedCandleProjectile : IProjectile
    {
        private static readonly int linkSize = 32;
        private static readonly int width = 20;
        private static readonly int height = 20;
        private static readonly int lifeTimeMax = 210;
        private static readonly int travelDistance = 128;
        private static readonly int frameDelay = 10;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private Rectangle currentFrame;
        private readonly int scale;
        private readonly string direction;
        private Vector2 destination;
        private int lifeTime;
        private int distTravelled;

        private readonly int instance;
        private bool expired;
        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public Vector2 location { get; set; }

        public RedCandleProjectile(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            this.lifeTime = lifeTimeMax;
            this.texture = texture;
            this.firstFrame = new Rectangle(0, 0, 32, 32);
            this.secondFrame = new Rectangle(32, 0, 32, 32);
            this.currentFrame = this.firstFrame;
            this.scale = scale;
            this.instance = instance;
            this.expired = false;
            this.direction = direction;
            this.hostile = false;
            this.distTravelled = 1;

            if (direction.Equals("Up"))
            {
                this.location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y - linkSize);
                this.destination = new Vector2(this.location.X, this.location.Y - travelDistance);
            }
            else if (direction.Equals("Left"))
            {
                this.location = new Vector2(loc.X - linkSize, loc.Y - ((width * scale) - linkSize) / 2);
                this.destination = new Vector2(this.location.X - travelDistance, this.location.Y);
            }
            else if (direction.Equals("Right"))
            {
                this.location = new Vector2(loc.X + linkSize, loc.Y - ((width * scale) - linkSize) / 2);
                this.destination = new Vector2(this.location.X + travelDistance, this.location.Y);
            }
            else
            {
                this.location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y + linkSize);
                this.destination = new Vector2(this.location.X, this.location.Y + travelDistance);
            }
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

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

        public void Update()
        {
            this.distTravelled++;
            this.lifeTime--;
            if (this.lifeTime % frameDelay == 0)
            {
                this.nextFrame();
            }

            if (this.lifeTime >= lifeTimeMax / 3)
            {
                float xdiff = (this.destination.X - this.location.X) / 8;
                float ydiff = (this.destination.Y - this.location.Y) / 8;
                float denom = (float)Math.Log(this.distTravelled);
                this.location = new Vector2(this.location.X + (xdiff / denom), this.location.Y + (ydiff / denom));
            }
            else if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.currentFrame, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
        }
    }
}
