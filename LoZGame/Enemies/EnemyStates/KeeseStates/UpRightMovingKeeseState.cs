namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class UpRightMovingKeeseState : IEnemyState
    {
        private readonly Keese keese;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private int accelerationMax = 5;
        private const int DirectionChangeMin = 20;
        private const int DirectionChangeMax = 80;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;
        private Random randomDirectionCooldown;

        public UpRightMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            this.sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            this.keese.CurrentState = this;
            randomStateGenerator = new RandomStateGenerator(this.keese, 2, 10);
            randomDirectionCooldown = LoZGame.Instance.Random;
            directionChange = randomDirectionCooldown.Next(DirectionChangeMin, DirectionChangeMax);
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
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void MoveDownLeft()
        {
            this.keese.CurrentState = new DownLeftMovingKeeseState(this.keese);
        }

        public void MoveDownRight()
        {
            this.keese.CurrentState = new DownRightMovingKeeseState(this.keese);
        }

        public void Die()
        {
            this.keese.CurrentState = new DeadKeeseState(this.keese);
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                directionChange = randomDirectionCooldown.Next(DirectionChangeMin, DirectionChangeMax);
                this.lifeTime = 0;
            }
            this.updateMoveSpeed();
            this.keese.Physics.Location = new Vector2(this.keese.Physics.Location.X + (int)(.2 * this.keese.MoveSpeed), this.keese.Physics.Location.Y + (int)(.2 * this.keese.MoveSpeed));
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.keese.Physics.Location, this.keese.CurrentTint);
        }

        private void updateMoveSpeed()
        {
            if (this.keese.MoveSpeed++ > 10)
            {
                this.keese.MoveSpeed = 0;
            }
        }
    }
}