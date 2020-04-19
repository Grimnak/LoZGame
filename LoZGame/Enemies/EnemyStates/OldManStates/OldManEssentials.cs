namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class OldManEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void Attack()
        {
            this.Enemy.CurrentState = new OldManSecretState(this.Enemy);
        }

        public override void Stop()
        {
            this.Enemy.CurrentState = new OldManIdleState(this.Enemy);
        }

        public override void Die()
        {
        }

        public override void Stun(int stunTime)
        {
        }
    }
}