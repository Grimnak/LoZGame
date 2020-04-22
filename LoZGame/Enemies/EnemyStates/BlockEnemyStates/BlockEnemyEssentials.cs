namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

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
            // override to no longer update the sprite since the sprite doesn't exist
            this.Lifetime++;
            if (this.Lifetime > this.DirectionChange)
            {
                this.Enemy.UpdateState();
                this.Lifetime = 0;
            } 
        }

        public override void Draw()
        {
            // enemy is invisble
        }
    }
}