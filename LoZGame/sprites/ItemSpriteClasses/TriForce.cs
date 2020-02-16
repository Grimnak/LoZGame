using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class TriForce : IItemSprite
    {
        private static int frameChange = 10;

        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private int scale;
        private float rotation;
        public Vector2 location { get; set; }
        public TriForce(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            firstFrame = new Rectangle(275, 0, 10, 16);
            secondFrame = new Rectangle(275, 16, 10, 16);
            currentFrame = firstFrame;
            lifeTime = 0;
            location = loc;
            this.rotation = 0;
            this.scale = scale;
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
            lifeTime++;

            if (lifeTime % frameChange == 0)
            {
                this.nextFrame();
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, rotation, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }

    }
}
