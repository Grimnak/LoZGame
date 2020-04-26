namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingGoriyaState : EnemyStateEssentials, IEnemyState
    {
        public AttackingGoriyaState(IEnemy enemy)
        {
            Enemy = enemy;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange * 2;
            FacePlayer();
            Sprite = Enemy.CreateCorrectSprite();
            if (LoZGame.Instance.Difficulty < 2)
            {
                Enemy.Physics.MovementVelocity = Vector2.Zero;
            }
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new BoomerangProjectile(Enemy.Physics));
        }
    }
}