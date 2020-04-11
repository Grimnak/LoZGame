namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FollowFireSnakeState : FireSnakeEssentials, IEnemyState
    {

        public FollowFireSnakeState(IEnemy fireSnake)
        {
            this.Enemy = fireSnake;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Sprite.SetFrame(2);
        }

        public override void Update()
        {
        }
    }
}