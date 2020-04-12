namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StalfosEssentials : EnemyStateEssentials, IEnemyState
    {
        public void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingStalfosState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingStalfosState(this.Enemy);
        }

        public void MoveUp()
        {
            this.Enemy.CurrentState = new UpMovingStalfosState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.CurrentState = new DownMovingStalfosState(this.Enemy);
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
            this.Enemy.CurrentState = new DeadStalfosState(this.Enemy);
        }

        public void Stun(int stunTime)
        {
            this.Enemy.CurrentState = new StunnedStalfosState(this.Enemy, this, stunTime);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(3);
            }
            base.Update();
        }
    }
}