namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SilverArrowProjectileSprite : SpriteEssentials, ISprite
    {
        public SilverArrowProjectileSprite(Texture2D texture, SpriteData data, float rotation, int scale)
        {
            this.SetUpSprite(texture, data);
        }
    }
}