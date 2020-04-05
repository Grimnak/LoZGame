namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadGelState(Gel gel)
        {
            this.gel = gel;
            this.gel.CurrentState = this;
            this.gel.Physics.Bounds = new Rectangle(gel.Physics.Bounds.Location, Point.Zero);
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            LoZGame.Instance.Drops.AttemptDrop(this.gel.Physics.Location);
            deathTimerMax = gel.EnemySpeedData.DeathTimerMax;
            this.gel.Physics.MovementVelocity = Vector2.Zero;
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
            this.sprite.Draw(this.gel.Physics.Location, this.gel.CurrentTint, this.gel.Physics.Depth);
        }
    }
}