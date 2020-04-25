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
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.RopeFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
            if (!(Enemy.CurrentState is AttackingRopeState || Enemy.IsSpawning))
            {
                CheckForLink();
            }
        }

        private void HardRope()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.RopeFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
            if (!Enemy.IsSpawning)
            {
                CheckForLink();
            }
        }
    }
}