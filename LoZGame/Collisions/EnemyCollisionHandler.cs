namespace LoZClone
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
            if (enemy is WallMaster) {
                    this.enemy.CurrentState.Attack();
                    this.enemy.Physics.Location = player.Physics.Location;

                    // Player velocity is changed here rather than player collision because player collision is checked before new wallmaster velocity is set
                    player.Physics.Velocity = this.enemy.Physics.Velocity;
            }
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
            if (!(this.enemy.CurrentState is AttackingWallMasterState))
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
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            this.enemy.TakeDamage(projectile.Damage);
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                this.enemy.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, this.enemy.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                this.enemy.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, this.enemy.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
            }
        }
    }
}