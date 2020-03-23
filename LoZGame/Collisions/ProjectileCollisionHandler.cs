﻿namespace LoZClone
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

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile)
            {
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile)
            {
                this.projectile.Returning = true;
            }
            else if (this.projectile is BombProjectile || this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
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
            if (this.projectile is BoomerangEnemy || this.projectile is MagicBoomerangEnemy)
            {
                this.projectile.Returning = true;
            }
        }

        public void OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile || this.projectile is BombProjectile)
            {
                this.projectile.Physics.StopMovement();
            }
            else if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile || this.projectile is BoomerangEnemy || this.projectile is MagicBoomerangEnemy)
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
            if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile || this.projectile is BoomerangEnemy || this.projectile is MagicBoomerangEnemy)
            {
                this.projectile.Returning = true;
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
        }
    }
}