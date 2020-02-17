namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    interface IProjectile
    {
        bool IsExpired { get; }

        int Instance { get; }

        bool IsHostile { get; }

        Vector2 location { get; }

        void Update();

        void Draw(SpriteBatch spriteBatch);

    }
}
