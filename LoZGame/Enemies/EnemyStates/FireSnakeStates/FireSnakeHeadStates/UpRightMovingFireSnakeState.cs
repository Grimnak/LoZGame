namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using static RandomStateGenerator;

    public class UpRightMovingFireSnakeState : FireSnakeEssentials, IEnemyState
    {
        public UpRightMovingFireSnakeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Enemy.Physics.MovementVelocity = new Vector2(this.Enemy.MoveSpeed, -1 * this.Enemy.MoveSpeed);
            this.Enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorDirection(StateType.MoveEast);
            }
            base.Update();
        }
    }
}