﻿namespace LoZClone
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
            if (!(enemy is OldMan || enemy is Merchant))
            {
                DeterminePushbackValues(collisionSide);
                this.player.TakeDamage();
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            this.player.TakeDamage();
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
            if (block is BlockTile || block is MovableTile)
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.player.Physics.Location = new Vector2(block.Physics.Location.X - LinkSpriteFactory.LinkWidth, this.player.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.player.Physics.Location = new Vector2(block.Physics.Location.X + LoZGame.Instance.TileWidth, this.player.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.player.Physics.Location = new Vector2(this.player.Physics.Location.X, block.Physics.Location.Y + LoZGame.Instance.TileHeight);
                }
                else
                {
                    this.player.Physics.Location = new Vector2(this.player.Physics.Location.X, block.Physics.Location.Y - LinkSpriteFactory.LinkHeight);
                }
            }
        }

        private void DeterminePushbackValues(CollisionDetection.CollisionSide collisionSide)
        {
            if (this.player.DamageTimer <= 0)
            {
                DeterminePushbackDirection(collisionSide);
                this.player.Physics.Velocity = new Vector2(xDirection * Speed, yDirection * Speed);
                this.player.Physics.Acceleration = new Vector2(xDirection * Acceleration, yDirection * Acceleration);
            }
        }

        private void DeterminePushbackDirection(CollisionDetection.CollisionSide collisionSide)
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