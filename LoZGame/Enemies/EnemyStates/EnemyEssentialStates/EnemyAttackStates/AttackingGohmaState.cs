namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class AttackingGohmaState : EnemyStateEssentials, IEnemyState
    {
        private const float DefaultSpread = MathHelper.PiOver4 / 4;
        private const int DefaultFireballs = 1;
        private Vector2 fireballOffset;

        public AttackingGohmaState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.CurrentState = this;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.Physics.MovementVelocity = Vector2.Zero;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            fireballOffset = (Enemy.Physics.Bounds.Location + new Point(Enemy.Physics.Bounds.Width / 2, Enemy.Physics.Bounds.Height)).ToVector2(); ;
            ShootFireballs();
        }

        private void ShootFireballs()
        {
            int numFireballs = DefaultFireballs;
            if (LoZGame.Instance.Difficulty > 0)
            {
                numFireballs += DefaultFireballs + LoZGame.Instance.Random.Next(LoZGame.Instance.Difficulty + 1);
            }
            float fireBallSpread;
            if (LoZGame.Instance.Difficulty > 2)
            {
                fireBallSpread = DefaultSpread / 2;
            }
            else
            {
                fireBallSpread = DefaultSpread;
            }

            Vector2 velocityVector = UnitVectorToPlayer(Enemy.Physics.Bounds.Location.ToVector2());
            float speedMod = LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod;
            if (speedMod < -1.5f)
            {
                speedMod = -1.5f;
            }
            velocityVector *= GameData.Instance.ProjectileSpeedConstants.FireballSpeed + speedMod;
            for (int i = 0; i < numFireballs; i++)
            {
                float rotation = ((-1 * (float)(numFireballs - 1) / 2.0f) * fireBallSpread) + (i * fireBallSpread);
                Vector2 rotatedVelocity = RotateVector(velocityVector, rotation);
                Physics fireballPhysics = new Physics(fireballOffset)
                {
                    MovementVelocity = new Vector2(rotatedVelocity.X, rotatedVelocity.Y)
                };
                IProjectile fireball = new FireballProjectile(fireballPhysics);
                fireball.Physics.Bounds = new Rectangle(fireball.Physics.Bounds.Location - new Point(fireball.Physics.Bounds.Width / 2, fireball.Physics.Bounds.Height / 2), fireball.Physics.Bounds.Size);
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(fireball);
            }
        }
    }
}