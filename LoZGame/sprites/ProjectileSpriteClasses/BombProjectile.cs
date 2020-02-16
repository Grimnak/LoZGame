using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    class BombProjectile : IProjectile
    {
        private static int linkSize = 32;
        private static int width = 8;
        private static int height = 16;
        private static int maxLife = 120;

        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        private bool isStatic;
        private bool expired;
        private int instance;
        private string direction;
        private bool hostile;
        private ExplosionManager explosion;
        public bool IsHostile { get { return hostile; } }
        public Vector2 location { get; set; }

        public BombProjectile(Texture2D texture, Vector2 loc, String direction, int scale, int instance, ExplosionManager explosion)
        {
            Texture = texture;
            frame = new Rectangle(136, 0, width, height);
            lifeTime = maxLife;
            this.instance = instance;
            this.direction = direction;
            this.hostile = false;
            this.explosion = explosion;
            if (this.direction == "Up")
            {
                location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y - linkSize);
            }
            else if (this.direction == "Left")
            {
                location = new Vector2(loc.X - linkSize + (linkSize - width*scale), loc.Y - ((height * scale) - linkSize) / 2);
            }
            else if (this.direction == "Right")
            {
                location = new Vector2(loc.X + linkSize, loc.Y - ((height * scale) - linkSize) / 2);
            }
            else
            {
                location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y + linkSize);
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
                Vector2 expolsionLoc = new Vector2(this.location.X - width / 2 - height * scale, this.location.Y - height * scale);
                explosion.addExplosion(explosion.Explosion, expolsionLoc);
                expired = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }
    }
}
