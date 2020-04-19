namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class AttackingBlueGoriyaState : EnemyStateEssentials, IEnemyState
    {
        public AttackingBlueGoriyaState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            FacePlayer();
            this.Sprite = this.Enemy.CreateCorrectSprite();
            if (LoZGame.Instance.Difficulty < 2)
            {
                this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            }
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new MagicBoomerangProjectile(this.Enemy.Physics));
        }
    }
}