namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class EnemyStateEssentials
    {
        public void UpdateRedWizzrobe()
        {
            Physics.Direction oldDirection = Enemy.Physics.CurrentDirection;
            FacePlayer();
            Physics.Direction newDirection = Enemy.Physics.CurrentDirection;

            if (oldDirection != newDirection)
            {
                Enemy.CreateCorrectSprite();
            }

            DefaultUpdate();
        }
    }
}