using System;
using Microsoft.Xna.Framework.Graphics;


namespace LoZClone
{
    public interface IEnemy
    {
        void moveLeft();
        void moveRight();
        void moveUp();
        void moveDown();
        void attack();
        void takeDamage();
        void die();
        void Update();
        void Draw(SpriteBatch sb);
    }
}