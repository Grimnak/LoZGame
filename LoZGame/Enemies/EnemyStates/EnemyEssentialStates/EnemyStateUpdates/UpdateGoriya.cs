namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateGoriya()
        {
            ;
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardGoriya();
            }
            else
            {
                HardGoriya();
            }
        }

        private void StandardGoriya()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GoriyaFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod));
            }
        }

        private void HardGoriya()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GoriyaFavorCardinalValue + (2 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.GoriyaFavorCardinalValue + (3 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                FacePlayer();
            }
        }
    }
}