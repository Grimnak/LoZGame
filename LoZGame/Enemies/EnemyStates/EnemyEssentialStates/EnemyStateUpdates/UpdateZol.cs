namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateZol()
        {
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardZol();
            }
            else
            {
                HardZol();
            }
        }

        private void StandardZol()
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
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.ZolFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                }
            }
        }

        private void HardZol()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.ZolFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }
    }
}