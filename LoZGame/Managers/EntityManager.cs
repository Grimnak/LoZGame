﻿namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public class EntityManager
    {
        private ProjectileManager projectile;
        private ExplosionManager explosion;
        private EnemyProjectileManager enemyProjectile;

        public EntityManager()
        {
            this.explosion = new ExplosionManager();
            this.projectile = new ProjectileManager();
            this.enemyProjectile = new EnemyProjectileManager();
        }

        public ProjectileManager ProjectileManager => this.projectile;

        public EnemyProjectileManager EnemyProjectileManager => this.enemyProjectile;

        public ExplosionManager ExplosionManager => this.explosion;

        public bool BoomerangOut => this.projectile.BoomerangOut;

        public void Update()
        {
            this.projectile.Update();
            this.explosion.Update();
            this.EnemyProjectileManager.Update();
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