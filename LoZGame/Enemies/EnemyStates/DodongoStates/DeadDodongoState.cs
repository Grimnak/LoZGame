namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadDodongoState : IEnemyState
    {
        private readonly IEnemy dodongo;
        private readonly ISprite sprite;

        public DeadDodongoState(IEnemy dodongo)
        {
            this.dodongo = dodongo;
            this.dodongo.CurrentState = this;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            LoZGame.Instance.Drops.AttemptDrop(this.dodongo.Physics.Location);
            this.dodongo.Expired = true;
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

        public void Stun(int stunTime)
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.dodongo.Physics.Location, this.dodongo.CurrentTint);
        }
    }
}
