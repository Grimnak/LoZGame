namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public partial class EnemyStateEssentials
    {
        public void UpdateRope()
        {
            DefaultUpdate();
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