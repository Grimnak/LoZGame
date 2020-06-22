namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class ProjectileCollisionHandler : CollisionInteractions
    {
        private IProjectile projectile;

        public ProjectileCollisionHandler(IProjectile projectile)
        {
            this.projectile = projectile;
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (!enemy.IsTransparent)
            {
                if (projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile)
                {
                    enemy.Stun(projectile.StunDuration);
                    projectile.Returning = true;
                }
                else if (projectile is BlueCandleProjectile || projectile is RedCandleProjectile)
                {
                    projectile.Physics.StopMovement();
                }
                else if (projectile is BombProjectile || projectile is BombExplosion || projectile is SwordBeamExplosion || projectile is SwordProjectile)
                {
                    // do nothing
                }
                else
                {
                    projectile.IsExpired = true;
                }
            }
        }

        public void OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
        }

        /// <summary>
        /// Used to optionally expire projectiles that collide with blocks.
        /// </summary>
        /// <param name="block">This is the block that is collided with by the projectile.</param>
        /// <param name="collisionSide">This is the side of the block that the projectile collides with..</param>
        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
            if (!block.IsTransparent)
            {
                projectile.IsExpired = true;
            }
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            if (projectile is BlueCandleProjectile || projectile is RedCandleProjectile || projectile is BombProjectile)
            {
                projectile.Physics.StopMovement();
            }
            else if (projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile)
            {
                projectile.Returning = true;
            }
            else if (projectile is BombExplosion)
            {
                // do nothing
            }
            else
            {
                projectile.IsExpired = true;
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile)
            {
                projectile.Returning = true;
            }
            else if (projectile is BlueCandleProjectile || projectile is RedCandleProjectile || projectile is BombProjectile)
            {
                SetBounds(projectile.Physics, collisionSide);
                projectile.Physics.SetLocation();
            }
            else if (projectile is BombExplosion || projectile is SwordBeamExplosion)
            {
                // do nothing
            }
            else
            {
                projectile.IsExpired = true;
            }
        }
    }
}