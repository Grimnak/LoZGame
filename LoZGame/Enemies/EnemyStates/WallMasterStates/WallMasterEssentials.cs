namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using static RandomStateGenerator;

    public partial class WallMasterEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void Attack()
        {
            this.Enemy.CurrentState = new AttackingWallMasterState(this.Enemy);

        }

        public override void Update()
        {
            base.Update();
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.WallMasterFavorCardinalValue);
            }
        }
    }
}