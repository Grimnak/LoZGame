namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly DeadEnemySprite sprite;
        private int frameChange;
        public DeadStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.stalfos.CurrentState = this;
            LoZGame.Instance.Drops.AttemptDrop(this.stalfos.Physics.Location);
            this.stalfos.Expired = true;
            this.frameChange = 15;
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

        public void Update()
        {
            if (this.frameChange % 15 == 1)
                this.sprite.Update();
            frameChange++;
        }

        public void Draw()
        {
            this.sprite.Draw(this.stalfos.Physics.Location, this.stalfos.CurrentTint);
        }
    }
}
