namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class Health : IItemSprite
    {
        private static readonly int frameChange = 10;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private readonly int scale;

        public Vector2 location { get; set; }

        public Health(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;
            this.firstFrame = new Rectangle(0, 0, 7, 8);
            this.secondFrame = new Rectangle(0, 8, 7, 8);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.location = loc;
            this.scale = scale;
        }

        private void nextFrame()
        {
            if (this.currentFrame == this.firstFrame)
            {
                this.currentFrame = this.secondFrame;
            }
            else
            {
                this.currentFrame = this.firstFrame;
            }
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > 200)
            {
                this.lifeTime = 0;
            }

            if (this.lifeTime % frameChange == 0)
            {
                this.nextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)this.location.X, (int)this.location.Y, this.firstFrame.Width * this.scale, this.firstFrame.Height * this.scale);
            spriteBatch.Draw(this.texture, dest, this.currentFrame, Color.White);
        }

    }
}
