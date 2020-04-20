namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;

    public class BlockCollisionHandler : CollisionInteractions
    {
        private IBlock block;
        private float xDirection;
        private float yDirection;

        private List<EnemyEssentials.EnemyAI> collisionBlackList = new List<EnemyEssentials.EnemyAI>()
        {
            EnemyEssentials.EnemyAI.Keese,
            EnemyEssentials.EnemyAI.Manhandla,
            EnemyEssentials.EnemyAI.ManHandlaHead,
            EnemyEssentials.EnemyAI.NoAI,
            EnemyEssentials.EnemyAI.WallMaster
        };

        public BlockCollisionHandler(IBlock block)
        {
            this.block = block;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            bool movable = true;
            if (!(player.State is GrabbedState) && this.block is MovableTile)
            {
                foreach (MovableTile.InvalidDirection invalid in this.block.InvalidDirections)
                {
                    switch (invalid)
                    {
                        case MovableTile.InvalidDirection.North:
                            movable = !(collisionSide == CollisionDetection.CollisionSide.Bottom);
                            break;
                        case MovableTile.InvalidDirection.South:
                            movable = !(collisionSide == CollisionDetection.CollisionSide.Top);
                            break;
                        case MovableTile.InvalidDirection.East:
                            movable = !(collisionSide == CollisionDetection.CollisionSide.Right);
                            break;
                        case MovableTile.InvalidDirection.West:
                            movable = !(collisionSide == CollisionDetection.CollisionSide.Left);
                            break;
                    }
                }
                if (movable)
                {
                    DeterminePushVelocity(player, collisionSide);
                }
                this.SetBounds(this.block.Physics, player.Physics, collisionSide);
            }
            else if (this.block is Tile)
            {
                SoundFactory.Instance.PlayClimbStairs();
                LoZGame.Instance.CollisionDetector.MoveToBasement = true;
            }
            else if (block is BlockTile)
            {
                if (!(player.State is GrabbedState))
                {
                    this.SetBounds(this.block.Physics, player.Physics, collisionSide);
                }
            }
            else if (block is CrossableTile)
            {
                if (!(player.State is GrabbedState) && !player.Inventory.HasLadder)
                {
                    this.SetBounds(this.block.Physics, player.Physics, collisionSide);
                }
            }
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (!collisionBlackList.Contains(enemy.AI))
            {
                this.SetBounds(this.block.Physics, enemy.Physics, collisionSide);
            }
        }

        private void DeterminePushVelocity(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            DeterminePushDirection(collisionSide);
            this.block.Physics.MovementVelocity = new Vector2(xDirection * (int)player.MoveSpeed, yDirection * (int)player.MoveSpeed);
            this.block.Physics.MovementAcceleration = new Vector2(xDirection * GameData.Instance.CollisionConstants.MovableBlockAcceleration, yDirection * GameData.Instance.CollisionConstants.MovableBlockAcceleration);
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