namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class LeftJumpingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public LeftJumpingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            RandomStateChange();
            Enemy.Physics.MovementVelocity = new Vector2(-1 * Enemy.MoveSpeed, 0);
            Enemy.Physics.Jump(GameData.Instance.EnemySpeedConstants.JumpStrength);
        }

        public override void Update()
        {
            base.Update();
            HandleJump();
        }
    }
}