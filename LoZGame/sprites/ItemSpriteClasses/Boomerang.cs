using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class Boomerang : IItemSprite, IUsableItem
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private Link player;
        private int scale;
        private string direction;

        private int instance;
        private bool expired;
        private bool moving;
        private bool returning;
        private bool isReturned;

        private float rotation;
        private static int maxDistance = 200;
        private static int travelRate = 5;
        private int distTraveled;

        private static int maxRotationDelay = 4;
        private Vector2 playerLoc;
        private int lifeTime;

        public Vector2 location { get; set; }
        public Boomerang(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(129, 0, 5, 16);
            location = loc;
            this.scale = scale;
            moving = false;
        }

        public Boomerang(Texture2D texture, Link player, int scale, int instance)
        {
            Texture = texture;
            frame = new Rectangle(129, 0, 5, 16);
            this.scale = scale;
            this.instance = instance;
            expired = false;
            moving = true;
            rotation = 0;
            Vector2 loc = player.CurrentLocation;
            this.direction = player.CurrentDirection;
            this.isReturned = false;
            this.returning = false;
            this.player = player;
            this.distTraveled = 0;

            if (direction.Equals("Up"))
            {
                location = new Vector2(loc.X + 16, loc.Y);
            }
            else if (direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y + 16);
            }
            else if (direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 32, loc.Y + 16);
            }
            else
            {
                location = new Vector2(loc.X + 16, loc.Y + 32);
            }
            playerLoc = player.CurrentLocation;
            playerLoc = new Vector2(playerLoc.X + 16, playerLoc.Y + 16);
        }


        private void rotate()
        {
            if (rotation == 0)
            {
                rotation = MathHelper.PiOver2;
            }
            else if (rotation == MathHelper.PiOver2)
            {
                rotation = MathHelper.Pi;
            }
            else if (rotation == MathHelper.Pi)
            {
                rotation = -1 * MathHelper.PiOver2;
            }
            else
            {
                rotation = 0;
            }
        }

        private Vector2 updateLoc(string direction)
        {
            Vector2 newLoc;
            if (direction.Equals("Up"))
            {
                newLoc = new Vector2(this.location.X, this.location.Y - travelRate);
            } else if (direction.Equals("Left"))
            {
                newLoc = new Vector2(this.location.X - travelRate, this.location.Y);
            } else if (direction.Equals("Right"))
            {
                newLoc = new Vector2(this.location.X + travelRate, this.location.Y);
            } else
            {
                newLoc = new Vector2(this.location.X, this.location.Y + travelRate);
            }
            return newLoc;
        }

        private void returnHome()
        {
            float newX = this.location.X;
            float newY = this.location.Y;
            playerLoc = player.CurrentLocation;
            playerLoc = new Vector2(playerLoc.X + 16, playerLoc.Y + 16);
            float diffX = playerLoc.X - newX;
            float diffY = playerLoc.Y - newY;
            if (Math.Abs(diffX) <= 2 * travelRate && Math.Abs(diffY) <= 2 * travelRate)
            {
                this.isReturned = true;
                return;
            }


            float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            if (newX != playerLoc.X)
            {
                float changeX = (diffX / diffTotal) * travelRate;
                newX += changeX;
            } 
            if (newY != playerLoc.Y)
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
            if (moving)
            {
                if (this.isReturned)
                {
                    this.expired = true;
                }
                lifeTime++;
                if (lifeTime % maxRotationDelay == 0)
                {
                    this.rotate();
                }
                if (distTraveled == maxDistance)
                {
                    this.returning = true;
                }
                if (!returning)
                {
                    this.location = this.updateLoc(this.direction);
                } else
                {
                    this.returnHome();
                }
                distTraveled += travelRate;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            if (!moving)
            {
                spriteBatch.Draw(Texture, dest, frame, Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, new Vector2(3, 8), scale, SpriteEffects.None, 0f);
            }
        }

    }
}
