namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BlockEnemyAttackState : BlockEnemyEssentials, IEnemyState
    {
        private const float FireballSpeed = 3.5f;

        public BlockEnemyAttackState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
            this.DirectionChange = 2 * LoZGame.Instance.UpdateSpeed;
            this.ShootFireball();
        }

        private void ShootFireball()
        {
            Vector2 velocityVector = (FireballSpeed / 2) * this.UnitVectorToPlayer(this.Enemy.Physics.Bounds.Center.ToVector2());
            Physics fireballPhysics = new Physics(this.Enemy.Physics.Bounds.Center.ToVector2())
            {
                MovementVelocity = new Vector2(velocityVector.X, velocityVector.Y)
            };
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballPhysics));
        }
    }
}