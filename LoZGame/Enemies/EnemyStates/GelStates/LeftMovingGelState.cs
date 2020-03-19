namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly ISprite sprite;
        private int timeSinceIdle = 0;
        private int timeInIdle = 0;
        private int movementWaitMax = 12;
        private RandomStateGenerator randomStateGenerator;

        public LeftMovingGelState(Gel gel)
        {
            this.gel = gel;
            this.sprite = EnemySpriteFactory.Instance.CreateGelSprite();
            this.gel.CurrentState = this;
            this.randomStateGenerator = new RandomStateGenerator(this.gel, 2, 6);
        }

        public void MoveLeft()
        {
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

        private void DecideToMove()
        {
            if (this.gel.ShouldMove)
            {
                if (timeSinceIdle++ > movementWaitMax)
                {
                    this.gel.ShouldMove = !this.gel.ShouldMove;
                    timeSinceIdle = 0;
                }
            }
            else
            {
                if (timeInIdle++ > movementWaitMax)
                {
                    this.gel.ShouldMove = !this.gel.ShouldMove;
                    timeInIdle = 0;
                    randomStateGenerator.Update();
                }
            }
        }

        public void Update()
        {
            this.DecideToMove();
            if (this.gel.ShouldMove)
            {
                this.gel.Physics.Location = new Vector2(this.gel.Physics.Location.X, this.gel.Physics.Location.Y + this.gel.MoveSpeed);
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.gel.Physics.Location, this.gel.CurrentTint);
        }
    }
}