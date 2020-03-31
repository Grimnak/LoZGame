namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class WaterTileSprite : SpriteEssentials, ISprite
    {
        public WaterTileSprite(Texture2D spriteTexture, SpriteData data)
        {
            this.SetUpSprite(spriteTexture, data);
        }
    }
}