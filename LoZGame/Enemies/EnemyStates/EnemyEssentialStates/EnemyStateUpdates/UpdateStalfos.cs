namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateStalfos()
        {
            DefaultUpdate();
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerJumpCardinal(GameData.Instance.EnemyMiscConstants.StalfosFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
            }
        }
    }
}