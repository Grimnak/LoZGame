namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class UpRightMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private float accelerationMax;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;
        private Random randomDirectionCooldown;

        public UpRightMovingEnemyState(IEnemy enemy)
        {
            this.enemy = enemy;
            this.enemy.CurrentState = this;
            this.enemy.Physics.MovementVelocity = new Vector2(this.enemy.MoveSpeed, -1 * this.enemy.MoveSpeed);
            this.enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }
    }
}