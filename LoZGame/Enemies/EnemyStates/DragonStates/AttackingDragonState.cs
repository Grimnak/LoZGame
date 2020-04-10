namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingDragonState : DragonEssentials, IEnemyState
    {
        private const float FireballSpeed = 3.5f;
        private const float FireballSpread = MathHelper.PiOver4 / 2;
        private const int NumberFireballs = 3;

        public AttackingDragonState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.Enemy.CurrentState = this;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.ShootFireballs();
        }

        private void ShootFireballs()
        {
            Vector2 velocityVector = this.UnitVectorToPlayer(this.Enemy.Physics.Bounds.Location.ToVector2());

            velocityVector *= FireballSpeed;
            for (int i = 0; i < NumberFireballs; i++)
            {
                float rotation = ((-1 * (float)(NumberFireballs - 1) / 2.0f) * FireballSpread) + (i * FireballSpread);
                Vector2 rotatedVelocity = this.RotateVector(velocityVector, rotation);
                Physics fireballPhysics = new Physics(this.Enemy.Physics.Bounds.Location.ToVector2())
                {
                    MovementVelocity = new Vector2(rotatedVelocity.X, rotatedVelocity.Y)
                };
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Fireball, fireballPhysics);
            }
        }
    }
}