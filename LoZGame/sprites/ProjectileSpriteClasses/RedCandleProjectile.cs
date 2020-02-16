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
        private static int linkSize = 32;
        private static int width = 20;
        private static int height = 20;
        private static int lifeTimeMax = 210;
        private static int travelDistance = 128;
        private static int frameDelay = 10;

        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private Rectangle currentFrame;
        private int scale;
        private string direction;
        private Vector2 destination;
        private int lifeTime;
        private int distTravelled;

        private int instance;
        private bool expired;
        private bool hostile;
        public bool IsHostile { get { return hostile; } }


        public Vector2 location { get; set; }
        
        public RedCandleProjectile(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            lifeTime = lifeTimeMax;
            Texture = texture;
            firstFrame = new Rectangle(0, 0, width, height);
            secondFrame = new Rectangle(0, 30, width, height);
            currentFrame = firstFrame;
            this.scale = scale;
            this.instance = instance;
            expired = false;
            this.direction = direction;
            this.hostile = false;
            distTravelled = 1;

            if (direction.Equals("Up"))
            {
                location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y - linkSize);
                destination = new Vector2(this.location.X, this.location.Y - travelDistance);
            }
            else if (direction.Equals("Left"))
            {
                location = new Vector2(loc.X - linkSize, loc.Y - ((width * scale) - linkSize) / 2);
                destination = new Vector2(this.location.X - travelDistance, this.location.Y);
            }
            else if (direction.Equals("Right"))
            {
                location = new Vector2(loc.X + linkSize, loc.Y - ((width * scale) - linkSize) / 2);
                destination = new Vector2(this.location.X + travelDistance, this.location.Y);
            }
            else
            {
                location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y + linkSize);
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
            distTravelled++;
            lifeTime--;
            if (lifeTime % frameDelay == 0)
            {
                this.nextFrame();
            }
            if (lifeTime >= lifeTimeMax / 3)
            {
                float xdiff = (destination.X - location.X) / 8;
                float ydiff = (destination.Y - location.Y) / 8;
                float denom = (float)Math.Log(distTravelled);
                this.location = new Vector2(this.location.X + (xdiff / denom), this.location.Y + (ydiff / denom));
            }
            else if (lifeTime <= 0)
            {
                expired = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }
    }
}
