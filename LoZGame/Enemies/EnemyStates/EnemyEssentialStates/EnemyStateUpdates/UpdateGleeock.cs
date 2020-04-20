namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateGleeock()
        {
            DefaultUpdate();
            if (this.Lifetime == this.DirectionChange)
            {
                AttemptFireBall();
            }
        }

        private void AttemptFireBall()
        {
            int attempt = LoZGame.Instance.Random.Next(0, 100);
            if (attempt <= GameData.Instance.EnemyMiscConstants.ProjectileSuccess / 2)
            {
                ShootFireballs();
            }
        }

        private void ShootFireballs()
        {
            int numberFireballs = 1 + LoZGame.Instance.Random.Next(0, LoZGame.Instance.Difficulty + 1);
            if (numberFireballs < 1)
            {
                numberFireballs = 1;
            }
            float fireBallSpread;
            if (LoZGame.Instance.Difficulty > 2)
            {
                fireBallSpread = MathHelper.PiOver4 / 4;
            }
            else
            {
                fireBallSpread = MathHelper.PiOver4 / 8;
            }

            Vector2 velocityVector = this.UnitVectorToPlayer(this.Enemy.Physics.Bounds.Location.ToVector2());
            float speedMod = LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod;
            if (speedMod < -1.5f)
            {
                speedMod = -1.5f;
            }
            velocityVector *= GameData.Instance.ProjectileSpeedConstants.FireballSpeed + speedMod;
            for (int i = 0; i < numberFireballs; i++)
            {
                float rotation = ((-1 * (float)(numberFireballs - 1) / 2.0f) * fireBallSpread) + (i * fireBallSpread);
                Vector2 rotatedVelocity = this.RotateVector(velocityVector, rotation);
                Physics fireballPhysics = new Physics(this.Enemy.Physics.Bounds.Location.ToVector2())
                {
                    MovementVelocity = new Vector2(rotatedVelocity.X, rotatedVelocity.Y)
                };
                IProjectile fireball = new FireballProjectile(fireballPhysics);
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(fireball);
                fireball.Damage = 4 + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.DamageMod);
            }
        }
    }
}