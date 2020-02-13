using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class Bomb : IItemSprite, IUsableItem
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        private bool isStatic;
        private bool expired;
        private int instance;
        public Vector2 location { get; set; }
        public Bomb(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(136, 0, 8, 16);
            lifeTime = 20;
            location = loc;
            this.scale = scale;
            isStatic = true;
            expired = false;
        }

        public Bomb(Texture2D texture, Vector2 loc, String direction, int scale, int instance)
        {
            Texture = texture;
            frame = new Rectangle(136, 0, 8, 16);
            lifeTime = 60;
            this.instance = instance;

            if (direction.Equals("Up"))
            {
                location = new Vector2(loc.X, loc.Y - 32);
            }
            else if (direction.Equals("Left"))
            {
                location = new Vector2(loc.X - 32, loc.Y);
            }
            else if (direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 32, loc.Y);
            }
            else
            {
                location = new Vector2(loc.X, loc.Y + 32);
            }


            this.scale = scale;
            isStatic = false;
            expired = false;
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
            if (!isStatic)
            {
                lifeTime--;
            }
            if (lifeTime <= 0)
            {
                expired = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            spriteBatch.Draw(Texture, dest, frame, Color.White);
        }

    }
}
