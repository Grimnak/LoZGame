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
        public Vector2 location { get; set; }

        private static int frameDelay = 4;
        private static int speed = 5;
        private static int maxLifeTime = 80;
        

        public SwordBeamProjectile(Texture2D texture, Link player, int scale, int instance)
        {
            Texture = texture;
            frameOne = new Rectangle(0, 0, 15, 16);
            frameTwo = new Rectangle(0, 16, 15, 16);
            frameThree = new Rectangle(0, 32, 15, 16);
            frameFour = new Rectangle(0, 48, 15, 16);
            currentFrame = frameOne;
            lifeTime = maxLifeTime;
            this.scale = scale;
            this.direction = player.CurrentDirection;
            Vector2 loc = player.CurrentLocation;
            if (this.direction.Equals("Up"))
            {
                location = new Vector2(loc.X + 16, loc.Y);
                rotation = MathHelper.Pi; ;
                dX = 0;
                dY = -1;
            }
            else if (this.direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y + 16);
                rotation = 1 * MathHelper.PiOver2;
                dX = -1;
                dY = 0;
            }
            else if (this.direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 32, loc.Y + 16);
                rotation = -1 * MathHelper.PiOver2;
                dX = 1;
                dY = 0;
            }
            else
            {
                location = new Vector2(loc.X + 16, loc.Y + 32);
                rotation = 0;
                dX = 0;
                dY = 1;
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

        public void Update()
        {
            lifeTime--;
            if (lifeTime < maxLifeTime - 30)
            {
                if (lifeTime % frameDelay == 0)
                {
                    this.nextFrame();
                }
                if (lifeTime <= 0)
                {
                    expired = true;
                }
                this.location = new Vector2(this.location.X + (dX * speed), this.location.Y + (dY * speed));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (lifeTime < maxLifeTime - 30)
            {
                spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, rotation, new Vector2(2, 8), scale, SpriteEffects.None, 0f);
            }
        }
    }
}
