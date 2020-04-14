namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingZolState : ZolEssentials, IEnemyState
    {
        public UpMovingZolState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.RandomMovementTimes();
            this.Enemy.Physics.MovementVelocity = new Vector2(0, -this.Enemy.MoveSpeed);
        }
    }
}