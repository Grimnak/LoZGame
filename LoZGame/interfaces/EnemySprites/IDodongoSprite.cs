﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public interface IDodongoprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint);
    }
}