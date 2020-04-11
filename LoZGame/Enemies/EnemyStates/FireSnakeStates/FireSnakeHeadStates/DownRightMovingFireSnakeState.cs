namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownRightMovingFireSnakeState : FireSnakeEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private int lifeTime = 0;
        private float accelerationMax;
        private int directionChange;
        private RandomStateGenerator randomStateGenerator;
        private Random randomDirectionCooldown;

        public DownRightMovingFireSnakeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Enemy.Physics.MovementVelocity = new Vector2(this.Enemy.MoveSpeed, this.Enemy.MoveSpeed);
            this.Enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorDirection(RandomStateGenerator.StateType.MoveSouth);
            }
            base.Update();
        }
    }
}