﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class OldMan : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Vector2 CurrentLocation
        {
            get; set;
        }

        public int Health { get; set; }

        private readonly OldManSprite sprite;

        public OldMan(Vector2 location)
        {
            this.CurrentLocation = new Vector2(location.X, location.Y);
            this.sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
            this.bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
        }

        public void TakeDamage()
        {
        }

        public void Die()
        {
        }

        public void Update()
        {
            this.sprite.Update();
            this.bounds.X = (int)this.CurrentLocation.X;
            this.bounds.Y = (int)this.CurrentLocation.Y;
        }

        public void Draw()
        {
            this.sprite.Draw(this.CurrentLocation, Color.White);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }
    }
}
