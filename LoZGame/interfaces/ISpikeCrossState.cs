using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface ISpikeCrossState
    {
        void moveLeft();
        void moveRight();
        void moveUp();
        void moveDown();
        void stop();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
