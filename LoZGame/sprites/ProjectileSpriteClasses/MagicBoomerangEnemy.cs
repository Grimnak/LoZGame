namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class MagicBoomerangEnemy : IProjectile
    {
        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frame;
        private readonly int scale;
        private readonly string direction;

        private readonly int instance;
        private bool expired;
        private bool returning;
        private bool isReturned;

        private float rotation;
        private static readonly int MaxDistance = 200;
        private static readonly int TravelRate = 5;
        private readonly int dX;
        private readonly int dY;
        private int distTraveled;
        private Vector2 enemyLoc;
        private readonly Goriya enemy;

        public bool IsHostile { get; }

        public Vector2 Location { get; set; }

        public MagicBoomerangEnemy(Texture2D texture, Goriya enemy, int scale, int instance)
        {
            this.texture = texture;
            this.frame = new Rectangle(129, 0, 5, 16);
            this.scale = scale;
            this.instance = instance;
            this.expired = false;
            this.rotation = 0;
            Vector2 loc = enemy.Physics.Location;
            this.direction = enemy.Direction;
            this.isReturned = false;
            this.returning = false;
            this.distTraveled = 0;
            this.IsHostile = true;
            this.enemy = enemy;

            if (this.direction.Equals("Up"))
            {
                this.Location = new Vector2(loc.X + 16, loc.Y);
                this.dX = 0;
                this.dY = -1;
            }
            else if (this.direction.Equals("Left"))
            {
                this.Location = new Vector2(loc.X, loc.Y + 16);
                this.dX = -1;
                this.dY = 0;
            }
            else if (this.direction.Equals("Right"))
            {
                this.Location = new Vector2(loc.X + 32, loc.Y + 16);
                this.dX = 1;
                this.dY = 0;
            }
            else
            {
                this.Location = new Vector2(loc.X + 16, loc.Y + 32);
                this.dX = 0;
                this.dY = 1;
            }

            this.enemyLoc = enemy.Physics.Location;
            this.enemyLoc = new Vector2(this.enemyLoc.X + 16, this.enemyLoc.Y + 16);
        }

        private void rotate()
        {
            this.rotation += MathHelper.PiOver4 / 2;
        }

        private void UpdateLoc()
        {
            this.Location = new Vector2(this.Location.X + (this.dX * TravelRate), this.Location.Y + (this.dY * TravelRate));
        }

        private void returnHome()
        {
            float newX = this.Location.X;
            float newY = this.Location.Y;
            this.enemyLoc = this.enemy.Physics.Location;
            this.enemyLoc = new Vector2(this.enemyLoc.X + 16, this.enemyLoc.Y + 16);
            float diffX = this.enemyLoc.X - newX;
            float diffY = this.enemyLoc.Y - newY;
            if (Math.Abs(diffX) <= 2 * TravelRate && Math.Abs(diffY) <= 2 * TravelRate)
            {
                this.isReturned = true;
                return;
            }

            float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            if (newX != this.enemyLoc.X)
            {
                float changeX = diffX / diffTotal * TravelRate;
                newX += changeX;
            }

            if (newY != this.enemyLoc.Y)
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
            this.rotate();
            if (this.isReturned)
            {
                this.expired = true;
            }

            if (this.distTraveled >= MaxDistance)
            {
                this.returning = true;
            }

            if (!this.returning)
            {
                this.UpdateLoc();
            }
            else
            {
                this.returnHome();
            }

            this.distTraveled += TravelRate;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.frame, Color.White, this.rotation, new Vector2(3, 8), this.scale, SpriteEffects.None, 0f);
        }
    }
}