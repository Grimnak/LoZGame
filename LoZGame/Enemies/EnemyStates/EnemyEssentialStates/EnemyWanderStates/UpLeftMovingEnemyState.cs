namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class UpLeftMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private float accelerationMax;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;
        private Random randomDirectionCooldown;

        public UpLeftMovingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            RandomDirectionChange();
            Enemy.Physics.MovementVelocity = new Vector2(-1 * Enemy.MoveSpeed, -1 * Enemy.MoveSpeed);
            Enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }
    }
}