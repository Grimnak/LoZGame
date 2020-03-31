namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class ArrowProjectileSprite : SpriteEssentials, ISprite
    {
        public ArrowProjectileSprite(Texture2D texture, SpriteData data)
        {
            this.SetUpSprite(texture, data);
        }
    }
}