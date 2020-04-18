﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingDarknutState : DarknutEssentials, IEnemyState
    {
        public UpMovingDarknutState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(0, -1 * this.Enemy.MoveSpeed);
        }
    }
}