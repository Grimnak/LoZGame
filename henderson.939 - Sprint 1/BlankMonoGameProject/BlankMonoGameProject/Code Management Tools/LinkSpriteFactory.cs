using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LinkSpriteFactory
    {
        private Texture2D linkIdleLeftTexture;
        private SpriteSheetData linkIdleLeftData = new SpriteSheetData("Link_Idle_Left", 25, 25, 1, 1);
        private Texture2D linkIdleRightTexture;
        private SpriteSheetData linkIdleRightData = new SpriteSheetData("Link_Idle_Right", 25, 25, 1, 1);

        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkIdleLeftTexture = content.Load<Texture2D>(linkIdleLeftData.GetFilePath);
            linkIdleRightTexture = content.Load<Texture2D>(linkIdleRightData.GetFilePath);
        }

        public LinkIdleLeftSprite CreateSprite_Link_Idle_Left()
        {
            return new LinkIdleLeftSprite(linkIdleLeftTexture, linkIdleLeftData);
        }

        public LinkIdleRightSprite CreateSprite_Link_Idle_Right()
        {
            return new LinkIdleRightSprite(linkIdleRightTexture, linkIdleRightData);
        }
    }
}
