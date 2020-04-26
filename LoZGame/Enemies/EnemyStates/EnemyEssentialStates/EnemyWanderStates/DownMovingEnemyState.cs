namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public DownMovingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            RandomStateChange();
            Enemy.Physics.MovementVelocity = new Vector2(0, Enemy.MoveSpeed);
        }
    }
}