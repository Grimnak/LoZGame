namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class IdleGelState : IEnemyState
    {
        private static readonly int minIdleTime = 0;
        private static readonly int maxIdleTime = LoZGame.Instance.UpdateSpeed;
        private Gel gel;
        private ISprite sprite;
        private int idleTime;
        private int lifeTime;
        private RandomStateGenerator randomStateGenerator;
        private Random randomNumGenerator;

        public IdleGelState(Gel gel)
        {
            this.gel = gel;
            this.sprite = EnemySpriteFactory.Instance.CreateGelSprite();
            this.gel.CurrentState = this;
            this.randomStateGenerator = new RandomStateGenerator(this.gel, 2, 6);
            randomNumGenerator = LoZGame.Instance.Random;
            this.idleTime = randomNumGenerator.Next(minIdleTime, maxIdleTime);
            this.lifeTime = 0;
            this.gel.Physics.MovementVelocity = Vector2.Zero;
        }

        public void MoveLeft()
        {
            this.gel.CurrentState = new LeftMovingGelState(this.gel);
        }

        public void MoveRight()
        {
            this.gel.CurrentState = new RightMovingGelState(this.gel);
        }

        public void MoveUp()
        {
            this.gel.CurrentState = new UpMovingGelState(this.gel);
        }

        public void MoveDown()
        {
            this.gel.CurrentState = new DownMovingGelState(this.gel);
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
            this.gel.CurrentState = new DeadGelState(this.gel);
        }

        public void Stun(int stunTime)
        {
            this.Die();
        }

        private void DecideToMove()
        {
            this.lifeTime++;
            if (this.lifeTime >= this.idleTime)
            {
                randomStateGenerator.Update();
            }
        }

        public void Update()
        {
            this.DecideToMove();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.gel.Physics.Location, this.gel.CurrentTint);
        }
    }
}