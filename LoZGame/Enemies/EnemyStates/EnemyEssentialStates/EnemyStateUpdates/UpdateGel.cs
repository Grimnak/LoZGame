namespace LoZClone
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
        }

        private void StandardGel()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                if (this.Enemy.Physics.MovementVelocity.Length() > 0)
                {
                    this.Enemy.CurrentState.Stop();
                    this.Lifetime = 0;
                }
                else
                {
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GelFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                }
            }
        }

        private void HardGel()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GelFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }
    }
}