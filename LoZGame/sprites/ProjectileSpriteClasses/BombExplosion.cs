using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class BombExplosion : IProjectile
    {
        private static int maxLifeTime = 90;
        private static int dissipateOne = 30;
        private static int dissipateTwo = 15;

        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle currentFrame;
        private int lifeTime;
        private int scale;
        private float rotation;
        private int instance;
        private bool expired;


        public Vector2 location { get; set; }
        private bool hostile;
        public bool IsHostile { get { return hostile; } }
        

        public BombExplosion(Texture2D texture, Vector2 location, int scale, int instance)
        {
            Texture = texture;
            this.location = location;
            frameOne = new Rectangle(0, 0, 48, 48);
            frameTwo = new Rectangle(0, 48, 48, 48);
            frameThree = new Rectangle(0, 96, 48, 48);
            currentFrame = frameOne;
            lifeTime = maxLifeTime;
            this.scale = scale;
            this.hostile = true;
            this.instance = instance;
            expired = false;
            this.rotation = 0;
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
        }

        public void Update()
        {
            lifeTime--;
            if (lifeTime == dissipateOne || lifeTime == dissipateTwo)
            {
                this.nextFrame();
            }
            if (lifeTime <= 0)
            {
                expired = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, rotation, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }
    }
}
