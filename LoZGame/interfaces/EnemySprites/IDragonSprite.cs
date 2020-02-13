using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface DragonSprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint);
    }
}