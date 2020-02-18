namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadDragonState : IDragonState
    {
        private readonly Dragon dragon;
        private readonly DeadEnemySprite sprite;

        public DeadDragonState(Dragon dragon)
        {
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.dragon = null;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
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

        public void Stop()
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.CurrentLocation, Color.White);
        }
    }
}