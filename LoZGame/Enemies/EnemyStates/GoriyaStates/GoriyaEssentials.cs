namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GoriyaEssentials : EnemyStateEssentials, IEnemyState
    {   
        public void MoveLeft()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
            this.Enemy.CurrentState = new LeftMovingGoriyaState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
            this.Enemy.CurrentState = new RightMovingGoriyaState(this.Enemy);
        }

        public void MoveUp()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.CurrentState = new UpMovingGoriyaState(this.Enemy);
        }

        public void MoveDown()
        {
            this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
            this.Enemy.CurrentState = new DownMovingGoriyaState(this.Enemy);
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
            this.Enemy.CurrentState = new AttackingGoriyaState(this.Enemy);
        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadGoriyaState(this.Enemy);
        }

        public virtual void Stun(int stunTime)
        {
            this.Enemy.CurrentState = new StunnedGoriyaState(this.Enemy, this, stunTime);
        }
    }
}