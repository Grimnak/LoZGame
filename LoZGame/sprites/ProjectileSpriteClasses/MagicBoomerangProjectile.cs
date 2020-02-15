using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class MagicBoomerangProjectile : IProjectile
    {
        private static int maxDistance = 300;
        private static int travelRate = 5;
        private static int xBound = 800, yBound = 480;

        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private Link player;
        private int scale;
        private string direction;

        private int instance;
        private bool expired;
        private bool returning;
        private bool isReturned;

        private float rotation;
        private int dX, dY;
        private int distTraveled;
        private Vector2 entityLoc;

        private bool hostile;
        public bool IsHostile { get { return hostile; } }
        public Vector2 location { get; set; }

        public MagicBoomerangProjectile(Texture2D texture, Link player, int scale, int instance)
        {
            Texture = texture;
            frame = new Rectangle(129, 16, 5, 16);
            this.scale = scale;
            this.instance = instance;
            expired = false;
            rotation = 0;
            Vector2 loc = player.CurrentLocation;
            this.direction = player.CurrentDirection;
            this.isReturned = false;
            this.returning = false;
            this.player = player;
            this.distTraveled = 0;
            this.hostile = false;

            if (direction.Equals("Up"))
            {
                location = new Vector2(loc.X + 16, loc.Y);
                dX = 0;
                dY = -1;
            }
            else if (direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y + 16);
                dX = -1;
                dY = 0;
            }
            else if (direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 32, loc.Y + 16);
                dX = 1;
                dY = 0;
            }
            else
            {
                location = new Vector2(loc.X + 16, loc.Y + 32);
                dX = 0;
                dY = 1;
            }
            entityLoc = player.CurrentLocation;
            entityLoc = new Vector2(entityLoc.X + 16, entityLoc.Y + 16);
        }

        private void rotate()
        {
            rotation += MathHelper.PiOver4 / 2;
        }

        private void updateLoc()
        {
            this.location = new Vector2(this.location.X + dX * travelRate, this.location.Y + dY * travelRate);
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
            entityLoc = player.CurrentLocation;
            entityLoc = new Vector2(entityLoc.X + 16, entityLoc.Y + 16);
            float diffX = entityLoc.X - newX;
            float diffY = entityLoc.Y - newY;
            if (Math.Abs(diffX) <= 2 * travelRate && Math.Abs(diffY) <= 2 * travelRate)
            {
                this.isReturned = true;
                return;
            }


            float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            if (newX != entityLoc.X)
            {
                float changeX = (diffX / diffTotal) * travelRate;
                newX += changeX;
            }
            if (newY != entityLoc.Y)
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
            this.checkBounds();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, new Vector2(3, 8), scale, SpriteEffects.None, 0f);
        }
    }
}
