namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpecialDoorRightSprite : SpriteEssentials, ISprite
    {
        public SpecialDoorRightSprite(Texture2D spriteTexture, SpriteData data)
        {
            this.SetUpSprite(spriteTexture, data);
        }
    }
}