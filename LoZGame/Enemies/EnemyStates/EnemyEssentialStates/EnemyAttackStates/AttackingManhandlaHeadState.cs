namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingManhandlaHeadState : EnemyStateEssentials, IEnemyState
    {
        private const float DefaultSpread = MathHelper.PiOver4 / 4;
        private const int DefaultFireballs = 1;

        public AttackingManhandlaHeadState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            this.ShootFireballs();
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

            Vector2 velocityVector = this.UnitVectorToPlayer(this.Enemy.Physics.Bounds.Location.ToVector2());
            float speedMod = LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod;
            if (speedMod < -1.5f)
            {
                speedMod = -1.5f;
            }
            velocityVector *= GameData.Instance.ProjectileSpeedConstants.FireballSpeed + speedMod;
            for (int i = 0; i < numFireballs; i++)
            {
                float rotation = ((-1 * (float)(numFireballs - 1) / 2.0f) * fireBallSpread) + (i * fireBallSpread);
                Vector2 rotatedVelocity = this.RotateVector(velocityVector, rotation);
                Physics fireballPhysics = new Physics(this.Enemy.Physics.Bounds.Location.ToVector2())
                {
                    MovementVelocity = new Vector2(rotatedVelocity.X, rotatedVelocity.Y)
                };
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballPhysics));
            }
        }
    }
}