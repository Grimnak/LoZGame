namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class HorizontalBricksSprite : SpriteEssentials, ISprite
    {
        public HorizontalBricksSprite(Texture2D spriteTexture, SpriteData data)
        {
            this.SetUpSprite(spriteTexture, data);
        }
    }
}