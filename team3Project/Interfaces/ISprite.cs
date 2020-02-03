using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Color spriteTint);
    }
}