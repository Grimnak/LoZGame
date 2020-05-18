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
            if (fireSnake is RedMoldormSegment)
            {
                Sprite.SetFrame(2);
            }
            else if (fireSnake is BlueMoldormSegment)
            {
                Sprite.SetFrame(3);
            }
        }

        public override void Update()
        {
        }
    }
}