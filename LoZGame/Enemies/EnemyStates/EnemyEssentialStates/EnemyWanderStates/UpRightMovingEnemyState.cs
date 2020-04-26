namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class UpRightMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public UpRightMovingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            RandomStateChange();
            Enemy.Physics.MovementVelocity = new Vector2(Enemy.MoveSpeed, -1 * Enemy.MoveSpeed);
            Enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }
    }
}