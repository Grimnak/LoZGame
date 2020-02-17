namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class TriForce : IItemSprite
    {
        private static readonly int frameChange = 10;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private readonly int scale;
        private readonly float rotation;

        public Vector2 location { get; set; }

        public TriForce(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;
            this.firstFrame = new Rectangle(275, 0, 10, 16);
            this.secondFrame = new Rectangle(275, 16, 10, 16);
            this.currentFrame = this.firstFrame;
            this.lifeTime = 0;
            this.location = loc;
            this.rotation = 0;
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

            if (this.lifeTime % frameChange == 0)
            {
                this.nextFrame();
                this.lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.currentFrame, Color.White, this.rotation, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }

    }
}
