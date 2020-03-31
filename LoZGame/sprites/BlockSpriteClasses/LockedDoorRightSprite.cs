namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LockedDoorRightSprite : SpriteEssentials, ISprite
    {
        public LockedDoorRightSprite(Texture2D spriteTexture, SpriteData data)
        {
            this.SetUpSprite(spriteTexture, data);
        }
    }
}