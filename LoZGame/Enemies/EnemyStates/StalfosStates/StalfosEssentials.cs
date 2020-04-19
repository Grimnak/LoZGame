namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StalfosEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void Update()
        {
            base.Update();
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.StalfosFavorCardinalValue);
            }
        }
    }
}