using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IDragonState
    {
        void moveLeft();
        void moveRight();
        void attack();
        void stop();
        void takeDamage();
        void die();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
