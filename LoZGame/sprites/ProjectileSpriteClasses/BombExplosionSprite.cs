namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombExplosionSprite : SpriteEssentials, ISprite
    {
        public BombExplosionSprite(Texture2D texture, SpriteData data, int scale)
        {
            this.SetUpSprite(texture, data);
        }
    }
}