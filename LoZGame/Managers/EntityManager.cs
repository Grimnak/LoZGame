﻿namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public class EntityManager
    {
        private ProjectileManager projectile;
        private ExplosionManager explosion;
        private EnemyProjectileManager enemyProjectile;

        private static readonly EntityManager instance = new EntityManager();

        public static EntityManager Instance
        {
            get
            {
                return instance;
            }
        }

        private EntityManager()
        {
            this.explosion = new ExplosionManager();
            this.projectile = new ProjectileManager(this.explosion);
            this.enemyProjectile = new EnemyProjectileManager();
        }

        public ProjectileManager ProjectileManager => this.projectile;

        public EnemyProjectileManager EnemyProjectileManager => this.enemyProjectile;

        public bool BoomerangOut => this.projectile.BoomerangOut;

        public void Update()
        {
            this.projectile.Update();
            this.explosion.Update();
            this.EnemyProjectileManager.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.projectile.Draw(spriteBatch);
            this.explosion.Draw(spriteBatch);
            this.enemyProjectile.Draw(spriteBatch);
        }

        public void Clear()
        {
            this.explosion = new ExplosionManager();
            this.projectile = new ProjectileManager(this.explosion);
            this.enemyProjectile = new EnemyProjectileManager();
        }
    }
}