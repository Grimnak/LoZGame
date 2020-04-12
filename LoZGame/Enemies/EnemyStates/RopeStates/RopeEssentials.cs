namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public class RopeEssentials : EnemyStateEssentials,  IEnemyState
    {
        public void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingRopeState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingRopeState(this.Enemy);
        }

        public void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingRopeState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingRopeState(this.Enemy);
        }

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
        }

        public void Attack()
        {
            this.Enemy.CurrentState = new AttackingRopeState(this.Enemy);
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadRopeState(this.Enemy);
        }

        public virtual void Stun(int stunTime)
        {
            this.Enemy.CurrentState = new StunnedRopeState(this.Enemy, this, stunTime);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(2);
            }
            base.Update();
            if (!(this.Enemy.CurrentState is AttackingRopeState))
            {
                this.CheckForLink();
            }
        }

        private void CheckForLink()
        {
            int ropeX = (int)this.Enemy.Physics.Location.X;
            int ropeY = (int)this.Enemy.Physics.Location.Y;
            int linkX = (int)LoZGame.Instance.Link.Physics.Location.X;
            int linkY = (int)LoZGame.Instance.Link.Physics.Location.Y;

            if (Math.Abs(ropeX - linkX) <= GameData.Instance.EnemyMiscData.RopeLinkPixelBuffer)
            {
                if ((linkY - ropeY) > 0)
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
                }
                else
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
                }
                this.Enemy.CurrentState.Attack();
            }
            else if (Math.Abs(ropeY - linkY) <= GameData.Instance.EnemyMiscData.RopeLinkPixelBuffer)
            {
                if ((linkX - ropeX) > 0)
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
                }
                else
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
                }
                this.Enemy.CurrentState.Attack();
            }
        }
    }
}