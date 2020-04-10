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
            if (!(projectile.IsExpired && (enemy is OldMan || enemy is Merchant || enemy is SpikeCross)))
            {
                if (projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile)
                {
                    enemy.Stun(projectile.StunDuration);
                }
            }
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile)
            {
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile)
            {
                this.projectile.Returning = true;
            }
            else if (this.projectile is BombProjectile || this.projectile is BombExplosion || this.projectile is SwordBeamExplosion || this.projectile is WoodenSwordProjectile)
            {
                // do nothing
            }
            else
            {
                this.projectile.IsExpired = true;
            }
        }

        public void OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
        }
        
        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile)
            {
                this.projectile.Returning = true;
                player.Stun(projectile.StunDuration);
            }
        }

        public void OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile || this.projectile is BombProjectile)
            {
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile)
            {
                this.projectile.Returning = true;
            }
            else if (this.projectile is BombExplosion)
            {
                // do nothing
            }
            else
            {
                this.projectile.IsExpired = true;
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile)
            {
                this.projectile.Returning = true;
            }
            else if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile || this.projectile is BombProjectile)
            {
                this.SetRoomBounds(this.projectile.Physics, collisionSide);
                this.projectile.Physics.SetLocation();
            }
            else if (this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
            {
                // do nothing
            }
            else
            {
                this.projectile.IsExpired = true;
            }
        }
    }
}