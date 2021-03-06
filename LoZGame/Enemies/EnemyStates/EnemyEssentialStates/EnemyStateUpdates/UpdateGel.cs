﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateGel()
        {
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardGel();
            }
            else
            {
                HardGel();
            }
            Enemy.Physics.KnockbackVelocity = Vector2.Zero;
        }

        private void StandardGel()
        {
            if (Lifetime == DirectionChange)
            {
                if (Enemy.Physics.MovementVelocity.Length() > 0)
                {
                    Enemy.CurrentState.Stop();
                    Lifetime = 0;
                }
                else
                {
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GelFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                }
            }
        }

        private void HardGel()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GelFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }
    }
}