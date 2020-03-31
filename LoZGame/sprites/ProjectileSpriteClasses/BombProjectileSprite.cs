namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombProjectileSprite : SpriteEssentials, ISprite
    {
        public BombProjectileSprite(Texture2D texture, SpriteData data, int scale)
        {
            this.SetUpSprite(texture, data);
        }
    }
}