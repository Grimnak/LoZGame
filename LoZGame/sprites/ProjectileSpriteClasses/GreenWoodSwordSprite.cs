namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class GreenWoodSwordSprite : SpriteEssentials, ISprite
    {
        public GreenWoodSwordSprite(Texture2D texture, SpriteData data)
        {
            this.SetUpSprite(texture, data);
        }
    }
}