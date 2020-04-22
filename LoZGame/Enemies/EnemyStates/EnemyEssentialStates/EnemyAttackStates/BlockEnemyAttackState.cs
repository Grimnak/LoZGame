namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BlockEnemyAttackState : BlockEnemyEssentials, IEnemyState
    {
        private const float FireballSpeed = 3f;

        public BlockEnemyAttackState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.CurrentState = this;
            DirectionChange = 2 * LoZGame.Instance.UpdateSpeed;
            ShootFireball();
        }

        private void ShootFireball()
        {
            float speedMod = LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod / 2;
            if (speedMod < -1)
            {
                speedMod = -1;
            }
            Vector2 velocityVector = ((FireballSpeed / 2) + speedMod) * UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2());
            Physics fireballPhysics = new Physics(Enemy.Physics.Bounds.Center.ToVector2())
            {
                MovementVelocity = new Vector2(velocityVector.X, velocityVector.Y)
            };
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballPhysics));
        }
    }
}