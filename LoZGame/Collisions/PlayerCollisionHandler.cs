namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class PlayerCollisionHandler
    {
        private IPlayer player;
        private float xDirection;
        private float yDirection;
        private const float Speed = 10;
        private const float Acceleration = -0.5f;

        public PlayerCollisionHandler(IPlayer player)
        {
            this.player = player;
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            DeterminePushbackValues(collisionSide);
            this.player.TakeDamage();
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            this.player.TakeDamage();
        }

        private void DeterminePushbackValues(CollisionDetection.CollisionSide collisionSide)
        {
            if (this.player.DamageTimer <= 0)
            {
                DetermineCollisionSide(collisionSide);
                this.player.Velocity = new Vector2(xDirection * Speed, yDirection * Speed);
                this.player.Acceleration = new Vector2(xDirection * Acceleration, yDirection * Acceleration);
            }
        }

        private void DetermineCollisionSide(CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                xDirection = 0;
                yDirection = 1;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                xDirection = 0;
                yDirection = -1;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                xDirection = 1;
                yDirection = 0;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                xDirection = -1;
                yDirection = 0;
            }
        }
    }
}