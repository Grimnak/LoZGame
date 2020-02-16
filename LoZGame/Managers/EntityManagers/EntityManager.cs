using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class EntityManager
    {
        private ProjectileManager projectile;
        private ExplosionManager explosion;
        public EntityManager()
        {
            this.explosion = new ExplosionManager();
            this.projectile = new ProjectileManager(explosion);
        }

        public ProjectileManager ProjectileManager {get { return this.projectile; } }

        public bool BoomerangOut {get { return projectile.BoomerangOut; } }

        public void Update()
        {
            projectile.Update();
            explosion.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            projectile.Draw(spriteBatch);
            explosion.Draw(spriteBatch);
        }

        public void Clear()
        {
            this.explosion = new ExplosionManager();
            this.projectile = new ProjectileManager(explosion);
        }
    }
}
