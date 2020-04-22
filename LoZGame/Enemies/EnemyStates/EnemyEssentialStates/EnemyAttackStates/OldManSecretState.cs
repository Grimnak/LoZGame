namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class OldManSecretState : EnemyStateEssentials, IEnemyState
    {
        private const float FireballSpeed = 5f;
        private const float FireballSpread = MathHelper.PiOver4;
        private const int NumberFireballs = 5;
        private int lifetime;

        public OldManSecretState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.CurrentState = this;
            Sprite = Enemy.CreateCorrectSprite();
            DirectionChange = LoZGame.Instance.UpdateSpeed * 10;
        }

        private void ShootFireballs()
        {
            Vector2 velocityVector = UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2());

            velocityVector *= FireballSpeed;
            for (int i = 0; i < NumberFireballs; i++)
            {
                float rotation = ((-1 * (float)(NumberFireballs - 1) / 2.0f) * FireballSpread) + (i * FireballSpread);
                Vector2 rotatedVelocity = RotateVector(velocityVector, rotation);
                Physics fireballPhysics = new Physics(Enemy.Physics.Bounds.Center.ToVector2())
                {
                    MovementVelocity = new Vector2(rotatedVelocity.X, rotatedVelocity.Y)
                };
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballPhysics));
            }
        }

        public override void Update()
        {   
            if (Lifetime > DirectionChange / 2 && Lifetime % 4 == 0)
            {
                ShootFireballs();
            }
            base.Update();
        }
    }
}