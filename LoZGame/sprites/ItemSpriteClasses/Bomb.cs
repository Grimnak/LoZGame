namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class Bomb : IItemSprite
    {
        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;

        public Vector2 location { get; set; }

        public Bomb(Texture2D texture, Vector2 loc, int scale)
        {
            this.texture = texture;
            this.frame = new Rectangle(136, 0, 8, 16);
            this.lifeTime = 0;
            this.location = loc;
            this.scale = scale;
        }

        public void Update()
        {
            this.lifeTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)this.location.X, (int)this.location.Y, this.frame.Width * this.scale, this.frame.Height * this.scale);
            spriteBatch.Draw(this.texture, dest, this.frame, Color.White);
        }

    }
}
