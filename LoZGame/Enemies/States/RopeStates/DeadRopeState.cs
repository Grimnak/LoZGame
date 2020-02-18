namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly DeadEnemySprite sprite;

        public DeadRopeState(Rope rope)
        {
            this.rope = rope;
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

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.rope.CurrentLocation, Color.White);
        }
    }
}