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
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DodongoFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
            if (!(Enemy.CurrentState is AttackingDodongoState || Enemy.IsSpawning))
            {
                CheckForLink();
            }
        }

        private void HardDodongo()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DodongoFavorCardinalValue + (2 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
            }
            if (!(Enemy.CurrentState is AttackingDodongoState || Enemy.IsSpawning))
            {
                CheckForLink();
            }
        }
    }
}