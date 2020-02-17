using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IEnemyState
    {
        void moveLeft();

        void moveRight();

        void moveUp();

        void moveDown();

        void takeDamage();

        void die();

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}
