namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadDragonState : IEnemyState
    {
        private readonly Dragon dragon;
        private readonly DeadEnemySprite sprite;

        public DeadDragonState(Dragon dragon)
        {
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
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

        public void Draw()
        {
            this.sprite.Draw(this.dragon.Physics.Location, Color.White);
        }
    }
}