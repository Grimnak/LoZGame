namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateDodongo()
        {
            DefaultUpdate();
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DodongoFavorCardinalValue);
            }
            if (!(this.Enemy.CurrentState is AttackingDodongoState))
            {
                this.CheckForLink();
            }
            if (this.Sprite.CurrentFrame >= 2)
            {
                this.Sprite.SetFrame(0);
            }
        }
    }
}