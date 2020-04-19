namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FireSnakeEssentials : EnemyStateEssentials
    {
        public override void Stun(int stunTime)
        {
        }

        public override void Update()
        {
            if (this.Lifetime % 10 == 0 && this.Lifetime != 0)
            {
                this.Enemy.UpdateChild();
            }
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.FireSnakeFavorCardinalValue);
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.FireSnakeFavorDiagonalValue);
            }
            base.Update();
        }
    }
}