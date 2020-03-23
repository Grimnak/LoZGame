namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly DeadEnemySprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax = 30;

        public DeadGelState(Gel gel)
        {
            this.gel = gel;
            this.gel.CurrentState = this;
            this.gel.Bounds = Rectangle.Empty;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            LoZGame.Instance.Drops.AttemptDrop(this.gel.Physics.Location);
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
            this.Die();
        }

        public void Update()
        {
            this.deathTimer++;
            this.sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                this.gel.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.gel.Physics.Location, this.gel.CurrentTint);
        }
    }
}