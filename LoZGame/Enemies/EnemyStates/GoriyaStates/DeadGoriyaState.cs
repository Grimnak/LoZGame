namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly DeadEnemySprite sprite;

        public DeadGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.goriya.CurrentState = this;
            this.goriya.VelocityX = 0;
            this.goriya.VelocityY = 0;
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

        public void TakeDamage(int damageAmount)
        {
        }

        public void Die()
        {
        }

        public void Attack()
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}
