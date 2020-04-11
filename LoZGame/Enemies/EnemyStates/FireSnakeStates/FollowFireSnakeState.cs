namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FollowFireSnakeState : FireSnakeEssentials, IEnemyState
    {

        public FollowFireSnakeState(IEnemy fireSnake)
        {
            this.Enemy = fireSnake;
            this.Sprite = ProjectileSpriteFactory.Instance.Fireball();
        }

        public override void Update()
        {
            this.Sprite.Update();
        }
    }
}