namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class AttackingBlueGoriyaState : EnemyStateEssentials, IEnemyState
    {
        public AttackingBlueGoriyaState(IEnemy enemy)
        {
            Enemy = enemy;
            DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            FacePlayer();
            Sprite = Enemy.CreateCorrectSprite();
            if (LoZGame.Instance.Difficulty < 2)
            {
                Enemy.Physics.MovementVelocity = Vector2.Zero;
            }
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new MagicBoomerangProjectile(Enemy.Physics));
        }
    }
}