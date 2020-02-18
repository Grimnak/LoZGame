namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IRopeSprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint);
    }
}