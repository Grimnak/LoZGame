namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private readonly int directionChange = 40;
        private RandomStateGenerator randomStateGenerator;

        public RightMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            this.sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.stalfos.CurrentState = this;
            randomStateGenerator = new RandomStateGenerator(this.stalfos, 2, 6);
        }

        public void MoveLeft()
        {
            this.stalfos.CurrentState = new LeftMovingStalfosState(this.stalfos);
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
            this.stalfos.CurrentState = new UpMovingStalfosState(this.stalfos);
        }

        public void MoveDown()
        {
            this.stalfos.CurrentState = new DownMovingStalfosState(this.stalfos);
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
            this.stalfos.CurrentState = new DeadStalfosState(this.stalfos);
        }

        public void Stun(int stunTime)
        {
            this.stalfos.CurrentState = new StunnedStalfosState(this.stalfos, this, stunTime);
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }
            this.stalfos.Physics.Location = new Vector2(this.stalfos.Physics.Location.X + this.stalfos.MoveSpeed, this.stalfos.Physics.Location.Y);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.stalfos.Physics.Location, this.stalfos.CurrentTint);
        }
    }
}