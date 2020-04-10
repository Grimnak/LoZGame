namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingDragonState : DragonEssentials, IEnemyState
    {

        public RightMovingDragonState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = new Vector2(this.Enemy.MoveSpeed, 0);
        }
    }
}