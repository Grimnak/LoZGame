﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class EnemyCollisionHandler
    {
        private IEnemy enemy;

        public EnemyCollisionHandler(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
            if (block is BlockTile || block is MovableTile)
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.enemy.Physics.Location = new Vector2(block.Physics.Location.X - EnemySpriteFactory.GetEnemyWidth(enemy), this.enemy.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.enemy.Physics.Location = new Vector2(block.Physics.Location.X + BlockSpriteFactory.Instance.TileWidth, this.enemy.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, block.Physics.Location.Y + BlockSpriteFactory.Instance.TileHeight);
                }
                else
                {
                    this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, block.Physics.Location.Y - EnemySpriteFactory.GetEnemyHeight(enemy));
                }
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            this.enemy.TakeDamage(1);
        }
    }
}