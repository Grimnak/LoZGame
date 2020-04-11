namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingZolState : ZolEssentials, IEnemyState
    {
        public LeftMovingZolState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.RandomMovementTimes();
            this.Enemy.Physics.MovementVelocity = new Vector2(-this.Enemy.MoveSpeed, 0);
        }
    }
}