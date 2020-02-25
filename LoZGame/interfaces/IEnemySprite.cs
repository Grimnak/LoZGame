namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IEnemySprite
    {
        void Update();

        void Draw(Vector2 location, Color spriteTint);
    }
}