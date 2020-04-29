namespace LoZClone
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
            RandomStateChange();
            float moveSpeed = Enemy.MoveSpeed;
            moveSpeed += LoZGame.Instance.Difficulty > 0 ? GameData.Instance.DifficultyConstants.SmallMoveMod : 0;
            Enemy.Physics.MovementVelocity = new Vector2(moveSpeed, moveSpeed);
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