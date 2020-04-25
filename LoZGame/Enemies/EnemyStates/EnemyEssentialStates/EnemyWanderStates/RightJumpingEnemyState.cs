namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class RightJumpingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public RightJumpingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            RandomDirectionChange();
            Enemy.Physics.MovementVelocity = new Vector2(Enemy.MoveSpeed, 0);
            Enemy.Physics.Jump(GameData.Instance.EnemySpeedConstants.JumpStrength);
        }

        public override void Update()
        {
            base.Update();
            HandleJump();
        }
    }
}