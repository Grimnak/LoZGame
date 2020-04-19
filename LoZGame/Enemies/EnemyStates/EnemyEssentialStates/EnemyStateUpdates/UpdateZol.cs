namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateZol()
        {
            DefaultUpdate();
            if (this.Lifetime == this.DirectionChange)
            {
                this.Lifetime = 0;
                if (!this.isMoving)
                {
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.ZolFavorCardinalValue);
                    this.isMoving = true;
                    this.Enemy.UpdateState();
                }
                else
                {
                    this.isMoving = false;
                    this.Enemy.CurrentState.Stop();
                }
            }
        }
    }
}