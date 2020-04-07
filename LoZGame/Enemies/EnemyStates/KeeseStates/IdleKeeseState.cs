namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class IdleKeeseState : IEnemyState
    {
        private readonly Keese keese;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;
        private int idleTimer = 0;

        public IdleKeeseState(Keese keese)
        {
            this.keese = keese;
            this.sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            randomStateGenerator = new RandomStateGenerator(this.keese, 2, 10);
            this.keese.CurrentState = this;
            this.keese.Physics.Bounds = Rectangle.Empty;
            LoZGame.Instance.Drops.AttemptDrop(this.keese.Physics.Location);
            this.keese.Physics.MovementVelocity = Vector2.Zero;
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
            this.keese.CurrentState = new DownRightMovingKeeseState(this.keese);
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
            this.idleTimer++;
            this.sprite.Update();
            if (idleTimer >= this.keese.EnemySpeedData.KeeseIdleMax)
            {
                this.randomStateGenerator.Update();
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.keese.Physics.Location, this.keese.CurrentTint, this.keese.Physics.Depth);
        }
    }
}
