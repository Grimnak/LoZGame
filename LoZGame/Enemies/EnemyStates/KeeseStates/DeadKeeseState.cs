namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadKeeseState : IEnemyState
    {
        private readonly Keese keese;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadKeeseState(Keese keese)
        {
            this.keese = keese;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.keese.CurrentState = this;
            this.keese.Physics.Bounds = new Rectangle(keese.Physics.Bounds.Location, Point.Zero);
            LoZGame.Instance.Drops.AttemptDrop(this.keese.Physics.Location);
            deathTimerMax = GameData.Instance.EnemySpeedData.DeathTimerMax;
            this.keese.Physics.MovementVelocity = Vector2.Zero;
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
                this.keese.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.keese.Physics.Location, this.keese.CurrentTint, this.keese.Physics.Depth);
        }
    }
}
