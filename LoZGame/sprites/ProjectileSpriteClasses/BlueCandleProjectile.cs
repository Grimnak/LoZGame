namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BlueCandleProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int Width = 20;
        private static readonly int Height = 20;
        private static readonly int LifeTimeMax = 210;
        private static readonly int TravelDistance = 64;
        private static readonly int FrameDelay = 10;

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

        public bool IsHostile { get { return this.hostile; } }

        public Vector2 Location { get; set; }

        public BlueCandleProjectile(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            this.lifeTime = LifeTimeMax;
            this.texture = texture;
            this.firstFrame = new Rectangle(0, 0, 32, 32);
            this.secondFrame = new Rectangle(32, 0, 32, 32);
            this.currentFrame = this.firstFrame;
            this.scale = 1;
            this.instance = instance;
            this.expired = false;
            this.direction = direction;
            this.distTravelled = 1;
            this.hostile = false;
            if (direction.Equals("Up"))
            {
                this.Location = new Vector2(loc.X - (((Width * scale) - LinkSize) / 2), loc.Y - LinkSize);
                this.destination = new Vector2(this.Location.X, this.Location.Y - TravelDistance);
            }
            else if (direction.Equals("Left"))
            {
                this.Location = new Vector2(loc.X - LinkSize, loc.Y - (((Width * scale) - LinkSize) / 2));
                this.destination = new Vector2(this.Location.X - TravelDistance, this.Location.Y);
            }
            else if (direction.Equals("Right"))
            {
                this.Location = new Vector2(loc.X + LinkSize, loc.Y - (((Width * scale) - LinkSize) / 2));
                this.destination = new Vector2(this.Location.X + TravelDistance, this.Location.Y);
            }
            else
            {
                this.Location = new Vector2(loc.X - (((Width * scale) - LinkSize) / 2), loc.Y + LinkSize);
                this.destination = new Vector2(this.Location.X, this.Location.Y + TravelDistance);
            }
        }

        public bool IsExpired
        {
            get { return this.expired; }
        }

        public int Instance
        {
            get { return this.instance; }
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
            this.distTravelled++;
            this.lifeTime--;
            if (this.lifeTime % FrameDelay == 0)
            {
                this.NextFrame();
            }

            if (this.lifeTime >= LifeTimeMax / 3)
            {
                float xdiff = (this.destination.X - this.Location.X) / 8;
                float ydiff = (this.destination.Y - this.Location.Y) / 8;
                float denom = (float)Math.Log(this.distTravelled);
                this.Location = new Vector2(this.Location.X + (xdiff / denom), this.Location.Y + (ydiff / denom));
            }
            else if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.currentFrame, Color.White, 0, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}