namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class EnemyStateEssentials
    {
        public void UpdateKeese()
        {
            DefaultUpdate();
            if (LoZGame.Instance.Difficulty <= 2)
            {
                StandardKeese();
            }
            else
            {
                HardKeese();
            }
            UpdateMoveSpeed();
            // set knockback velocity to zero to prevent enemy from getting stuck
            Enemy.Physics.KnockbackVelocity = Vector2.Zero;
        }

        private void StandardKeese()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.KeeseFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.KeeseFavorDiagonalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
            }
        }

        private void HardKeese()
        {
            if (Lifetime == DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.KeeseFavorCardinalValue + (2 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.KeeseFavorDiagonalValue + (2 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                AttemptBomb();
            }
        }

        private void UpdateMoveSpeed()
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

        private void AttemptBomb()
        {
            int attempt = LoZGame.Instance.Random.Next(0, 100);
            if (2 * attempt <= GameData.Instance.EnemyMiscConstants.ProjectileSuccess)
            {
                IProjectile bomb = new BombProjectile(Enemy.Physics);
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(bomb);
            }
        }
    }
}