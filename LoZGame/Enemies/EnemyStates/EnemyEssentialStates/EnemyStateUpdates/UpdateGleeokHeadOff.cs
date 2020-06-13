namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateGleeokHeadOff()
        {
            DefaultUpdate();
            if (Lifetime == DirectionChange)
            {
                ShootFireball();
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GleeokHeadOffFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
                FavorPlayerDiagonal(GameData.Instance.EnemyMiscConstants.GleeokHeadOffFavorCardinalValue + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallPreferenceMod));
            }
        }

        private void ShootFireball()
        {
            float speedMod = LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod / 2;
            if (speedMod < -1)
            {
                speedMod = -1;
            }
            Vector2 velocityVector = (GameData.Instance.ProjectileSpeedConstants.FireballSpeed + speedMod) * UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2());
            Physics fireballPhysics = new Physics(Enemy.Physics.Bounds.Center.ToVector2())
            {
                MovementVelocity = new Vector2(velocityVector.X, velocityVector.Y)
            };
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballPhysics));
        }
    }
}