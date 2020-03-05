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

        public bool OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandle)
            {
                this.projectile.Physics.Velocity = new Vector2(0, 0);
                this.projectile.Physics.Acceleration = new Vector2(0, 0);
            }
            else if (this.projectile is Boomerang || this.projectile is MagicBoomerang)
            {
                boomerangReturning = true;
            } else if(this.projectile is Bomb || this.projectile is BombExplosion || this.projectile is SwordBeamExplosion)
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
            bool boomerangReturning = false;
            if (this.projectile is Boomerang || this.projectile is MagicBoomerang)
            {
            }
            else if (this.projectile is Boomerang || this.projectile is MagicBoomerang)
            {
            }
            else
            {
            }
            return boomerangReturning;
        }

        public bool OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;

            if (!(block is Tile))
            {
                if (this.projectile is BlueCandleProjectile || this.projectile is RedCandle)
                {
                    this.projectile.Physics.Velocity = new Vector2(0, 0);
                    this.projectile.Physics.Acceleration = new Vector2(0, 0);
                }
                else if (this.projectile is Boomerang || this.projectile is MagicBoomerang || this.projectile is BoomerangEnemy)
                {
                    boomerangReturning = true;
                }
                else if (this.projectile is Bomb)
                {
                    this.PushOut(collisionSide);
                }
                else
                {
                }
            }
            return boomerangReturning;
        }

        public bool OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;
            if (this.projectile is BlueCandleProjectile || this.projectile is RedCandle)
            {
                this.projectile.Physics.Velocity = new Vector2(0, 0);
                this.projectile.Physics.Acceleration = new Vector2(0, 0);
            }
            else if (this.projectile is Boomerang || this.projectile is MagicBoomerang)
            {
                boomerangReturning = true;
            }
            else if (this.projectile is Bomb) 
            {
                this.PushOut(collisionSide);
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
        
        public bool OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            bool boomerangReturning = false;
            if (this.projectile is BoomerangEnemy || this.projectile is MagicBoomerangEnemy)
            {
                boomerangReturning = true;
            }
            else
            {
            }
            return boomerangReturning;
        }

        private void PushOut(CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, this.projectile.Physics.Location.Y + 1);
            } else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X, this.projectile.Physics.Location.Y - 1);
            } else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X + 1, this.projectile.Physics.Location.Y);
            } else if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                this.projectile.Physics.Location = new Vector2(this.projectile.Physics.Location.X - 1, this.projectile.Physics.Location.Y);
            }
        }
    }
}