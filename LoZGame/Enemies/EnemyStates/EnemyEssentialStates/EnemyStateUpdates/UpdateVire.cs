namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateVire()
        {
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardVire();
            }
            else
            {
                HardVire();
            }
        }

        private void StandardVire()
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
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.VireFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                    FavorPlayerJumpCardinal(GameData.Instance.EnemyMiscConstants.VireFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                    this.Enemy.States.Remove(RandomStateGenerator.StateType.JumpNorth);
                    this.Enemy.States.Remove(RandomStateGenerator.StateType.MoveEast);
                    this.Enemy.States.Remove(RandomStateGenerator.StateType.MoveWest);
                    this.Enemy.States.Remove(RandomStateGenerator.StateType.JumpSouth);
                }
            }
        }

        private void HardVire()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerJumpCardinal(GameData.Instance.EnemyMiscConstants.VireFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                FavorPlayerJumpDiagonal(GameData.Instance.EnemyMiscConstants.VireFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }
    }
}