namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownLeftMovingFireSnakeState : IEnemyState
    {
        private readonly IEnemy fireSnake;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private float accelerationMax;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;
        private Random randomDirectionCooldown;

        public DownLeftMovingFireSnakeState(IEnemy fireSnake)
        {
            this.fireSnake = fireSnake;
            this.sprite = ProjectileSpriteFactory.Instance.Fireball();
            this.fireSnake.CurrentState = this;
            randomStateGenerator = new RandomStateGenerator(this.fireSnake, 2, 10);
            randomDirectionCooldown = LoZGame.Instance.Random;
            directionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.fireSnake.Physics.MovementVelocity = new Vector2(-1 * this.fireSnake.MoveSpeed, this.fireSnake.MoveSpeed);
            this.fireSnake.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
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
            this.lifeTime++;
            this.sprite.Update();
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                directionChange = GameData.Instance.EnemySpeedData.DirectionChange;
                this.lifeTime = 0;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.fireSnake.Physics.Location, this.fireSnake.CurrentTint, this.fireSnake.Physics.Depth);
        }
    }
}