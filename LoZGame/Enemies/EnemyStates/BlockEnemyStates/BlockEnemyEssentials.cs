namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class BlockEnemyEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void Attack()
        {
            Enemy.CurrentState = new BlockEnemyAttackState(Enemy);
        }

        public override void Stop()
        {
            Enemy.CurrentState = new BlockEnemyIdleState(Enemy);
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
            Lifetime++;
            if (Lifetime > DirectionChange)
            {
                Enemy.UpdateState();
                Lifetime = 0;
            } 
        }

        public override void Draw()
        {
            // enemy is invisble
        }
    }
}