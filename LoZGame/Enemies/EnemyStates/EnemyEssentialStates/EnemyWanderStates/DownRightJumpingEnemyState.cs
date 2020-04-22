﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownRightJumpingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public DownRightJumpingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            RandomDirectionChange();
            Enemy.Physics.MovementVelocity = new Vector2(Enemy.MoveSpeed, Enemy.MoveSpeed);
            Enemy.Physics.MovementVelocity *= (float)Math.Sqrt(0.5);
            Enemy.Physics.Jump(GameData.Instance.EnemySpeedConstants.JumpStrength);
        }

        public override void Update()
        {
            base.Update();
            HandleJump();
        }
    }
}