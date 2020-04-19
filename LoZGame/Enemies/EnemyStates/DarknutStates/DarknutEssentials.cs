namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DarknutEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void Stun(int stunTime)
        {
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DarknutFavorCardinalValue);
            }
            base.Update();
        }
    }
}