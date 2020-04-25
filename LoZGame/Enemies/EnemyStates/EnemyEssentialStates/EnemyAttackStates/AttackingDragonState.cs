namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingDragonState : EnemyStateEssentials, IEnemyState
    {
        private const float DefaultSpread = MathHelper.PiOver4 / 2;
        private const int DefaultFireballs = 3;

        public AttackingDragonState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            ShootFireballs();
        }

        private void ShootFireballs()
        {
            int numberFireballs = DefaultFireballs + (2 * LoZGame.Instance.Difficulty);
            if (numberFireballs < 1)
            {
                numberFireballs = 1;
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
            for (int i = 0; i < numberFireballs; i++)
            {
                float rotation = ((-1 * (float)(numberFireballs - 1) / 2.0f) * fireBallSpread) + (i * fireBallSpread);
                Vector2 rotatedVelocity = RotateVector(velocityVector, rotation);
                Physics fireballPhysics = new Physics(Enemy.Physics.Bounds.Location.ToVector2())
                {
                    MovementVelocity = new Vector2(rotatedVelocity.X, rotatedVelocity.Y)
                };
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballPhysics));
            }
        }
    }
}