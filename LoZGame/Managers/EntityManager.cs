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

        public EntityManager()
        {
            this.explosion = new ExplosionManager();
            this.projectile = new ProjectileManager();
            this.enemyProjectile = new EnemyProjectileManager();
            this.friendlyProjectiles = new List<IProjectile>();
        }

        public List<IProjectile> EnemyProjectiles { get { return this.enemyProjectile.Projectiles; } }

        public List<IProjectile> PlayerProjectiles { get { return this.friendlyProjectiles; } }

        public ProjectileManager ProjectileManager => this.projectile;

        public EnemyProjectileManager EnemyProjectileManager => this.enemyProjectile;

        public ExplosionManager ExplosionManager => this.explosion;

        public bool BoomerangOut => this.projectile.BoomerangOut;

        public void Update()
        {
            this.projectile.Update();
            this.explosion.Update();
            this.EnemyProjectileManager.Update();
            this.friendlyProjectiles.Clear();
            foreach (IProjectile projectile in this.projectile.Projectiles)
            {
                this.friendlyProjectiles.Add(projectile);
            }
            foreach (IProjectile explosion in this.explosion.Explosions)
            {
                this.friendlyProjectiles.Add(explosion);
            }

        }

        public void Draw()
        {
            this.projectile.Draw();
            this.explosion.Draw();
            this.enemyProjectile.Draw();
        }

        public void Clear()
        {
            this.explosion = new ExplosionManager();
            this.projectile = new ProjectileManager();
            this.enemyProjectile = new EnemyProjectileManager();
        }
    }
}