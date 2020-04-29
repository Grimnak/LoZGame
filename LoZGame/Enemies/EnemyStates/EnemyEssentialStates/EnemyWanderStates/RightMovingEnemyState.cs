namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class RightMovingEnemyState : EnemyStateEssentials, IEnemyState
    {
        public RightMovingEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.CurrentState = this;
            Sprite = Enemy.CreateCorrectSprite();
            RandomStateChange();
            float moveSpeed = Enemy.MoveSpeed;
            moveSpeed += LoZGame.Instance.Difficulty > 0 ? GameData.Instance.DifficultyConstants.SmallMoveMod : 0;
            Enemy.Physics.MovementVelocity = new Vector2(moveSpeed, 0);
        }
    }
}