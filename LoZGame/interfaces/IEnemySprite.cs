using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IEnemySprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Color spriteTint);
        void Attack();

    }
}
