using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LinkSpriteFactory
    {
        private Texture2D linkIdleLeftTexture;
        //private SpriteSheetData linkIdleLeftData = new SpriteSheetData("Link_Idle_Left", 25, 25);
        private Texture2D linkIdleRightTexture;
        //private SpriteSheetData linkIdleRightData = new SpriteSheetData("Link_Idle_Right", 25, 25);

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
            //linkIdleLeftTexture = content.Load<Texture2D>(linkIdleLeftData.GetFilePath);
        }

        public Sprite CreateSprite_Link_Idle_Left()
        {
            return new Sprite(linkIdleLeftTexture, linkIdleLeftData);
        }

        public UnanimatedSprite CreateSprite_Link_Idle_Right()
        {
            return new UnanimatedSprite(linkIdleRightTexture, linkIdleRightData);
        }
    }
}
