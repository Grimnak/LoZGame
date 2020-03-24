namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadDragonState : IEnemyState
    {
        private readonly Dragon dragon;
        private readonly DeadEnemySprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax = 30;

        public DeadDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.dragon.CurrentState = this;
            this.dragon.Bounds = Rectangle.Empty;
            LoZGame.Instance.Drops.AttemptDrop(this.dragon.Physics.Location);

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

        public void Die()
        {
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void Stun(int stunTime)
        {
        }

        public void Update()
        {
            this.deathTimer++;
            this.sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                this.dragon.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.dragon.Physics.Location, this.dragon.CurrentTint);
        }
    }
}
