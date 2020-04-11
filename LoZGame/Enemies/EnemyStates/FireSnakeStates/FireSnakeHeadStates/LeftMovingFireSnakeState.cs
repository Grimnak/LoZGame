namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class LeftMovingFireSnakeState : FireSnakeEssentials, IEnemyState
    {
        public LeftMovingFireSnakeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Enemy.Physics.MovementVelocity = new Vector2(-1 * this.Enemy.MoveSpeed, 0);
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorDirection(RandomStateGenerator.StateType.MoveNorthWest);
            }
            base.Update();
        }
    }
}