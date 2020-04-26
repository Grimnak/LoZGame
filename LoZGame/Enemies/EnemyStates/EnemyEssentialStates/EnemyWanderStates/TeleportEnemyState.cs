namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class TeleportEnemyState : EnemyStateEssentials, IEnemyState
    {
        public TeleportEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            Enemy.Physics.Bounds = GetNewBounds();
            RandomStateChange();
        }

        private Rectangle GetNewBounds()
        {
            float newXGridLocation = LoZGame.Instance.Random.Next(0, 11);
            float newYGridLocation = LoZGame.Instance.Random.Next(0, 6);
            Vector2 newScreenLocation = LoZGame.Instance.Dungeon.CurrentRoom.GridToScreenVector(newXGridLocation, newYGridLocation);

            return new Rectangle((int)newScreenLocation.X, (int)newScreenLocation.Y, EnemySpriteFactory.GetEnemyWidth(Enemy), EnemySpriteFactory.GetEnemyHeight(Enemy));
        }
    }
}