namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly DeadEnemySprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax = 30;

        public DeadStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.stalfos.CurrentState = this;
            this.stalfos.Bounds = Rectangle.Empty;
            LoZGame.Instance.Drops.AttemptDrop(this.stalfos.Physics.Location);
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
                this.stalfos.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.stalfos.Physics.Location, this.stalfos.CurrentTint);
        }
    }
}
