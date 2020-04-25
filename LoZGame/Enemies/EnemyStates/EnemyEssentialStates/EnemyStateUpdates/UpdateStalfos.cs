namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateStalfos()
        {
            DefaultUpdate();
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.StalfosFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
            }
        }
    }
}