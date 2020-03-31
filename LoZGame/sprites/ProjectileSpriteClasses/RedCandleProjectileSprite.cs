namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class RedCandleProjectileSprite : SpriteEssentials, ISprite
    {
        public RedCandleProjectileSprite(Texture2D texture, SpriteData data, int scale)
        {
            this.SetUpSprite(texture, data);
        }
    }
}