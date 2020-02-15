using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class MagicBoomerangEnemy : IProjectile
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int scale;
        private string direction;

        private int instance;
        private bool expired;
        private bool returning;
        private bool isReturned;

        private float rotation;
        private static int maxDistance = 300;
        private static int travelRate = 5;
        private int dX, dY;
        private int distTraveled;
        private Vector2 enemyLoc;

        public bool IsHostile { get; }
        public Vector2 location { get; set; }

        public MagicBoomerangEnemy(Texture2D texture, /*IEnemy enemy,*/ int scale, int instance)
        {
            Texture = texture;
            frame = new Rectangle(129, 16, 5, 16);
            this.scale = scale;
            this.instance = instance;
            expired = false;
            rotation = 0;
            /*Vector2 loc = enemy.CurrentLocation;
            this.direction = enemy.CurrentDirection;*/
            this.isReturned = false;
            this.returning = false;
            this.distTraveled = 0;
            this.IsHostile = true;

            if (direction.Equals("Up"))
            {
                //location = new Vector2(loc.X + 16, loc.Y);
                dX = 0;
                dY = -1;
            }
            else if (direction.Equals("Left"))
            {
                //location = new Vector2(loc.X, loc.Y + 16);
                dX = -1;
                dY = 0;
            }
            else if (direction.Equals("Right"))
            {
                //location = new Vector2(loc.X + 32, loc.Y + 16);
                dX = 1;
                dY = 0;
            }
            else
            {
                //location = new Vector2(loc.X + 16, loc.Y + 32);
                dX = 0;
                dY = 1;
            }
            /*entityLoc = enemy.CurrentLocation;*/
            /*entityLoc = new Vector2(entityLoc.X + 16, entityLoc.Y + 16);*/
        }


        private void rotate()
        {
            rotation += MathHelper.PiOver4 / 2;
        }

        private void updateLoc()
        {
            this.location = new Vector2(this.location.X + dX * travelRate, this.location.Y + dY * travelRate);
        }

        private void returnHome()
        {
            float newX = this.location.X;
            float newY = this.location.Y;
            /*enemyLoc = enemy.CurrentLocation;
            enemyLoc = new Vector2(enemyLoc.X + 16, enemyLoc.Y + 16);*/
            float diffX = enemyLoc.X - newX;
            float diffY = enemyLoc.Y - newY;
            if (Math.Abs(diffX) <= 2 * travelRate && Math.Abs(diffY) <= 2 * travelRate)
            {
                this.isReturned = true;
                return;
            }
            float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            if (newX != enemyLoc.X)
            {
                float changeX = (diffX / diffTotal) * travelRate;
                newX += changeX;
            }
            if (newY != enemyLoc.Y)
            {
                float changeY = (diffY / diffTotal) * travelRate;
                newY += changeY;
            }
            this.location = new Vector2(newX, newY);
        }

        public bool IsExpired
        {
            get { return expired; }
        }

        public int Instance
        {
            get { return instance; }
        }

        public void Update()
        {
            this.rotate();
                if (this.isReturned)
                {
                    this.expired = true;
                }
                if (distTraveled == maxDistance)
                {
                    this.returning = true;
                }
                if (!returning)
                {
                    this.updateLoc();
                }
                else
                {
                    this.returnHome();
                }
                distTraveled += travelRate;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, new Vector2(3, 8), scale, SpriteEffects.None, 0f);
        }
    }
}
