namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingGanonState : EnemyStateEssentials, IEnemyState
    {
        public AttackingGanonState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            ShootFireball();
        }

        private void ShootFireball()
        {
            float speedMod = LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod / 2;
            if (speedMod < -1)
            {
                speedMod = -1;
            }
            Vector2 velocityVector = ((GameData.Instance.ProjectileSpeedConstants.FireballSpeed / 2) + speedMod) * UnitVectorToPlayer(Enemy.Physics.Bounds.Center.ToVector2());
            Physics fireballPhysics = new Physics(Enemy.Physics.Bounds.Center.ToVector2())
            {
                MovementVelocity = new Vector2(velocityVector.X, velocityVector.Y)
            };
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballPhysics));
        }
    }
}