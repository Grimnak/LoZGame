using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoZClone
{
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
