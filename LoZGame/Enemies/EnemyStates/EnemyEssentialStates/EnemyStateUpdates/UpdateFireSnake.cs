namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateFireSnake()
        {
            DefaultUpdate();
            if (Lifetime % GameData.Instance.EnemyMiscConstants.UpdateSegmentTime == 0 && Lifetime != 0)
            {
                Enemy.UpdateChild();
            }
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.FireSnakeFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.FireSnakeFavorDiagonalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }
    }
}