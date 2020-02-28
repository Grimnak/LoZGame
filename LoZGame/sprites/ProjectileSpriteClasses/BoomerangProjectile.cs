namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BoomerangProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int Width = 5;
        private static readonly int Height = 16;
        private static readonly int MaxDistance = 200;
        private static readonly int TravelRate = 5;
        private static readonly int XBound = 800;
        private static readonly int YBound = 480;

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

        public Vector2 Location { get; set; }

        public BoomerangProjectile(Texture2D texture, IPlayer player, int scale, int instance)
        {
            this.texture = texture;
            this.frame = new Rectangle(129, 0, Width, Height);
            this.origin = new Vector2(Width / 2, Height / 2);
            this.scale = scale;
            this.instance = instance;
            this.expired = false;
            this.rotation = 0;
            Vector2 loc = player.Physics.Location;
            this.direction = player.CurrentDirection;
            this.isReturned = false;
            this.returning = false;
            this.player = player;
            this.distTraveled = 0;
            this.hostile = false;

            if (this.direction.Equals("Up"))
            {
                this.Location = new Vector2(loc.X - (((Width * scale) - LinkSize) / 2), loc.Y);
                this.dX = 0;
                this.dY = -1;
            }
            else if (this.direction.Equals("Left"))
            {
                this.Location = new Vector2(loc.X, loc.Y - (((Width * scale) - LinkSize) / 2));
                this.dX = -1;
                this.dY = 0;
            }
            else if (this.direction.Equals("Right"))
            {
                this.Location = new Vector2(loc.X + LinkSize, loc.Y - (((Width * scale) - LinkSize) / 2));
                this.dX = 1;
                this.dY = 0;
            }
            else
            {
                this.Location = new Vector2(loc.X - (((Width * scale) - LinkSize) / 2), loc.Y + LinkSize);
                this.dX = 0;
                this.dY = 1;
            }

            this.playerLoc = player.Physics.Location;
            this.playerLoc = new Vector2(this.playerLoc.X + 16, this.playerLoc.Y + 16);
        }

        private void Rotate()
        {
            this.rotation += MathHelper.PiOver4 / 2;
        }

        private void UpdateLoc()
        {
            this.Location = new Vector2(this.Location.X + (this.dX * TravelRate), this.Location.Y + (this.dY * TravelRate));
        }

        private void CheckBounds()
        {
            if (this.Location.X >= XBound || this.Location.X <= 0 || this.Location.Y >= YBound || this.Location.Y <= 0)
            {
                this.returning = true;
            }
        }

        private void ReturnHome()
        {
            float newX = this.Location.X;
            float newY = this.Location.Y;
            this.playerLoc = this.player.Physics.Location;
            this.playerLoc = new Vector2(this.playerLoc.X + 16, this.playerLoc.Y + 16);
            float diffX = this.playerLoc.X - newX;
            float diffY = this.playerLoc.Y - newY;
            if (Math.Abs(diffX) <= 2 * TravelRate && Math.Abs(diffY) <= 2 * TravelRate)
            {
                this.isReturned = true;
                return;
            }

            float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            if (newX != this.playerLoc.X)
            {
                float changeX = diffX / diffTotal * TravelRate;
                newX += changeX;
            }

            if (newY != this.playerLoc.Y)
            {
                float changeY = diffY / diffTotal * TravelRate;
                newY += changeY;
            }

            this.Location = new Vector2(newX, newY);
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public void Update()
        {
            this.Rotate();
            if (this.isReturned)
            {
                this.expired = true;
            }

            if (this.distTraveled == MaxDistance)
            {
                this.returning = true;
            }

            if (!this.returning)
            {
                this.UpdateLoc();
            }
            else
            {
                this.ReturnHome();
            }

            this.distTraveled += TravelRate;
            this.CheckBounds();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.frame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, 0f);
        }
    }
}