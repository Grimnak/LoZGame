namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class DownLeftMovingKeeseState : KeeseEssentials, IEnemyState
    {
        public DownLeftMovingKeeseState(IEnemy enemy)
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