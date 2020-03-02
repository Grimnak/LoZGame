namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly ISprite sprite;

        public UpMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.rope.VelocityX = 0 * rope.AttackFactor;
            this.rope.VelocityY = -1 * rope.AttackFactor;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingRopeSprite();
            this.rope.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.rope.CurrentState = new LeftMovingRopeState(this.rope);
        }

        public void MoveRight()
        {
            this.rope.CurrentState = new RightMovingRopeState(this.rope);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            this.rope.CurrentState = new DownMovingRopeState(this.rope);
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

        public void TakeDamage(int damageAmount)
        {
            this.rope.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.rope.CurrentState = new DeadRopeState(this.rope);
        }

        public void Update()
        {
            this.rope.Physics.Location = new Vector2(this.rope.Physics.Location.X + this.rope.VelocityX, this.rope.Physics.Location.Y + this.rope.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.rope.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}