using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class Arrow : IItemSprite
    {
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        private string direction;
        private bool moving;
        private float rotation;
        public Vector2 location { get; set; }
        public Arrow(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(154, 0, 5, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
            this.moving = false;
            this.direction = "Up";
            this.rotation = 0;
        }

        public Arrow(Texture2D texture, Vector2 loc, string direction, int scale)
        {
            Texture = texture;
            frame = new Rectangle(154, 0, 5, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
            this.direction = direction;
            this.moving = true;
            if (this.direction == "Up")
            {
                location = new Vector2(loc.X, loc.Y - 64);
                rotation = 0;
            } else if (this.direction == "Left")
            {
                location = new Vector2(loc.X - 64, loc.Y);
                rotation = MathHelper.PiOver2;
            } else if (this.direction == "Right")
            {
                location = new Vector2(loc.X + 64, loc.Y);
                rotation = MathHelper.Pi;
            } else
            {
                location = new Vector2(loc.X, loc.Y + 64);
                rotation = 3*MathHelper.PiOver2;
            }
        }
        public void Update()
        {
            lifeTime++;
            if (this.direction == "Up" && this.moving == true)
            {
                this.location = new Vector2(location.X, location.Y - 1);
            }
            else if (this.direction == "Left" && this.moving == true)
            {
                this.location = new Vector2(location.X - 1, location.Y);
            }
            else if (this.direction == "Right" && this.moving == true)
            {
                this.location = new Vector2(location.X + 1, location.Y);
            }
            else if (this.direction == "Down" && this.moving == true)
            {
                this.location = new Vector2(location.X, location.Y + 1);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, location, frame, Color.White, rotation, location, scale, SpriteEffects.None, 0f);
        }

    }
}
