namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class KeeseEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void Update()
        {
            base.Update();
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.KeeseFavorCardinalValue);
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.KeeseFavorDiagonalValue);
            }
            UpdateMoveSpeed();
        }

        private void UpdateMoveSpeed()
        {
            Vector2 normalVel = this.Enemy.Physics.MovementVelocity / this.Enemy.Physics.MovementVelocity.Length();
            if (this.Lifetime < this.DirectionChange / 2)
            {
                if (this.Enemy.Physics.MovementVelocity.Length() <= GameData.Instance.EnemySpeedConstants.MaxKeeseSpeed)
                {
                    this.Enemy.Physics.MovementVelocity += normalVel * GameData.Instance.EnemySpeedConstants.KeeseAcceleration;
                }
            }
            else
            {
                if (this.Enemy.Physics.MovementVelocity.Length() >= GameData.Instance.EnemySpeedConstants.MinKeeseSpeed)
                {
                    this.Enemy.Physics.MovementVelocity -= normalVel * GameData.Instance.EnemySpeedConstants.KeeseAcceleration;
                }
            }
        }
    }
}