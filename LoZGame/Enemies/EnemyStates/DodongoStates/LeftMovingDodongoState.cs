namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingDodongoState : DodongoEssentals, IEnemyState
    {
        public LeftMovingDodongoState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Enemy.MoveSpeed = GameData.Instance.EnemySpeedData.DodongoSpeed;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(-1 * this.Enemy.MoveSpeed, 0);
        }
    }
}