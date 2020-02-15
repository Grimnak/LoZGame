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
        private Texture2D Texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private int scale;
        private bool isStatic;
        private bool expired;
        private int instance;
        private string direction;
        private bool hostile;
        private ProjectileManager projectile;
        public bool IsHostile { get { return hostile; } }
        public Vector2 location { get; set; }

        public BombProjectile(Texture2D texture, Vector2 loc, String direction, int scale, int instance, ProjectileManager projectile)
        {
            Texture = texture;
            frame = new Rectangle(136, 0, 8, 16);
            lifeTime = 60;
            this.instance = instance;
            this.direction = direction;
            this.hostile = false;
            this.projectile = projectile;
            if (this.direction == "Up")
            {
                location = new Vector2(loc.X + 4*scale, loc.Y - 32);
            }
            else if (this.direction == "Left")
            {
                location = new Vector2(loc.X - 16, loc.Y);
            }
            else if (this.direction == "Right")
            {
                location = new Vector2(loc.X + 32, loc.Y);
            }
            else
            {
                location = new Vector2(loc.X + 4*scale, loc.Y + 32);
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
                Vector2 expolsionLoc = new Vector2(this.location.X - 4 - 16 * scale, this.location.Y - 16 * scale);
                projectile.addExplosion(projectile.Explosion, expolsionLoc);
                expired = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.location, frame, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }
    }
}
