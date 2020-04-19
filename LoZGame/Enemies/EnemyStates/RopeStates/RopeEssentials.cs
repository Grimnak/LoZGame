namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public class RopeEssentials : EnemyStateEssentials,  IEnemyState
    {
        public void Attack()
        {
            this.Enemy.CurrentState = new AttackingRopeState(this.Enemy);
        }

        public override void Update()
        {
            base.Update();
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.RopeFavorCardinalValue);
            }
            if (!(this.Enemy.CurrentState is AttackingRopeState || this.Enemy.IsSpawning))
            {
                this.CheckForLink();
            }
        }
    }
}