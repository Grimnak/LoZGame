﻿namespace LoZGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IItemSprite
    {
        Vector2 Location { get; set; }

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}