namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework.Graphics;

    public class BlueCandleProjectileSprite : SpriteEssentials,  ISprite
    {
        public BlueCandleProjectileSprite(Texture2D texture, SpriteData data)
        {
            this.SetUpSprite(texture, data);
        }
    }
}
