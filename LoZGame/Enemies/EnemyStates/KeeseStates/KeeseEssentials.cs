﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class KeeseEssentials : EnemyStateEssentials, IEnemyState
    {
        public void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingKeeseState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingKeeseState(this.Enemy);
        }

        public void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingKeeseState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingKeeseState(this.Enemy);
        }

        public void MoveUpLeft()
        {
            this.Enemy.CurrentState = new UpLeftMovingKeeseState(this.Enemy);
        }

        public void MoveUpRight()
        {
            this.Enemy.CurrentState = new UpRightMovingKeeseState(this.Enemy);
        }

        public void MoveDownLeft()
        {
            this.Enemy.CurrentState = new DownLeftMovingKeeseState(this.Enemy);
        }

        public void MoveDownRight()
        {
            this.Enemy.CurrentState = new DownRightMovingKeeseState(this.Enemy);
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadKeeseState(this.Enemy);
        }

        public void Stun(int stunTime)
        {
            this.Enemy.TakeDamage(GameData.Instance.EnemyDamageData.KeeseHealth);
        }

        public override void Update()
        {
            base.Update();
            UpdateMoveSpeed();
        }

        private void UpdateMoveSpeed()
        {
            Vector2 normalVel = this.Enemy.Physics.MovementVelocity / this.Enemy.Physics.MovementVelocity.Length();
            if (this.Lifetime < this.DirectionChange / 2)
            {
                if (this.Enemy.Physics.MovementVelocity.Length() <= GameData.Instance.EnemySpeedData.MaxKeeseSpeed)
                {
                    this.Enemy.Physics.MovementVelocity += normalVel * GameData.Instance.EnemySpeedData.KeeseAccel;
                }
            }
            else
            {
                if (this.Enemy.Physics.MovementVelocity.Length() >= GameData.Instance.EnemySpeedData.MinKeeseSpeed)
                {
                    this.Enemy.Physics.MovementVelocity -= normalVel * GameData.Instance.EnemySpeedData.KeeseAccel;
                }
            }
        }
    }
}