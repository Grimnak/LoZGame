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
            this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
            this.Enemy.CurrentState = new LeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
            this.Enemy.CurrentState = new RightMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUp()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpMovingEnemyState(this.Enemy);
        }

        public virtual void MoveDown()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUpLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpLeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveUpRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpRightMovingEnemyState(this.Enemy);
        }

        public virtual void MoveDownLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownLeftMovingEnemyState(this.Enemy);
        }

        public virtual void MoveDownRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownRightMovingEnemyState(this.Enemy);
        }

        public virtual void JumpLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
            this.Enemy.CurrentState = new LeftJumpingEnemyState(this.Enemy);
        }

        public virtual void JumpRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
            this.Enemy.CurrentState = new RightJumpingEnemyState(this.Enemy);
        }

        public virtual void JumpUp()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpJumpingEnemyState(this.Enemy);
        }

        public virtual void JumpDown()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownJumpingEnemyState(this.Enemy);
        }

        public virtual void JumpUpLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpLeftJumpingEnemyState(this.Enemy);
        }

        public virtual void JumpUpRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpRightJumpingEnemyState(this.Enemy);
        }

        public virtual void JumpDownLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownLeftJumpingEnemyState(this.Enemy);
        }

        public virtual void JumpDownRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownRightJumpingEnemyState(this.Enemy);
        }

        public virtual void Attack()
        {
            this.Enemy.Attack();
        }

        public virtual void Stop()
        {
            this.Enemy.CurrentState = new IdleEnemyState(this.Enemy);
        }

        public virtual void Die()
        {
            if (this.Enemy.IsDead)
            {
                this.Enemy.CurrentState = new DeadEnemyState(this.Enemy);
            }
        }

        public virtual void Spawn()
        {
            if (!this.spawnBlackList.Contains(this.Enemy.AI))
            {
                this.Enemy.CurrentState = new SpawnEnemyState(this.Enemy);
            }
        }

        public virtual void Stun(int stunTime)
        {
            if (!(this.Enemy.IsSpawning || this.Enemy.IsDead))
            {
                this.Enemy.CurrentState = new StunnedEnemyState(this.Enemy, this.Enemy.CurrentState, stunTime);
            }
        }
    }
}