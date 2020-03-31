namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FireballSprite : SpriteEssentials, ISprite
    {
        public FireballSprite(Texture2D texture, SpriteData data)
        {
            this.SetUpSprite(texture, data);
        }
    }
}