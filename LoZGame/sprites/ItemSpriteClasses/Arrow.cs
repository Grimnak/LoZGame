using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class Arrow : IItemSprite, IUsableItem
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        private string direction;
        private bool moving;
        private float rotation;
        private int instance;
        private bool expired;
        public Vector2 location { get; set; }
        public Arrow(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(154, 0, 5, 16);
            lifeTime = 20;
            this.location = new Vector2(loc.X, loc.Y);
            this.scale = scale;
            this.moving = false;
            this.direction = "Up";
            this.rotation = 0;
        }

        public Arrow(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            Texture = texture;
            frame = new Rectangle(154, 0, 5, 16);
            lifeTime = 100;
            this.scale = scale;
            this.direction = direction;
            this.moving = true;
            if (this.direction == "Up")
            {
                location = new Vector2(loc.X, loc.Y - 10);
                rotation = 0;
            } else if (this.direction == "Left")
            {
                location = new Vector2(loc.X - 10, loc.Y);
                rotation = -1 * MathHelper.PiOver2;
            } else if (this.direction == "Right")
            {
                location = new Vector2(loc.X + 10, loc.Y);
                rotation = MathHelper.PiOver2;
            } else
            {
                location = new Vector2(loc.X, loc.Y + 10);
                rotation = MathHelper.Pi;
            }

            this.instance = instance;
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
            lifeTime--;
            if (moving)
            {
                lifeTime--;
            }
            if (lifeTime <= 0)
            {
                expired = true;
            }
            if (this.direction == "Up" && this.moving == true)
            {
                this.location = new Vector2(location.X, location.Y - 10);
            }
            else if (this.direction == "Left" && this.moving == true)
            {
                this.location = new Vector2(location.X - 10, location.Y);
            }
            else if (this.direction == "Right" && this.moving == true)
            {
                this.location = new Vector2(location.X + 10, location.Y);
            }
            else if (this.direction == "Down" && this.moving == true)
            {
                this.location = new Vector2(location.X, location.Y + 10);
            }
        }

        public void Draw(SpriteBatch spriteBatch)   
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, new Vector2(0,0), scale, SpriteEffects.None, 0f);
        }

    }
}
