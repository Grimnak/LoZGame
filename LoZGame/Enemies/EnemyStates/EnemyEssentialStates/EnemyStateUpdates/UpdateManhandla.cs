namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateManhandla()
        {
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardManhandla();
            }
            else
            {
                HardManhandla();
            }
            UpdateManMoveSpeed();
        }

        private void StandardManhandla()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerDiagonal(100);
            }
        }

        private void HardManhandla()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(100);
                FavorPlayerDiagonal(100);
            }
        }

        private void UpdateManMoveSpeed()
        {
            Vector2 normalVel = this.Enemy.Physics.MovementVelocity / this.Enemy.Physics.MovementVelocity.Length();
            if (this.Lifetime < this.DirectionChange / 2)
            {
                if (this.Enemy.Physics.MovementVelocity.Length() <= GameData.Instance.EnemySpeedConstants.ManhandlaMaxSpeed)
                {
                    this.Enemy.Physics.MovementVelocity += normalVel * GameData.Instance.EnemySpeedConstants.ManhandlaAcceleration;
                }
            }
            else
            {
                if (this.Enemy.Physics.MovementVelocity.Length() >= GameData.Instance.EnemySpeedConstants.ManhandlaMinSpeed)
                {
                    this.Enemy.Physics.MovementVelocity -= normalVel * GameData.Instance.EnemySpeedConstants.ManhandlaAcceleration;
                }
            }
        }
    }
}