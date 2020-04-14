namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FireSnakeEssentials : EnemyStateEssentials, IEnemyState
    {
        public void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingFireSnakeState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingFireSnakeState(this.Enemy);
        }

        public void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingFireSnakeState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingFireSnakeState(this.Enemy);
        }

        public void MoveUpLeft()
        {
            this.Enemy.CurrentState = new UpLeftMovingFireSnakeState(this.Enemy);
        }

        public void MoveUpRight()
        {
            this.Enemy.CurrentState = new UpRightMovingFireSnakeState(this.Enemy);
        }

        public void MoveDownLeft()
        {
            this.Enemy.CurrentState = new DownLeftMovingFireSnakeState(this.Enemy);
        }

        public void MoveDownRight()
        {
            this.Enemy.CurrentState = new DownRightMovingFireSnakeState(this.Enemy);
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadFireSnakeState(this.Enemy);
        }

        public void Stun(int stunTime)
        {
        }

        public override void Update()
        {
            if (this.Lifetime % (DirectionChange / 4) == 0 && this.Lifetime != 0)
            {
                this.Enemy.UpdateChild();
            }
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.FireSnakeFavorCardinalValue);
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.FireSnakeFavorDiagonalValue);
            }
            base.Update();
        }
    }
}