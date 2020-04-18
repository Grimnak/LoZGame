namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class ZolEssentials : EnemyStateEssentials, IEnemyState
    {
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

        public virtual void Stun(int stunTime)
        {
        }

        public override void Spawn()
        {
            this.Enemy.CurrentState = new SpawnZolState(this.Enemy);
        }

        public void RandomMovementTimes()
        {
            this.idleTime = LoZGame.Instance.Random.Next(GameData.Instance.EnemyMiscConstants.ZolMinIdle, GameData.Instance.EnemyMiscConstants.ZolMaxIdle);
            this.moving = true;
            this.Lifetime = 0;
        }

        private void DecideToMove()
        {
            this.Lifetime++;
            if (this.moving && this.Lifetime >= GameData.Instance.EnemyMiscConstants.ZolMovementTime)
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
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.ZolFavorCardinalValue);
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