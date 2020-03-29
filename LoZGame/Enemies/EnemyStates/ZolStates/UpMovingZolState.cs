﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly ISprite sprite;
        private int timeSinceIdle = 0;
        private int timeInIdle = 0;
        private int movementWaitMax = 12;
        private RandomStateGenerator randomStateGenerator;

        public UpMovingZolState(Zol zol)
        {
            this.zol = zol;
            this.sprite = EnemySpriteFactory.Instance.CreateZolSprite();
            this.zol.CurrentState = this;
            this.randomStateGenerator = new RandomStateGenerator(this.zol, 2, 6);
            this.zol.Physics.MovementVelocity = new Vector2(0, -1 * this.zol.MoveSpeed);
        }

        public void MoveLeft()
        {
            this.zol.CurrentState = new LeftMovingZolState(this.zol);
        }

        public void MoveRight()
        {
            this.zol.CurrentState = new RightMovingZolState(this.zol);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            this.zol.CurrentState = new DownMovingZolState(this.zol);
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
            this.zol.CurrentState = new DeadZolState(this.zol);
        }

        public void Stun(int stunTime)
        {
            this.zol.CurrentState = new StunnedZolState(this.zol, this, stunTime);
        }

        private void DecideToMove()
        {
            if (this.zol.ShouldMove)
            {
                if (timeSinceIdle++ > movementWaitMax)
                {
                    this.zol.ShouldMove = !this.zol.ShouldMove;
                    timeSinceIdle = 0;
                }
            }
            else
            {
                if (timeInIdle++ > movementWaitMax)
                {
                    this.zol.ShouldMove = !this.zol.ShouldMove;
                    timeInIdle = 0;
                    randomStateGenerator.Update();
                }
            }
        }

        public void Update()
        {
            this.DecideToMove();
            if (this.zol.ShouldMove)
            {
                this.zol.Physics.Move();
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.zol.Physics.Location, this.zol.CurrentTint);
        }
    }
}