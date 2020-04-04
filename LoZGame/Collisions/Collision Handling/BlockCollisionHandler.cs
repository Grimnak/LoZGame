namespace LoZClone
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;

    public class BlockCollisionHandler : CollisionInteractions
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
                /*else
                {
                    this.SetBlockBounds(this.block.Physics, player.Physics, collisionSide);
                }*/
                this.SetBlockBounds(this.block.Physics, player.Physics, collisionSide);
            }
            else if (this.block is Tile)
            {
                SoundEffectsFactory.Instance.PlayClimbStairs();
                LoZGame.Instance.CollisionDetector.MoveToBasement = true;
            }
            else if (block is BlockTile)
            {
                this.SetBlockBounds(this.block.Physics, player.Physics, collisionSide);
            }
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (!(enemy is Keese))
            {
                this.SetBlockBounds(this.block.Physics, enemy.Physics, collisionSide);
            }
        }

        private void DeterminePushVelocity(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            DeterminePushDirection(collisionSide);
            this.block.Physics.MovementVelocity = new Vector2(xDirection * (int)player.MoveSpeed, yDirection * (int)player.MoveSpeed);
            this.block.Physics.MovementAcceleration = new Vector2(xDirection * Acceleration, yDirection * Acceleration);
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