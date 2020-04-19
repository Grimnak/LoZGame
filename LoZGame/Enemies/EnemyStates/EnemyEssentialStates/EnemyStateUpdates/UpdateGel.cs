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
                this.Enemy.Physics.Move();
                if (!this.isMoving)
                {
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GelFavorCardinalValue);
                    this.isMoving = true;
                    this.Enemy.UpdateState();
                }
                else
                {
                    this.isMoving = false;
                    this.Enemy.CurrentState = new IdleEnemyState(this.Enemy);
                }
            }
        }
    }
}