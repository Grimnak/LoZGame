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

        private ProjectileManager projectile;

        private static int frameDelay = 4;
        private static int speed = 5;
        private static int maxLifeTime = 40;
        private static int xBound = 800, yBound = 480;
        private static int linkSpriteSize = 32;

        public SwordBeamProjectile(Texture2D texture, Link player, int scale, int instance, ProjectileManager projectile)
        {
            Texture = texture;
            frameOne = new Rectangle(0, 0, 15, 16);
            frameTwo = new Rectangle(0, 16, 15, 16);
            frameThree = new Rectangle(0, 32, 15, 16);
            frameFour = new Rectangle(0, 48, 15, 16);
            this.projectile = projectile;
            currentFrame = frameOne;
            lifeTime = maxLifeTime;
            this.scale = scale;
            this.direction = player.CurrentDirection;
            Vector2 loc = player.CurrentLocation;
            this.hostile = false;
            
            if (this.direction.Equals("Up"))
            {
                location = new Vector2(loc.X + 16, loc.Y);
                rotation = MathHelper.Pi;
                dX = 0;
                dY = -1;
                tip = new Vector2(8, 0);
            }
            else if (this.direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y + linkSpriteSize / 2);
                rotation = 1 * MathHelper.PiOver2;
                dX = -1;
                dY = 0;
                tip = new Vector2(0, 8);
            }
            else if (this.direction.Equals("Right"))
            {
                location = new Vector2(loc.X + linkSpriteSize, loc.Y + linkSpriteSize / 2);
                rotation = -1 * MathHelper.PiOver2;
                dX = 1;
                dY = 0;
                tip = new Vector2(15, 8);
            }
            else
            {
                location = new Vector2(loc.X + linkSpriteSize / 2, loc.Y + linkSpriteSize);
                rotation = 0;
                dX = 0;
                dY = 1;
                tip = new Vector2(8, 16);
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
            if (this.location.X >= xBound || this.location.X <= 0 || this.location.Y >= yBound || this.location.Y <= 0)
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
                    projectile.addExplosion(projectile.SwordExplosion, new Vector2(this.location.X + tip.X, this.location.Y + tip.Y));
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
