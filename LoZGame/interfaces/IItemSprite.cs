using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IItemSprite
    {
        Vector2 location { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}