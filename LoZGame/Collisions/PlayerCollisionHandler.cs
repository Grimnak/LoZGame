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
            if (!(enemy is OldMan || enemy is Merchant || enemy is WallMaster))
            {
                DeterminePushbackValues(collisionSide);
                this.player.TakeDamage(enemy.Damage);
            }
            else if (enemy is WallMaster)
            {
                this.player.State = new ImmobileState(player);
            }
        }

        public void OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
            if (item.PickUpItemTime >= 0)
            {
                item.Physics.Location = new Vector2(player.Physics.Location.X + 5, player.Physics.Location.Y - 45);
                this.player.State = new PickupItemState(player, item);
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            this.player.TakeDamage(projectile.Damage);
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
            if (!(player.State is ImmobileState))
            {
                if (block is BlockTile || block is MovableTile)
                {
                    if (collisionSide == CollisionDetection.CollisionSide.Right)
                    {
                        this.player.Physics.Location = new Vector2(block.Physics.Location.X - LinkSpriteFactory.LinkWidth, this.player.Physics.Location.Y);
                    }
                    else if (collisionSide == CollisionDetection.CollisionSide.Left)
                    {
                        this.player.Physics.Location = new Vector2(block.Physics.Location.X + BlockSpriteFactory.Instance.TileWidth, this.player.Physics.Location.Y);
                    }
                    else if (collisionSide == CollisionDetection.CollisionSide.Top)
                    {
                        this.player.Physics.Location = new Vector2(this.player.Physics.Location.X, block.Physics.Location.Y + BlockSpriteFactory.Instance.TileHeight);
                    }
                    else
                    {
                        this.player.Physics.Location = new Vector2(this.player.Physics.Location.X, block.Physics.Location.Y - LinkSpriteFactory.LinkHeight);
                    }
                }
            }
        }

        public void OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                this.player.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, this.player.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                this.player.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, this.player.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.player.Physics.Location = new Vector2(this.player.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                this.player.Physics.Location = new Vector2(this.player.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
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