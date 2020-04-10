namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingGoriyaState : GoriyaEssentials, IEnemyState
    {
        public RightMovingGoriyaState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.Physics.MovementVelocity = new Vector2(this.Enemy.MoveSpeed, 0);
        }
    }
}