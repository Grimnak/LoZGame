using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class RedCandleProjectile : IProjectile
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private Rectangle currentFrame;
        private int scale;
        private string direction;
        private Vector2 destination;
        private int lifeTime;
        private int distTravelled;

        private static int lifeTimeMax = 210;
        private static int travelDistance = 256;
        private static int frameDelay = 10;

        private int instance;
        private bool expired;
        private bool moving;


        public Vector2 location { get; set; }
        
        public RedCandleProjectile(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            lifeTime = lifeTimeMax;
            Texture = texture;
            firstFrame = new Rectangle(0, 0, 20, 20);
            secondFrame = new Rectangle(0, 30, 20, 20);
            currentFrame = firstFrame;
            this.scale = scale;
            this.instance = instance;
            expired = false;
            this.direction = direction;
            moving = true;
            distTravelled = 1;

            if (direction.Equals("Up"))
            {
                location = new Vector2(loc.X + 13, loc.Y);
                destination = new Vector2(this.location.X, this.location.Y - travelDistance);
            }
            else if (direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y + 8);
                destination = new Vector2(this.location.X - travelDistance, this.location.Y);
            }
            else if (direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 32, loc.Y + 8);
                destination = new Vector2(this.location.X + travelDistance, this.location.Y);
            }
            else
            {
                location = new Vector2(loc.X + 13, loc.Y + 32);
                destination = new Vector2(this.location.X, this.location.Y + travelDistance);
            }
        }

        public bool IsExpired
        {
            get { return expired; }
        }

        public int Instance
        {
            get { return instance; }
        }

        private void nextFrame()
        {
            if (currentFrame == firstFrame)
            {
                currentFrame = secondFrame;
            }
            else
            {
                currentFrame = firstFrame;
            }
        }

        public void Update()
        {
            if (moving)
            {
                if (lifeTime % frameDelay == 0)
                {
                    this.nextFrame();
                }
                if (lifeTime >= lifeTimeMax / 3)
                {
                    float xdiff = (destination.X - location.X) / 8;
                    float ydiff = (destination.Y - location.Y) / 8;
                    float denom = 2 * distTravelled + 1 / distTravelled;
                    this.location = new Vector2(this.location.X + (xdiff / denom), this.location.Y + (ydiff / denom));
                }
                else if (lifeTime <= 0)
                {
                    expired = true;
                }
                distTravelled++;
                lifeTime--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }
    }
}
