using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class TriforceProjectile : IProjectile
    {
        private static int linkSize = 32;
        private static int width = 10;
        private static int height = 16;
        private static int frameChange = 10;

        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private int scale;
        private int instance;
        private bool expired;
        private bool isStatic; 
        private bool hostile;
        public bool IsHostile { get { return hostile; } }
        public Vector2 location { get; set; }
        public static int LifeTime { get { return 200; } }

        public TriforceProjectile(Texture2D texture, Vector2 loc, int scale, int instance)
        {
            Texture = texture;
            firstFrame = new Rectangle(275, 0, width, height);
            secondFrame = new Rectangle(275, 16, width, height);
            currentFrame = firstFrame;
            lifeTime = LifeTime;
            location = new Vector2(loc.X + (linkSize - width) / (2 * scale), loc.Y - linkSize);
            this.scale = scale;
            expired = false;
            this.instance = instance;
            isStatic = false;
            this.hostile = false;
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
            lifeTime--;

            if (isStatic)
            {
                if (lifeTime <= 0)
                {
                    lifeTime = 200;
                }
            }
            else
            {
                if (lifeTime <= 0)
                {
                    expired = true;
                }
            }

            if (lifeTime % frameChange == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }
    }
}
