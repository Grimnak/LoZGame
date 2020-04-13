namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DragonEssentials : EnemyStateEssentials, IEnemyState
    {
        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
            this.Enemy.CurrentState = new LeftMovingDragonState(this.Enemy);
        }

        public void MoveRight()
        {
            this.Enemy.CurrentState = new RightMovingDragonState(this.Enemy);
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

        public void Stop()
        {
            this.Enemy.CurrentState = new IdleDragonState(this.Enemy);
        }

        public void Spawn()
        {
            this.Enemy.CurrentState = new SpawnDragonState(this.Enemy);
        }

        public void Attack()
        {
            this.Enemy.CurrentState = new AttackingDragonState(this.Enemy);
        }

        public void Die()
        {
            this.Enemy.CurrentState = new DeadDragonState(this.Enemy);
        }

        public void Stun(int stunTime)
        {
        }
    }
}