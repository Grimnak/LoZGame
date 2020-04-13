namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public class UpMovingRopeState : RopeEssentials, IEnemyState
    {
        public UpMovingRopeState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.Enemy.MoveSpeed = GameData.Instance.EnemySpeedConstants.RopeSpeed;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(0, -1 * this.Enemy.MoveSpeed);
        }
    }
}