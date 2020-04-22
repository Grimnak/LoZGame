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
            if (!(Enemy.CurrentState is AttackingSpikeCrossState))
            {
                CheckForLink();
            }
        }

        private void HardSpikeCross()
        {
            if (!(Enemy.CurrentState is AttackingSpikeCrossState))
            {
                CheckForLink();
                //this.CheckForLinkDiagonal();
            }
        }
    }
}