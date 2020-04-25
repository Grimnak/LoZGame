namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class UpJumpingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public UpJumpingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            RandomDirectionChange();
            Enemy.Physics.MovementVelocity = new Vector2(0, -1 * Enemy.MoveSpeed);
            Enemy.Physics.Jump(GameData.Instance.EnemySpeedConstants.JumpStrength);
        }

        public override void Update()
        {
            base.Update();
            HandleJump();
        }
    }
}