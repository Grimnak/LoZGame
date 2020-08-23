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
            EnemyEssentials.EnemyAI.MoldormHead,
            EnemyEssentials.EnemyAI.Segment,
            EnemyEssentials.EnemyAI.WallMaster,
            EnemyEssentials.EnemyAI.Patra,
            EnemyEssentials.EnemyAI.MiniPatra
        };

        public BlockCollisionHandler(IBlock block)
        {
            this.block = block;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            bool movable = true;
            if (!(player.State is GrabbedState) && block is MovableBlock)
            {
                switch (collisionSide)
                {
                    case CollisionDetection.CollisionSide.Top:
                        movable = !block.InvalidDirections.Contains(MovableBlock.InvalidDirection.North);
                        break;
                    case CollisionDetection.CollisionSide.Bottom:
                        movable = !block.InvalidDirections.Contains(MovableBlock.InvalidDirection.South);
                        break;
                    case CollisionDetection.CollisionSide.Right:
                        movable = !block.InvalidDirections.Contains(MovableBlock.InvalidDirection.East);
                        break;
                    case CollisionDetection.CollisionSide.Left:
                        movable = !block.InvalidDirections.Contains(MovableBlock.InvalidDirection.West);
                        break;
                }
                if (movable)
                {
                    DeterminePushVelocity(player, collisionSide);
                }
                SetBounds(block.Physics, player.Physics, collisionSide);
            }
            else if (block is Tile)
            {
                SoundFactory.Instance.PlayClimbStairs();
            }
            else if (block is BlockTile)
            {
                if (!(player.State is GrabbedState))
                {
                    SetBounds(block.Physics, player.Physics, collisionSide);
                }
            }
            else if (block is CrossableTile)
            {
                if (!(player.State is GrabbedState) && (!player.Inventory.HasLadder || player.Inventory.LadderInUse))
                {
                    if (!((CrossableTile)block).BeingCrossed)
                    {
                        SetBounds(block.Physics, player.Physics, collisionSide);
                    }
                }
            }
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (!collisionBlackList.Contains(enemy.AI))
            {
                if (enemy.AI != EnemyEssentials.EnemyAI.PolsVoice)
                {
                    SetBounds(block.Physics, enemy.Physics, collisionSide);
                }
            }
        }

        private void DeterminePushVelocity(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            DeterminePushDirection(collisionSide);
            block.Physics.MovementVelocity = new Vector2(xDirection * (int)player.MoveSpeed, yDirection * (int)player.MoveSpeed);
            block.Physics.MovementAcceleration = new Vector2(xDirection * GameData.Instance.CollisionConstants.MovableBlockAcceleration, yDirection * GameData.Instance.CollisionConstants.MovableBlockAcceleration);
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