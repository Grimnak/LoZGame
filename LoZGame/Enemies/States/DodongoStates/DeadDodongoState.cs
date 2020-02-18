namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadDodongoState : IEnemyState
    {
        private readonly Dodongo dodongo;
        private readonly IEnemySprite sprite;

        public DeadDodongoState(Dodongo dodongo)
        {
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingDodongoSprite();
            this.dodongo = dodongo;
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
            this.sprite.Draw(sb, this.dodongo.CurrentLocation, Color.White);
        }
    }
}