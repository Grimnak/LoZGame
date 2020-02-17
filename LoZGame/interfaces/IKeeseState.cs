using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IKeeseState
    {
        void moveLeft();

        void moveRight();

        void moveUp();

        void moveDown();

        void moveUpLeft();

        void moveDownLeft();

        void moveUpRight();

        void moveDownRight();

        void takeDamage();

        void die();

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}
