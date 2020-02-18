namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadGoriyaState : IGoriyaState
    {
        private readonly Goriya goriya;
        private readonly DeadEnemySprite sprite;

        public DeadGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
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

        public void TakeDamage()
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

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.goriya.CurrentLocation, Color.White);
        }
    }
}