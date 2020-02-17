namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BoomerangEnemy : IProjectile
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
        private static readonly int maxDistance = 200;
        private static readonly int travelRate = 5;
        private readonly int dX;
        private readonly int dY;
        private int distTraveled;
        private Vector2 enemyLoc;
        private Goriya enemy;

        public bool IsHostile { get; }

        public Vector2 location { get; set; }

        public BoomerangEnemy(Texture2D texture, Goriya enemy, int scale, int instance)
        {
            this.texture = texture;
            this.frame = new Rectangle(129, 0, 5, 16);
            this.scale = scale;
            this.instance = instance;
            this.expired = false;
            this.rotation = 0;
            Vector2 loc = enemy.currentLocation;
            this.direction = enemy.direction;
            this.isReturned = false;
            this.returning = false;
            this.distTraveled = 0;
            this.IsHostile = true;
            this.enemy = enemy;
            this.enemy.HasBoomerang = false;

            if (this.direction.Equals("Up"))
            {
                this.location = new Vector2(loc.X + 16, loc.Y);
                this.dX = 0;
                this.dY = -1;
            }
            else if (this.direction.Equals("Left"))
            {
                this.location = new Vector2(loc.X, loc.Y + 16);
                this.dX = -1;
                this.dY = 0;
            }
            else if (this.direction.Equals("Right"))
            {
                this.location = new Vector2(loc.X + 32, loc.Y + 16);
                this.dX = 1;
                this.dY = 0;
            }
            else
            {
                location = new Vector2(loc.X + 16, loc.Y + 32);
                this.dX = 0;
                this.dY = 1;
            }

            enemyLoc = enemy.currentLocation;
            enemyLoc = new Vector2(enemyLoc.X + 16, enemyLoc.Y + 16);
        }

        private void rotate()
        {
            this.rotation += MathHelper.PiOver4 / 2;
        }

        private void updateLoc()
        {
            this.location = new Vector2(this.location.X + this.dX * travelRate, this.location.Y + this.dY * travelRate);
        }

        private void returnHome()
        {
            float newX = this.location.X;
            float newY = this.location.Y;
            this.enemyLoc = enemy.currentLocation;
            this.enemyLoc = new Vector2(enemyLoc.X + 16, enemyLoc.Y + 16);
            float diffX = this.enemyLoc.X - newX;
            float diffY = this.enemyLoc.Y - newY;
            if (Math.Abs(diffX) <= 2 * travelRate && Math.Abs(diffY) <= 2 * travelRate)
            {
                this.isReturned = true;
                this.enemy.HasBoomerang = true;
                return;
            }

            float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            if (newX != this.enemyLoc.X)
            {
                float changeX = (diffX / diffTotal) * travelRate;
                newX += changeX;
            }

            if (newY != this.enemyLoc.Y)
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

            if (this.distTraveled >= maxDistance)
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.frame, Color.White, this.rotation, new Vector2(3, 8), this.scale, SpriteEffects.None, 0f);
        }
    }
}
