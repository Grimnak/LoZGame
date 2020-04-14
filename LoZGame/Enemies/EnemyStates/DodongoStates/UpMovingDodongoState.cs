namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingDodongoState : DodongoEssentials, IEnemyState
    {
        public UpMovingDodongoState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            this.Enemy.MoveSpeed = GameData.Instance.EnemySpeedConstants.DodongoSpeed;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(0, -1 * this.Enemy.MoveSpeed);
        }
    }
}