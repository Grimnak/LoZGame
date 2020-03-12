namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadKeeseState : IEnemyState
    {
        private readonly Keese keese;
        private readonly DeadEnemySprite sprite;

        public DeadKeeseState(Keese keese)
        {
            this.keese = keese;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.keese.CurrentState = this;
            LoZGame.Instance.Drops.AttemptDrop(this.keese.Physics.Location);
            this.keese.Expired = true;
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

        public void Die()
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.keese.Physics.Location, this.keese.CurrentTint);
        }
    }
}
