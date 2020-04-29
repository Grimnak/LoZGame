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
            if (this.Enemy.Physics.MovementVelocity.Length() > 0)
            {
                UpdateManMoveSpeed();
            }
        }

        private void StandardManhandla()
        {
            if (Lifetime == DirectionChange)
            {
                int favormod = GameData.Instance.EnemyMiscConstants.KeeseFavorCardinalValue;
                if (LoZGame.Instance.Difficulty > 0)
                {
                    favormod += LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod;
                }
                FavorPlayerCardinal(favormod);
                FavorPlayerDiagonal(2 * favormod);
            }
        }

        private void HardManhandla()
        {
            if (Lifetime == DirectionChange)
            {
                float moveSpeed = Enemy.MoveSpeed;
                moveSpeed += LoZGame.Instance.Difficulty > 0 ? LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod : 0;
                Enemy.Physics.MovementVelocity = UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2()) * moveSpeed;
                Lifetime = 0;
                RandomStateChange();
            }
        }

        private void UpdateManMoveSpeed()
        {
            float maxSpeedDiff = GameData.Instance.EnemySpeedConstants.ManhandlaMaxSpeed - GameData.Instance.EnemySpeedConstants.ManhandlaMinSpeed;
            float moveSpeed = Enemy.MoveSpeed;
            moveSpeed += LoZGame.Instance.Difficulty > 0 ? LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod : 0;
            Vector2 normalVel = new Vector2(Enemy.Physics.MovementVelocity.X, Enemy.Physics.MovementVelocity.Y);
            normalVel.Normalize();
            if (Lifetime < DirectionChange / 2)
            {
                if (Enemy.Physics.MovementVelocity.Length() <= moveSpeed + maxSpeedDiff)
                {
                    Enemy.Physics.MovementVelocity += normalVel * GameData.Instance.EnemySpeedConstants.KeeseAcceleration;
                }
            }
            else
            {
                if (Enemy.Physics.MovementVelocity.Length() >= moveSpeed)
                {
                    Enemy.Physics.MovementVelocity -= normalVel * GameData.Instance.EnemySpeedConstants.KeeseAcceleration;
                }
            }
        }
    }
}