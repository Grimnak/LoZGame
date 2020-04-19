﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownLeftMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public DownLeftMovingEnemyState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            RandomDirectionChange();
            this.Enemy.Physics.MovementVelocity = new Vector2(-1 * this.Enemy.MoveSpeed, this.Enemy.MoveSpeed);
            this.Enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
        }
    }
}