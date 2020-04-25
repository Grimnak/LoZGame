namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public class EntityManager : IManager
    {
        private ProjectileManager projectile;
        private ExplosionManager explosion;
        private EnemyProjectileManager enemyProjectile;
        private List<IProjectile> friendlyProjectiles;
        private List<IProjectile> hostileProjectiles;

        public EntityManager()
        {
            explosion = new ExplosionManager();
            projectile = new ProjectileManager();
            enemyProjectile = new EnemyProjectileManager();
            friendlyProjectiles = new List<IProjectile>();
            hostileProjectiles = new List<IProjectile>();
        }

        public List<IProjectile> EnemyProjectiles { get { return hostileProjectiles; } }

        public List<IProjectile> PlayerProjectiles { get { return friendlyProjectiles; } }

        public ProjectileManager ProjectileManager => projectile;

        public EnemyProjectileManager EnemyProjectileManager => enemyProjectile;

        public ExplosionManager ExplosionManager => explosion;

        public bool BoomerangOut => projectile.BoomerangOut;

        public void Update()
        {
            projectile.Update();
            explosion.Update();
            EnemyProjectileManager.Update();
            friendlyProjectiles.Clear();
            hostileProjectiles.Clear();
            foreach (IProjectile projectile in projectile.Projectiles)
            {
                friendlyProjectiles.Add(projectile);
            }
            foreach (IProjectile explosion in explosion.Explosions)
            {
                friendlyProjectiles.Add(explosion);
            }
            foreach (IProjectile projectile in enemyProjectile.Projectiles)
            {
                hostileProjectiles.Add(projectile);
            }
            foreach (IProjectile explosion in explosion.Explosions)
            {
                hostileProjectiles.Add(explosion);
            }

        }

        public void Draw()
        {
            projectile.Draw();
            explosion.Draw();
            enemyProjectile.Draw();
        }

        public void Clear()
        {
            explosion = new ExplosionManager();
            projectile = new ProjectileManager();
            enemyProjectile = new EnemyProjectileManager();
        }
    }
}