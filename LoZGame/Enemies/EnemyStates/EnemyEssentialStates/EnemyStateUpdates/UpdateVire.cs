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
            if (Lifetime == DirectionChange)
            {
                if (Enemy.Physics.MovementVelocity.Length() > 0)
                {
                    Enemy.CurrentState.Stop();
                    Lifetime = 0;
                }
                else
                {
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.VireFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                    FavorPlayerJumpCardinal(GameData.Instance.EnemyMiscConstants.VireFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                    Enemy.States.Remove(RandomStateGenerator.StateType.JumpNorth);
                    Enemy.States.Remove(RandomStateGenerator.StateType.MoveEast);
                    Enemy.States.Remove(RandomStateGenerator.StateType.MoveWest);
                    Enemy.States.Remove(RandomStateGenerator.StateType.JumpSouth);
                }
            }
        }

        private void HardVire()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerJumpCardinal(GameData.Instance.EnemyMiscConstants.VireFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
                FavorPlayerJumpDiagonal(GameData.Instance.EnemyMiscConstants.VireFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }
    }
}