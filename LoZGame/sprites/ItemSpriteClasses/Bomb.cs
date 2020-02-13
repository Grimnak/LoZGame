using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class Bomb : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        bool isStatic;
        bool exploding;
        public Vector2 location { get; set; }
        public Bomb(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(136, 0, 8, 16);
            lifeTime = 20;
            location = loc;
            this.scale = scale;
            isStatic = true;
            exploding = false;
        }

        public Bomb(Texture2D texture, Vector2 loc, String direction, int scale)
        {
            Texture = texture;
            frame = new Rectangle(136, 0, 8, 16);
            lifeTime = 20;


            if (direction.Equals("Up"))
            {
                location = new Vector2(loc.X, loc.Y - 64);
            }
            else if (direction.Equals("Left"))
            {
                location = new Vector2(loc.X - 64, loc.Y);
            }
            else if (direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 64, loc.Y);
            }
            else
            {
                location = new Vector2(loc.X, loc.Y + 64);
            }


            this.scale = scale;
            isStatic = false;
            exploding = false;
        }



        public void Update()
        {
            if (!isStatic)
            {
                lifeTime--;
            }
            if (lifeTime <= 0)
            {
                exploding = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }
}
