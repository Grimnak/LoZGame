namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class BlockCollisionHandler
    {
        private IBlock block;
        private float xDirection;
        private float yDirection;
        private const float Acceleration = -0.5f;

        public BlockCollisionHandler(IBlock block)
        {
            this.block = block;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            if (!(player.State is ImmobileState))
            {
                if (this.block is MovableTile)
                {
                    DeterminePushVelocity(player, collisionSide);
                }
            }
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(IBlock targetBlock, CollisionDetection.CollisionSide collisionSide)
        {
            /*if (this.block != targetBlock && this.block is MovableTile && !(targetBlock is Tile))
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.block.Physics.Location = new Vector2(targetBlock.Physics.Location.X - LoZGame.Instance.TileWidth, this.block.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.block.Physics.Location = new Vector2(targetBlock.Physics.Location.X + LoZGame.Instance.TileWidth, this.block.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.block.Physics.Location = new Vector2(this.block.Physics.Location.X, targetBlock.Physics.Location.Y + LoZGame.Instance.TileHeight);
                }
                else
                {
                    this.block.Physics.Location = new Vector2(this.block.Physics.Location.X, targetBlock.Physics.Location.Y - LoZGame.Instance.TileHeight);
                }
            }*/
        }

        private void DeterminePushVelocity(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            DeterminePushDirection(collisionSide);
            this.block.Physics.Velocity = new Vector2(xDirection * player.MoveSpeed, yDirection * player.MoveSpeed);
            this.block.Physics.Acceleration = new Vector2(xDirection * Acceleration, yDirection * Acceleration);
        }

        private void DeterminePushDirection(CollisionDetection.CollisionSide collisionSide)
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