using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class SwordBeamProjectile : IProjectile
    {
        private static int linkSize = 32;
        private static int width = 15;
        private static int height = 16;

        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle frameFour;
        private Rectangle currentFrame;
        int dX;
        int dY;
        private int lifeTime;
        private int scale;
        private string direction;
        private float rotation;
        private int instance;
        private bool expired;
        private Vector2 tip;
        private static int delay = 10;
        public Vector2 location { get; set; }
        private bool hostile;
        public bool IsHostile { get { return hostile; } }

        private ExplosionManager explosion;

        private static int frameDelay = 4;
        private static int speed = 5;
        private static int maxLifeTime = 40;
        private static int xBound = 800, yBound = 480;
        

        public SwordBeamProjectile(Texture2D texture, Link player, int scale, int instance, ExplosionManager explosion)
        {
            Texture = texture;
            frameOne = new Rectangle(0, 0, width, height);
            frameTwo = new Rectangle(0, 16, width, height);
            frameThree = new Rectangle(0, 32, width, height);
            frameFour = new Rectangle(0, 48, width, height);
            this.explosion = explosion;
            currentFrame = frameOne;
            lifeTime = maxLifeTime;
            this.scale = scale;
            this.direction = player.CurrentDirection;
            Vector2 loc = player.CurrentLocation;
            this.hostile = false;
            
            if (this.direction.Equals("Up"))
            {
                location = new Vector2(loc.X + (linkSize - width * scale / 2), loc.Y);
                rotation = MathHelper.Pi;
                dX = 0;
                dY = -1;
                tip = new Vector2((width * scale) / 2, 0);
            }
            else if (this.direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y + (linkSize - width * scale / 2));
                rotation = 1 * MathHelper.PiOver2;
                dX = -1;
                dY = 0;
                tip = new Vector2(0, (width * scale) / 2);
            }
            else if (this.direction.Equals("Right"))
            {
                location = new Vector2(loc.X + linkSize, loc.Y + (linkSize - width * scale / 2));
                rotation = -1 * MathHelper.PiOver2;
                dX = 1;
                dY = 0;
                tip = new Vector2(height * scale, (width * scale) / 2 );
            }
            else
            {
                location = new Vector2(loc.X + (linkSize - width * scale / 2), loc.Y + linkSize);
                rotation = 0;
                dX = 0;
                dY = 1;
                tip = new Vector2((width * scale) / 2, height * scale);
            }

            this.instance = instance;
            expired = false;
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
            if (currentFrame == frameOne)
            {
                currentFrame = frameTwo;
            }
            else if (currentFrame == frameTwo)
            {
                currentFrame = frameThree;
            }
            else if (currentFrame == frameThree)
            {
                currentFrame = frameFour;
            }
            else
            {
                currentFrame = frameOne;
            }
        }

        private void checkBounds()
        {
            if (this.location.X >= xBound - height || this.location.X <= 0 || this.location.Y >= yBound - height || this.location.Y <= 0)
            {
                this.lifeTime = 0;
            }
        }

        public void Update()
        {
            lifeTime--;
            if (lifeTime < maxLifeTime - delay)
            {
                if (lifeTime % frameDelay == 0)
                {
                    this.nextFrame();
                }
                if (lifeTime <= 0)
                {
                    explosion.addExplosion(explosion.SwordExplosion, new Vector2(this.location.X + tip.X, this.location.Y + tip.Y));
                    expired = true;
                }
                this.location = new Vector2(this.location.X + (dX * speed), this.location.Y + (dY * speed));
                this.checkBounds();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (lifeTime < maxLifeTime - delay)
            {
                spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, rotation, new Vector2(8, 8), scale, SpriteEffects.None, 0f);
            }
        }
    }
}
