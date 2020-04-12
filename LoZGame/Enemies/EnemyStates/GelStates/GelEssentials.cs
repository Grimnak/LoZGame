namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class GelEssentials : EnemyStateEssentials, IEnemyState
    {
        private static readonly int minMovementTime = LoZGame.Instance.UpdateSpeed;
        private static readonly int maxMovementTime = LoZGame.Instance.UpdateSpeed * 4;
        private static readonly int minIdleTime = LoZGame.Instance.UpdateSpeed;
        private static readonly int maxIdleTime = LoZGame.Instance.UpdateSpeed * 2;
        private int movementTime;
        private int idleTime;
        private bool moving;

        public void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingGelState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingGelState(this.Enemy);
        }

        public void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingGelState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingGelState(this.Enemy);
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
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadGelState(this.Enemy);
        }

        public void Stun(int stunTime)
        {
            this.Enemy.TakeDamage(GameData.Instance.EnemyDamageData.GelHealth);
        }

        public void RandomMovementTimes()
        {
            this.movementTime = LoZGame.Instance.Random.Next(minMovementTime, maxMovementTime);
            this.idleTime = LoZGame.Instance.Random.Next(minIdleTime, maxIdleTime);
            this.moving = true;
            this.Lifetime = 0;
        }

        private void DecideToMove()
        {
            this.Lifetime++;
            if (this.moving && this.Lifetime >= this.movementTime)
            {
                this.Lifetime = 0;
                this.moving = false;
            }
            else if (this.Lifetime >= this.idleTime)
            {
                this.Enemy.UpdateState();
            }
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(3);
            }
            this.DecideToMove();
            if (this.moving)
            {
                this.Enemy.Physics.Move();
            }
            this.Sprite.Update();
        }
    }
}