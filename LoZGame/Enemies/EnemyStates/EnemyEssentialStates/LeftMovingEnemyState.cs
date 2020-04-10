﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class LeftMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public LeftMovingEnemyState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.Physics.MovementVelocity = new Vector2(0, -1 * this.Enemy.MoveSpeed);
        }
    }
}