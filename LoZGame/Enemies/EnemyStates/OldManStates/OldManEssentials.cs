namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class OldManEssentials : EnemyStateEssentials, IEnemyState
    {
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
            this.Enemy.CurrentState = new OldManSecretState(this.Enemy);
        }

        public void Stop()
        {
            this.Enemy.CurrentState = new OldManIdleState(this.Enemy);
        }

        public void Spawn()
        {
            this.Enemy.CurrentState = new SpawnOldManState(this.Enemy);
        }

        public void Die()
        {
        }

        public void Stun(int stunTime)
        {
        }
    }
}