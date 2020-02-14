using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class RedRing : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        public Vector2 location { get; set; }
        public RedRing(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(169, 0, 7, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public void Update()
        {
            lifeTime++;
            if (lifeTime > 20)
            {
                lifeTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }
}
