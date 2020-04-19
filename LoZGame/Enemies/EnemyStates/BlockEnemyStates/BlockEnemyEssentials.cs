namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class BlockEnemyEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void Attack()
        {
            this.Enemy.CurrentState = new BlockEnemyAttackState(this.Enemy);
        }

        public override void Stop()
        {
            this.Enemy.CurrentState = new BlockEnemyIdleState(this.Enemy);
        }

        public override void Die()
        {
        }

        public override void Stun(int stunTime)
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