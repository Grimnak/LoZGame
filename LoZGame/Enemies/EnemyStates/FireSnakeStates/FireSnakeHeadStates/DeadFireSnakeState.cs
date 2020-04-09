namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadFireSnakeState : IEnemyState
    {
        private readonly IEnemy fireSnake;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadFireSnakeState(IEnemy fireSnake)
        {
            this.fireSnake = fireSnake;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.fireSnake.CurrentState = this;
            this.fireSnake.Physics.Bounds = new Rectangle(fireSnake.Physics.Bounds.Location, Point.Zero);
            LoZGame.Instance.Drops.AttemptDrop(this.fireSnake.Physics.Location);
            deathTimerMax = GameData.Instance.EnemySpeedData.DeathTimerMax;
            this.fireSnake.Physics.MovementVelocity = Vector2.Zero;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
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
        }

        public void Stun(int stunTime)
        {
        }

        public void Update()
        {
            this.deathTimer++;
            this.sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                this.fireSnake.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.fireSnake.Physics.Location, this.fireSnake.CurrentTint, this.fireSnake.Physics.Depth);
        }
    }
}
