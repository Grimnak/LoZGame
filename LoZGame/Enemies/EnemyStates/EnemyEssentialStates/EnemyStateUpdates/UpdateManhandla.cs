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
            if (Lifetime == DirectionChange)
            {
                FavorPlayerDiagonal(100);
            }
        }

        private void HardManhandla()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(100);
                FavorPlayerDiagonal(100);
            }
        }

        private void UpdateManMoveSpeed()
        {
            float maxSpeedDiff = GameData.Instance.EnemySpeedConstants.ManhandlaMaxSpeed - GameData.Instance.EnemySpeedConstants.ManhandlaMinSpeed;
            Vector2 normalVel = Enemy.Physics.MovementVelocity / Enemy.Physics.MovementVelocity.Length();
            if (Lifetime < DirectionChange / 2)
            {
                if (Enemy.Physics.MovementVelocity.Length() <= Enemy.MoveSpeed + maxSpeedDiff)
                {
                    Enemy.Physics.MovementVelocity += normalVel * GameData.Instance.EnemySpeedConstants.KeeseAcceleration;
                }
            }
            else
            {
                if (Enemy.Physics.MovementVelocity.Length() >= Enemy.MoveSpeed)
                {
                    Enemy.Physics.MovementVelocity -= normalVel * GameData.Instance.EnemySpeedConstants.KeeseAcceleration;
                }
            }
        }
    }
}