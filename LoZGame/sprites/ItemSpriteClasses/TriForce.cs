using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class TriForce : IItemSprite, IUsableItem
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private int scale;
        private int instance;
        private bool expired;
        private bool isStatic;
        public Vector2 location { get; set; }
        public TriForce(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            firstFrame = new Rectangle(275, 0, 10, 16);
            secondFrame = new Rectangle(275, 16, 10, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
            this.scale = scale;
            isStatic = true;
        }

        public TriForce(Texture2D texture, Vector2 loc, int scale, int instance)
        {
            Texture = texture;
            firstFrame = new Rectangle(275, 0, 10, 16);
            secondFrame = new Rectangle(275, 16, 10, 16);
            currentFrame = firstFrame;
            lifeTime = 200;
            location = new Vector2(loc.X, loc.Y - 32);
            this.scale = scale;
            expired = false;
            this.instance = instance;
            isStatic = false;
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
                if(lifeTime <= 0)
                {
                    expired = true;
                }
            }

            if (lifeTime % 4 == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, firstFrame.Width * scale, firstFrame.Height * scale);
            spriteBatch.Draw(Texture, dest, currentFrame, Color.White);
        }

    }
}
