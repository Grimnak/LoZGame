namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DownMovingWallMasterState : WallMasterEssentials, IEnemyState
    {
        public DownMovingWallMasterState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            this.Sprite = EnemySpriteFactory.Instance.CreateLeftMovingWallMasterSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(0, this.Enemy.MoveSpeed);
        }
    }
}