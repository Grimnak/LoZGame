namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingWallMasterState : WallMasterEssentials, IEnemyState
    {
        public LeftMovingWallMasterState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            this.Sprite = EnemySpriteFactory.Instance.CreateLeftMovingWallMasterSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(-1 * this.Enemy.MoveSpeed, 0);
        }
    }
}