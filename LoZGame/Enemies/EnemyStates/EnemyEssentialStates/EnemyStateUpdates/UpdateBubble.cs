namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateBubble()
        {
            DefaultUpdate();
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.BubbleFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
            }
        }
    }
}