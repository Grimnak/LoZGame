namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class MagicBoomerangProjectileSprite : SpriteEssentials, ISprite
    {
        public MagicBoomerangProjectileSprite(Texture2D texture, SpriteData data, int scale)
        {
            this.SetUpSprite(texture, data);
        }
    }
}