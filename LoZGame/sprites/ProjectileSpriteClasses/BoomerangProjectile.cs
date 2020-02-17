namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BoomerangProjectile : IProjectile
    {
        private static readonly int linkSize = 32;
        private static readonly int width = 5;
        private static readonly int height = 16;
        private static readonly int maxDistance = 200;
        private static readonly int travelRate = 5;
        private static readonly int xBound = 800;
        private static readonly int yBound = 480;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frame;
        private Vector2 origin;
        private readonly IPlayer player;
        private readonly int scale;
        private readonly int dX;
        private readonly int dY;
        private readonly string direction;

        private readonly int instance;
        private bool expired;
        private bool returning;
        private bool isReturned;
        private float rotation;
        private int distTraveled;
        private Vector2 playerLoc;

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public Vector2 location { get; set; }

        public BoomerangProjectile(Texture2D texture, IPlayer player, int scale, int instance)
        {
            this.texture = texture;
            this.frame = new Rectangle(129, 0, width, height);
            this.origin = new Vector2(width / 2, height / 2);
            this.scale = scale;
            this.instance = instance;
            this.expired = false;
            this.rotation = 0;
            Vector2 loc = player.CurrentLocation;
            this.direction = player.CurrentDirection;
            this.isReturned = false;
            this.returning = false;
            this.player = player;
            this.distTraveled = 0;
            this.hostile = false;

            if (this.direction.Equals("Up"))
            {
                this.location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y);
                this.dX = 0;
                this.dY = -1;
            }
            else if (this.direction.Equals("Left"))
            {
                this.location = new Vector2(loc.X, loc.Y - ((width * scale) - linkSize) / 2);
                this.dX = -1;
                this.dY = 0;
            }
            else if (this.direction.Equals("Right"))
            {
                this.location = new Vector2(loc.X + linkSize, loc.Y - ((width * scale) - linkSize) / 2);
                this.dX = 1;
                this.dY = 0;
            }
            else
            {
                this.location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y + linkSize);
                this.dX = 0;
                this.dY = 1;
            }

            this.playerLoc = player.CurrentLocation;
            this.playerLoc = new Vector2(this.playerLoc.X + 16, this.playerLoc.Y + 16);
        }

        private void rotate()
        {
            this.rotation += MathHelper.PiOver4 / 2;
        }

        private void updateLoc()
        {
            this.location = new Vector2(this.location.X + this.dX * travelRate, this.location.Y + this.dY * travelRate);
        }

        private void checkBounds()
        {
            if (this.location.X >= xBound || this.location.X <= 0 || this.location.Y >= yBound || this.location.Y <= 0)
            {
                this.returning = true;
            }
        }

        private void returnHome()
        {
            float newX = this.location.X;
            float newY = this.location.Y;
            this.playerLoc = this.player.CurrentLocation;
            this.playerLoc = new Vector2(this.playerLoc.X + 16, this.playerLoc.Y + 16);
            float diffX = this.playerLoc.X - newX;
            float diffY = this.playerLoc.Y - newY;
            if (Math.Abs(diffX) <= 2 * travelRate && Math.Abs(diffY) <= 2 * travelRate)
            {
                this.isReturned = true;
                return;
            }

            float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            if (newX != this.playerLoc.X)
            {
                float changeX = (diffX / diffTotal) * travelRate;
                newX += changeX;
            }

            if (newY != this.playerLoc.Y)
            {
                float changeY = (diffY / diffTotal) * travelRate;
                newY += changeY;
            }

            this.location = new Vector2(newX, newY);
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public void Update()
        {
            this.rotate();
            if (this.isReturned)
            {
                this.expired = true;
            }

            if (this.distTraveled == maxDistance)
            {
                this.returning = true;
            }

            if (!this.returning)
            {
                this.updateLoc();
            }
            else
            {
                this.returnHome();
            }

            this.distTraveled += travelRate;
            this.checkBounds();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.frame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, 0f);
        }
    }
}