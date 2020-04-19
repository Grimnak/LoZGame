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
        }

        private void StandardKeese()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.KeeseFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.KeeseFavorDiagonalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
            }
        }

        private void HardKeese()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.KeeseFavorCardinalValue + (2 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.KeeseFavorDiagonalValue + (2 * (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargePreferenceMod)));
                AttemptBomb();
            }
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

        private void AttemptBomb()
        {
            int attempt = LoZGame.Instance.Random.Next(0, 100);
            if (2 * attempt <= GameData.Instance.EnemyMiscConstants.ProjectileSuccess)
            {
                IProjectile bomb = new BombProjectile(this.Enemy.Physics);
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(bomb);
            }
        }
    }
}