namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class IdleDragonState : DragonEssentials, IEnemyState
    {
        public IdleDragonState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }
    }
}