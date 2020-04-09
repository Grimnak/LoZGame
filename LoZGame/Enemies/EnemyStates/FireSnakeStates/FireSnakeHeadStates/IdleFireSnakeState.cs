namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class IdleFireSnakeState : IEnemyState
    {
        private readonly IEnemy fireSnake;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;
        private int idleTimer = 0;

        public IdleFireSnakeState(IEnemy fireSnake)
        {
            this.fireSnake = fireSnake;
            this.sprite = ProjectileSpriteFactory.Instance.Fireball();
            randomStateGenerator = new RandomStateGenerator(this.fireSnake, 2, 10);
            this.fireSnake.CurrentState = this;
            this.fireSnake.Physics.Bounds = Rectangle.Empty;
            LoZGame.Instance.Drops.AttemptDrop(this.fireSnake.Physics.Location);
            this.fireSnake.Physics.MovementVelocity = Vector2.Zero;
        }

        public void MoveLeft()
        {
            this.fireSnake.CurrentState = new LeftMovingFireSnakeState(this.fireSnake);
        }

        public void MoveRight()
        {
            this.fireSnake.CurrentState = new RightMovingFireSnakeState(this.fireSnake);
        }

        public void MoveUp()
        {
            this.fireSnake.CurrentState = new UpMovingFireSnakeState(this.fireSnake);
        }

        public void MoveDown()
        {
            this.fireSnake.CurrentState = new DownMovingFireSnakeState(this.fireSnake);
        }

        public void MoveUpLeft()
        {
            this.fireSnake.CurrentState = new UpLeftMovingFireSnakeState(this.fireSnake);
        }

        public void MoveUpRight()
        {
            this.fireSnake.CurrentState = new UpRightMovingFireSnakeState(this.fireSnake);
        }

        public void MoveDownLeft()
        {
            this.fireSnake.CurrentState = new DownLeftMovingFireSnakeState(this.fireSnake);
        }

        public void MoveDownRight()
        {
            this.fireSnake.CurrentState = new DownRightMovingFireSnakeState(this.fireSnake);
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.fireSnake.CurrentState = new DeadFireSnakeState(this.fireSnake);
        }

        public void Stun(int stunTime)
        {
            this.Die();
        }

        public void Update()
        {
            this.idleTimer++;
            this.sprite.Update();
            if (idleTimer >= 0)
            {
                this.randomStateGenerator.Update();
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.fireSnake.Physics.Location, this.fireSnake.CurrentTint, this.fireSnake.Physics.Depth);
        }
    }
}
