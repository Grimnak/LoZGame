namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownRightMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public DownRightMovingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            RandomStateChange();
            Enemy.Physics.MovementVelocity = new Vector2(Enemy.MoveSpeed, Enemy.MoveSpeed);
            Enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }
    }
}