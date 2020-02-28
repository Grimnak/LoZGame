namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly DeadEnemySprite sprite;

        public DeadZolState(Zol zol)
        {
            this.zol = zol;
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

        public void Draw()
        {
            this.sprite.Draw(this.zol.Physics.Location, Color.White);
        }
    }
}