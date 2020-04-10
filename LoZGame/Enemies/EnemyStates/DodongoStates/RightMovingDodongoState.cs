namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingDodongoState : DodongoEssentals, IEnemyState
    {
        public RightMovingDodongoState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(this.Enemy.MoveSpeed, 0);
        }
    }
}