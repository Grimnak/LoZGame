using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    class SilverArrow : IItemSprite, IUsableItem
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
        public SilverArrow(Texture2D texture, Vector2 loc, int scale)
        {
            Texture = texture;
            frame = new Rectangle(154, 16, 5, 16);
            lifeTime = 0;
            location = loc;
            this.scale = scale;
        }
        public SilverArrow(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            Texture = texture;
            frame = new Rectangle(154, 16, 5, 16);
            lifeTime = 100;
            this.scale = scale;
            this.direction = direction;
            this.moving = true;
            if (this.direction.Equals("Up"))
            {
                location = new Vector2(loc.X + 16, loc.Y);
                rotation = 0;
            }
            else if (this.direction.Equals("Left"))
            {
                location = new Vector2(loc.X, loc.Y + 16);
                rotation = -1 * MathHelper.PiOver2;
            }
            else if (this.direction.Equals("Right"))
            {
                location = new Vector2(loc.X + 32, loc.Y + 16);
                rotation = MathHelper.PiOver2;
            }
            else
            {
                location = new Vector2(loc.X + 16, loc.Y + 32);
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
            if (this.direction.Equals("Up") && this.moving == true)
            {
                this.location = new Vector2(location.X, location.Y - 10);
            }
            else if (this.direction.Equals("Left") && this.moving == true)
            {
                this.location = new Vector2(location.X - 10, location.Y);
            }
            else if (this.direction.Equals("Right") && this.moving == true)
            {
                this.location = new Vector2(location.X + 10, location.Y);
            }
            else if (this.direction.Equals("Down") && this.moving == true)
            {
                this.location = new Vector2(location.X, location.Y + 10);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, rotation, new Vector2(2, 8), scale, SpriteEffects.None, 0f);
        }

    }
}
