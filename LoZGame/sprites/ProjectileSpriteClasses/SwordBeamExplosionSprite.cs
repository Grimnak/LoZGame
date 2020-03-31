namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamExplosionSprite : SpriteEssentials, ISprite
    {
        public SwordBeamExplosionSprite(Texture2D texture, SpriteData data)
        {
            this.SetUpSprite(texture, data);
        }
    }
}