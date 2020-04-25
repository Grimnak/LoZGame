namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class IdleEnemyState : EnemyStateEssentials, IEnemyState
    {
        public IdleEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.CurrentState = this;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.Physics.MovementVelocity = Vector2.Zero;
            RandomDirectionChange();
        }
    }
}