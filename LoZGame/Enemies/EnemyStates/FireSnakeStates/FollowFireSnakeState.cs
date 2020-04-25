namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FollowFireSnakeState : EnemyStateEssentials, IEnemyState
    {
        public FollowFireSnakeState(IEnemy fireSnake)
        {
            Enemy = fireSnake;
            Sprite = Enemy.CreateCorrectSprite();
            Sprite.SetFrame(2);
        }

        public override void Update()
        {
        }
    }
}