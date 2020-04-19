﻿namespace LoZClone
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
            if (this.Lifetime % GameData.Instance.EnemyMiscConstants.UpdateSegmentTime == 0 && this.Lifetime != 0)
            {
                this.Enemy.UpdateChild();
            }
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.FireSnakeFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.FireSnakeFavorDiagonalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }
    }
}