﻿namespace LoZClone
{
    using System;
    using System.Linq;
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
            bool movable = true;
            if (!(player.State is GrabbedState) && this.block is MovableTile)
            {
                foreach (string direction in this.block.InvalidDirections ?? Enumerable.Empty<string>())
                {
                    switch (direction)
                    {
                        case "N":
                            movable = !(collisionSide == CollisionDetection.CollisionSide.Bottom);
                            break;
                        case "S":
                            movable = !(collisionSide == CollisionDetection.CollisionSide.Top);
                            break;
                        case "E":
                            movable = !(collisionSide == CollisionDetection.CollisionSide.Right);
                            break;
                        case "W":
                            movable = !(collisionSide == CollisionDetection.CollisionSide.Left);
                            break;
                    }
                }
                if (movable)
                {
                    DeterminePushVelocity(player, collisionSide);
                }
            }
            else if (this.block is Tile)
            {
                LoZGame.Instance.CollisionDetector.MoveToBasement = true;
            }
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                this.block.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, this.block.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                this.block.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, this.block.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.block.Physics.Location = new Vector2(this.block.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                this.block.Physics.Location = new Vector2(this.block.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
            }
        }

        private void DeterminePushVelocity(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            DeterminePushDirection(collisionSide);
            this.block.Physics.Velocity = new Vector2(xDirection * (int)player.MoveSpeed, yDirection * (int)player.MoveSpeed);
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