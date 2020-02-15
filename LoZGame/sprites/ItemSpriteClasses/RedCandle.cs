using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class RedCandle : IItemSprite
    {
        private Texture2D Texture;
        private Rectangle currentFrame;
        private int scale;
        private int lifeTime;


        public Vector2 location { get; set; }
        public RedCandle(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            currentFrame = new Rectangle(160, 0, 6, 16);
            location = loc;
            this.scale = scale;
            lifeTime = 0;
        }

        public void Update()
        {
            lifeTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, currentFrame, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }

    }
}
