namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax = 30;

        public DeadGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.goriya.CurrentState = this;
            this.goriya.Physics.Bounds = new Rectangle(goriya.Physics.Bounds.Location, Point.Zero); ;
            LoZGame.Instance.Drops.AttemptDrop(this.goriya.Physics.Location);
            this.goriya.Physics.MovementVelocity = Vector2.Zero;
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

        public void Stop()
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

        public void Die()
        {
        }

        public void Attack()
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
                this.goriya.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.Physics.Location, this.goriya.CurrentTint, this.goriya.Physics.Depth);
        }
    }
}
