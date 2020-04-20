namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public partial class EnemyStateEssentials
    {
        public void UpdateSpikeCross()
        {
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardRope();
            }
            else
            {
                HardRope();
            }
        }

        private void StandardSpikeCross()
        {
            if (!(this.Enemy.CurrentState is AttackingSpikeCrossState))
            {
                this.CheckForLink();
            }
        }

        private void HardSpikeCross()
        {
            if (!(this.Enemy.CurrentState is AttackingSpikeCrossState))
            {
                this.CheckForLink();
                //this.CheckForLinkDiagonal();
            }
        }
    }
}