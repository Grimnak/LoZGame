using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IDodongoSprite
    {
        void update();
        void draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint);
    }
}