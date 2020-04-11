namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownLeftMovingFireSnakeState : FireSnakeEssentials, IEnemyState
    {
        public DownLeftMovingFireSnakeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Enemy.Physics.MovementVelocity = new Vector2(-1 * this.Enemy.MoveSpeed, this.Enemy.MoveSpeed);
            this.Enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorDirection(RandomStateGenerator.StateType.MoveWest);
            }
            base.Update();
        }
    }
}