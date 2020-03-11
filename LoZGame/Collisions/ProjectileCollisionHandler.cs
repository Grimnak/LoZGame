namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class ProjectileCollisionHandler
    {
        private IProjectile projectile;

        public ProjectileCollisionHandler(IProjectile projectile)
        {
            this.projectile = projectile;
        }

        public bool OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile)
            {
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile)
            {
                boomerangReturning = true;
            }
            else if (this.projectile is BombProjectile || this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
            {
                // do nothing
            }
            else
            {
                this.projectile.IsExpired = true;
            }
            return boomerangReturning;
        }

        public bool OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
            return false;
        }
        
        public bool OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;
            if (this.projectile is BoomerangEnemy || this.projectile is MagicBoomerangEnemy)
            {
                boomerangReturning = true;
            }
            return boomerangReturning;
        }

        public bool OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile)
            {
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile || this.projectile is BoomerangEnemy)
            {
                boomerangReturning = true;
            }
            else if (this.projectile is BombProjectile || this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
            {
                // do nothing
            }
            else
            {
                this.projectile.IsExpired = true;
            }
            return boomerangReturning;
        }

        public bool OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;
            if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile || this.projectile is BoomerangEnemy)
            {
                boomerangReturning = true;
            }
            else if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile || this.projectile is BombProjectile)
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.projectile.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, this.projectile.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.projectile.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, this.projectile.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
                {
                    this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
                }
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
            {
                // do nothing
            }
            else
            {
                this.projectile.IsExpired = true;
            }
            return boomerangReturning;
        }

        private void PushOut(CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, this.projectile.Physics.Location.Y + 1);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, this.projectile.Physics.Location.Y - 1);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X + 1, this.projectile.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X - 1, this.projectile.Physics.Location.Y);
            }
        }
    }
}