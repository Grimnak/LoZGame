using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class SwordBeamExplosion : IProjectile
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
        private SpriteEffects effect;

        private static int frameDelay = 4;
        private static float speed = (float)2.5;
        private static int maxLifeTime = 60;
        

        public SwordBeamExplosion(Texture2D texture, Vector2 location, string direction, int scale, int instance)
        {
            location = new Vector2(location.X - 6, location.Y - 5);
            Texture = texture;
            frameOne = new Rectangle(0, 0, 10, 12);
            frameTwo = new Rectangle(0, 12, 10, 12);
            frameThree = new Rectangle(0, 24, 10, 12);
            frameFour = new Rectangle(0, 36, 10, 12);
            currentFrame = frameOne;
            lifeTime = maxLifeTime;
            this.scale = scale;
            this.direction = direction;
            if (this.direction.Equals("NorthEast"))
            {
                this.location = new Vector2(location.X, location.Y);
                effect = SpriteEffects.FlipHorizontally;
                rotation = 0;
                dX = 1;
                dY = -1;
            }
            else if (this.direction.Equals("NorthWest"))
            {
                this.location = new Vector2(location.X, location.Y);
                effect = effect = SpriteEffects.None;
                rotation = 0;
                dX = -1;
                dY = -1;
            }
            else if (this.direction.Equals("SouthEast"))
            {
                this.location = new Vector2(location.X + 20, location.Y + 24);
                effect = SpriteEffects.None;
                rotation = MathHelper.Pi;
                dX = 1;
                dY = 1;
            }
            else
            {
                this.location = new Vector2(location.X, location.Y);
                rotation = 0;
                effect = SpriteEffects.FlipVertically;
                dX = -1;
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

        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, rotation, new Vector2(0, 0), scale, effect, 0f);
        }
    }
}
