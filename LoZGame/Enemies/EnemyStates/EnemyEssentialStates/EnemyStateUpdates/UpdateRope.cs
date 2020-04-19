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
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardRope();
            }
            else
            {
                HardRope();
            }
        }

        private void StandardRope()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.RopeFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
            if (!(this.Enemy.CurrentState is AttackingRopeState || this.Enemy.IsSpawning))
            {
                this.CheckForLink();
            }
        }

        private void HardRope()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.RopeFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
            if (!this.Enemy.IsSpawning)
            {
                this.CheckForLink();
            }
        }
    }
}