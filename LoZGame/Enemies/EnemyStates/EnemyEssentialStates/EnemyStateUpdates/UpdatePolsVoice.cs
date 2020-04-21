namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdatePolsVoice()
        {
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardPolsVoice();
            }
            else
            {
                HardPolsVoice();
            }
        }

        private void StandardPolsVoice()
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
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.PolsVoiceFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                }
            }
        }

        private void HardPolsVoice()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.PolsVoiceFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }
    }
}