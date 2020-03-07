namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DownMovingGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly ISprite sprite;

        public DownMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.Physics.Velocity = new Vector2(0, 1);
            this.sprite = EnemySpriteFactory.Instance.CreateDownMovingGoriyaSprite();
            this.goriya.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.goriya.CurrentState = new LeftMovingGoriyaState(this.goriya);
        }

        public void MoveRight()
        {
            this.goriya.CurrentState = new RightMovingGoriyaState(this.goriya);
        }

        public void MoveUp()
        {
            this.goriya.CurrentState = new UpMovingGoriyaState(this.goriya);
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

        public void Stop()
        {
        }

        public void Attack()
        {
            this.goriya.CurrentState = new AttackingGoriyaState(this.goriya);
        }

        public void TakeDamage(int damageAmount)
        {
            this.goriya.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Update()
        {
            this.goriya.Physics.Move();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}