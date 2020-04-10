namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class IdleKeeseState : KeeseEssentials, IEnemyState
    {
        public IdleKeeseState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            RandomDirectionChange();
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }
    }
}
