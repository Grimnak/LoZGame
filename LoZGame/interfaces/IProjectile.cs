namespace LoZGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal interface IProjectile
    {
        bool IsExpired { get; }

        int Instance { get; }

        bool IsHostile { get; }

        Vector2 Location { get; }

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}