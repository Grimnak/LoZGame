namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class RightMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public RightMovingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.CurrentState = this;
            Sprite = Enemy.CreateCorrectSprite();
            RandomStateChange();
            Enemy.Physics.MovementVelocity = new Vector2(Enemy.MoveSpeed, 0);
        }
    }
}