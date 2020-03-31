namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class VerticalBricksSprite : SpriteEssentials,  ISprite
    {
        public VerticalBricksSprite(Texture2D spriteTexture, SpriteData data)
        {
            this.SetUpSprite(spriteTexture, data);
        }
    }