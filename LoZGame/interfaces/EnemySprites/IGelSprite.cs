namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IGelSprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint);
    }
}