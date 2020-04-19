namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateDodongo()
        {
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardDodongo();
            }
            else
            {
                HardDodongo();
            }
        }

        private void StandardDodongo()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.RopeFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
            if (!(this.Enemy.CurrentState is AttackingDodongoState || this.Enemy.IsSpawning))
            {
                this.CheckForLink();
            }
        }

        private void HardDodongo()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.RopeFavorCardinalValue + (2 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
            }
            if (!(this.Enemy.CurrentState is AttackingDodongoState || this.Enemy.IsSpawning))
            {
                this.CheckForLink();
            }
        }
    }
}