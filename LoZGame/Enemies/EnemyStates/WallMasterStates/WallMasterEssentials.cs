namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using static RandomStateGenerator;
    public partial class WallMasterEssentials : EnemyStateEssentials, IEnemyState
    {
        public void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingWallMasterState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingWallMasterState(this.Enemy);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingWallMasterState(this.Enemy);
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
            this.Enemy.CurrentState = new AttackingWallMasterState(this.Enemy);

        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadWallMasterState(this.Enemy);
        }

        public virtual void Stun(int stunTime)
        {
            this.Enemy.CurrentState = new StunnedWallMasterState(this.Enemy, this, stunTime);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(3);
            }
            base.Update();
        }
    }
}