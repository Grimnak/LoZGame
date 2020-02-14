using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class RedCandle : IItemSprite, IUsableItem
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int scale;
        private string direction;
        private Vector2 destination;
        private static int travelDistance = 128;
        private int lifeTime;

        private int instance;
        private bool expired;
        private bool moving;


        public Vector2 location { get; set; }
        public RedCandle(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(160, 0, 6, 16);
            location = loc;
            this.scale = scale;
            moving = false;
            lifeTime = 1000000;
        }

        public RedCandle(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            lifeTime = 150;
            Texture = texture;
            frame = new Rectangle(160, 0, 6, 16);
            this.scale = scale;
            this.instance = instance;
            expired = false;
            this.direction = direction;
            moving = true;

            if (direction.Equals("Up"))
            {
                location = new Vector2(loc.X + 13, loc.Y);
                destination = new Vector2(this.location.X, this.location.Y - travelDistance);
            }
            else if (direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y + 8);
                destination = new Vector2(this.location.X - travelDistance, this.location.Y);
            }
            else if (direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 32, loc.Y + 8);
                destination = new Vector2(this.location.X + travelDistance, this.location.Y);
            }
            else
            {
                location = new Vector2(loc.X + 13, loc.Y + 32);
                destination = new Vector2(this.location.X, this.location.Y + travelDistance);
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
            if (moving)
            {
                if (lifeTime >= 60)
                {
                    float xdiff = destination.X - location.X;
                    float ydiff = destination.Y - location.Y;
                    this.location = new Vector2(location.X + (xdiff * 1 / travelDistance), location.Y + (ydiff * 1 / travelDistance));
                }
                else if (lifeTime <= 0)
                {
                    expired = true;
                }

                lifeTime--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }

    }
}
