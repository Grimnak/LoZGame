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

        public bool OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;
            if (this.projectile is BoomerangProjectile || this.projectile is MagicBoomerangProjectile)
            {
                boomerangReturning = true;
            }
            else if (this.projectile is BlueCandleProjectile || this.projectile is RedCandleProjectile || this.projectile is BombProjectile || this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
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
            else
            {
                this.projectile.IsExpired = true;
            }
            return boomerangReturning;
        }

        /*private void PushOut(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            if (((BlueCandleProjectile)projectile).Direction.Equals("Up"))
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, projectile.Physics.Location.Y + BlockSpriteFactory.Instance.TileHeight);
            }
            else if (((BlueCandleProjectile)projectile).Direction.Equals("Bottom"))
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, projectile.Physics.Location.Y - ProjectileSpriteFactory.GetProjectileHeight(this.projectile));
            }
            else if (((BlueCandleProjectile)projectile).Direction.Equals("Left"))
            {
                this.projectile.Physics.Location = new Vector2(projectile.Physics.Location.X + BlockSpriteFactory.Instance.TileWidth, this.projectile.Physics.Location.Y);
            }
            else if (((BlueCandleProjectile)projectile).Direction.Equals("Right"))
            {
                this.projectile.Physics.Location = new Vector2(projectile.Physics.Location.X - ProjectileSpriteFactory.GetProjectileWidth(this.projectile), this.projectile.Physics.Location.Y);
            }
        }*/
    }
}