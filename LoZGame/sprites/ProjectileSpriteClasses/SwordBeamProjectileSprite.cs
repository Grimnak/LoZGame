namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamProjectileSprite : SpriteEssentials, ISprite
    {
        public SwordBeamProjectileSprite(Texture2D texture, SpriteData data)
        {
            this.SetUpSprite(texture, data);
        }
    }
}