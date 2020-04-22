namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using static RandomStateGenerator;
    using static EnemyEssentials;

    public partial class EnemyStateEssentials
    {
        public virtual void MoveLeft()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.West;
            Enemy.CurrentState = new LeftMovingEnemyState(Enemy);
        }

        public virtual void MoveRight()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.East;
            Enemy.CurrentState = new RightMovingEnemyState(Enemy);
        }

        public virtual void MoveUp()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.North;
            Enemy.CurrentState = new UpMovingEnemyState(Enemy);
        }

        public virtual void MoveDown()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.South;
            Enemy.CurrentState = new DownMovingEnemyState(Enemy);
        }

        public virtual void MoveUpLeft()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.North;
            Enemy.CurrentState = new UpLeftMovingEnemyState(Enemy);
        }

        public virtual void MoveUpRight()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.North;
            Enemy.CurrentState = new UpRightMovingEnemyState(Enemy);
        }

        public virtual void MoveDownLeft()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.South;
            Enemy.CurrentState = new DownLeftMovingEnemyState(Enemy);
        }

        public virtual void MoveDownRight()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.South;
            Enemy.CurrentState = new DownRightMovingEnemyState(Enemy);
        }

        public virtual void JumpLeft()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.West;
            Enemy.CurrentState = new LeftJumpingEnemyState(Enemy);
        }

        public virtual void JumpRight()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.East;
            Enemy.CurrentState = new RightJumpingEnemyState(Enemy);
        }

        public virtual void JumpUp()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.North;
            Enemy.CurrentState = new UpJumpingEnemyState(Enemy);
        }

        public virtual void JumpDown()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.South;
            Enemy.CurrentState = new DownJumpingEnemyState(Enemy);
        }

        public virtual void JumpUpLeft()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.North;
            Enemy.CurrentState = new UpLeftJumpingEnemyState(Enemy);
        }

        public virtual void JumpUpRight()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.North;
            Enemy.CurrentState = new UpRightJumpingEnemyState(Enemy);
        }

        public virtual void JumpDownLeft()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.South;
            Enemy.CurrentState = new DownLeftJumpingEnemyState(Enemy);
        }

        public virtual void JumpDownRight()
        {
            Enemy.Physics.CurrentDirection = Physics.Direction.South;
            Enemy.CurrentState = new DownRightJumpingEnemyState(Enemy);
        }

        public virtual void Attack()
        {
            Enemy.Attack();
        }

        public virtual void Stop()
        {
            Enemy.CurrentState = new IdleEnemyState(Enemy);
        }

        public virtual void Die()
        {
            if (Enemy.IsDead)
            {
                Enemy.CurrentState = new DeadEnemyState(Enemy);
            }
        }

        public virtual void Spawn()
        {
            if (!spawnBlackList.Contains(Enemy.AI))
            {
                Enemy.CurrentState = new SpawnEnemyState(Enemy);
            }
        }

        public virtual void Stun(int stunTime)
        {
            if (!(Enemy.IsSpawning || Enemy.IsDead))
            {
                Enemy.CurrentState = new StunnedEnemyState(Enemy, Enemy.CurrentState, stunTime);
            }
        }
    }
}