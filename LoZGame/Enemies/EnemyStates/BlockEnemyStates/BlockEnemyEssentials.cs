namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class BlockEnemyEssentials : EnemyStateEssentials, IEnemyState
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
            this.Enemy.CurrentState = new BlockEnemyAttackState(this.Enemy);
        }

        public void Stop()
        {
            this.Enemy.CurrentState = new BlockEnemyIdleState(this.Enemy);
        }

        public void Die()
        {
        }

        public void Stun(int stunTime)
        {
        }

        public override void Update()
        {
            // override to no longer update the sprite since the sprite doesnt exisst
            this.Lifetime++;
            if (this.Lifetime > this.DirectionChange)
            {
                this.Lifetime = 0;
                this.Enemy.UpdateState();
            } 
        }

        public override void Draw()
        {
            // enemy is invisble
        }
    }
}