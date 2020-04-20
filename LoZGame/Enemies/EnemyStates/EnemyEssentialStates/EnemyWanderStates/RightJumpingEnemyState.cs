namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class RightJumpingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public RightJumpingEnemyState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            RandomDirectionChange();
            this.Enemy.Physics.MovementVelocity = new Vector2(this.Enemy.MoveSpeed, 0);
            this.Enemy.Physics.Jump(GameData.Instance.EnemySpeedConstants.JumpStrength);
        }

        public override void Update()
        {
            base.Update();
            HandleJump();
        }
    }
}