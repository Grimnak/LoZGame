namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class UpMovingGelState : IEnemyState
    {
        private static readonly int minMovementTime = LoZGame.Instance.UpdateSpeed;
        private static readonly int maxMovementTime = LoZGame.Instance.UpdateSpeed * 4;
        private static readonly int minIdleTime = LoZGame.Instance.UpdateSpeed;
        private static readonly int maxIdleTime = LoZGame.Instance.UpdateSpeed * 2;
        private readonly Gel gel;
        private readonly ISprite sprite;
        private int movementTime;
        private int idleTime;
        private int lifeTime;
        private RandomStateGenerator randomStateGenerator;
        private Random randomNumGenerator;
        private bool moving;

        public UpMovingGelState(Gel gel)
        {
            this.gel = gel;
            this.sprite = EnemySpriteFactory.Instance.CreateGelSprite();
            this.gel.CurrentState = this;
            this.randomStateGenerator = new RandomStateGenerator(this.gel, 2, 6);
            this.moving = true;
            randomNumGenerator = LoZGame.Instance.Random;
            this.movementTime = randomNumGenerator.Next(minMovementTime, maxMovementTime);
            this.idleTime = randomNumGenerator.Next(minIdleTime, maxIdleTime);
            this.lifeTime = 0;
            this.gel.Physics.MovementVelocity = new Vector2(0, -1 * this.gel.MoveSpeed);
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
            this.movementTime = randomNumGenerator.Next(minMovementTime, maxMovementTime);
            this.idleTime = randomNumGenerator.Next(minIdleTime, maxIdleTime);
            this.moving = true;
            this.lifeTime = 0;
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
            if (this.moving && this.lifeTime >= this.movementTime)
            {
                this.lifeTime = 0;
                this.moving = false;
            }
            else if (this.lifeTime >= this.idleTime)
            {
                randomStateGenerator.Update();
            }
        }

        public void Update()
        {
            this.DecideToMove();
            if (this.moving)
            {
                this.gel.Physics.Move();
            }
            this.sprite.Update();
        }
        
        public void Draw()
        {
            this.sprite.Draw(this.gel.Physics.Location, this.gel.CurrentTint, this.gel.Physics.Depth);
        }
    }
}