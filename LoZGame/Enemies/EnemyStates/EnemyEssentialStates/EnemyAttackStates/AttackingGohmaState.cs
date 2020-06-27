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
            fireballOffset = (Enemy.Physics.Bounds.Location + new Point(Enemy.Physics.Bounds.Width / 2, Enemy.Physics.Bounds.Height)).ToVector2();
            ShootFireball();
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