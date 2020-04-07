namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownRightMovingKeeseState : IEnemyState
    {
        private readonly Keese keese;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private float accelerationMax;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;
        private Random randomDirectionCooldown;

        public DownRightMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            this.sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            this.keese.CurrentState = this;
            randomStateGenerator = new RandomStateGenerator(this.keese, 2, 10);
            randomDirectionCooldown = LoZGame.Instance.Random;
            directionChange = randomDirectionCooldown.Next(this.keese.MinChangeTime, this.keese.MaxChangeTime);
            accelerationMax = this.keese.EnemySpeedData.MaxKeeseAccel;
            this.keese.Physics.MovementVelocity = new Vector2(this.keese.MoveSpeed, this.keese.MoveSpeed);
            this.keese.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }

        public void MoveLeft()
        {
            this.keese.CurrentState = new LeftMovingKeeseState(this.keese);
        }

        public void MoveRight()
        {
            this.keese.CurrentState = new RightMovingKeeseState(this.keese);
        }

        public void MoveUp()
        {
            this.keese.CurrentState = new UpMovingKeeseState(this.keese);
        }

        public void MoveDown()
        {
            this.keese.CurrentState = new DownMovingKeeseState(this.keese);
        }

        public void MoveUpLeft()
        {
            this.keese.CurrentState = new UpLeftMovingKeeseState(this.keese);
        }

        public void MoveUpRight()
        {
            this.keese.CurrentState = new UpRightMovingKeeseState(this.keese);
        }

        public void MoveDownLeft()
        {
            this.keese.CurrentState = new DownLeftMovingKeeseState(this.keese);
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
            this.keese.CurrentState = new DeadKeeseState(this.keese);
        }

        public void Stun(int stunTime)
        {
            this.Die();
        }

        public void Update()
        {
            this.lifeTime++;
            this.keese.UpdateMoveSpeed(lifeTime, directionChange);
            this.sprite.Update();
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                directionChange = randomDirectionCooldown.Next(this.keese.MinChangeTime, this.keese.MaxChangeTime);
                this.lifeTime = 0;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.keese.Physics.Location, this.keese.CurrentTint, this.keese.Physics.Depth);
        }
    }
}