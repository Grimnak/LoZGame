namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly DeadEnemySprite sprite;

        public DeadGelState(Gel gel)
        {
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.gel = null;
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

        public void TakeDamage()
        {
        }

        public void Die()
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.gel.CurrentLocation, Color.White);
        }
    }
}