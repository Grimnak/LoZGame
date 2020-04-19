namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateGel()
        {
            DefaultUpdate();
            if (this.Lifetime == this.DirectionChange)
            {
                this.Lifetime = 0;
                if (this.Enemy.Physics.MovementVelocity.Length() > 0)
                {
                    this.Enemy.CurrentState.Stop();
                }
                else
                {
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GelFavorCardinalValue);
                    this.Enemy.UpdateState();
                }
            }
        }
    }
}