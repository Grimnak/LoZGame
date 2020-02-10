using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IEnemySprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Color spriteTint);
        public void Attack();
    }
}
