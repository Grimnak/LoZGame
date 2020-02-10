using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LinkSpriteFactory
    {
        private Texture2D greenLinkUpTexture;
        private SpriteSheetData greenLinkUpData = new SpriteSheetData("Green_Link_Up", 7, 1);
        private Texture2D blueLinkUpTexture;
        private SpriteSheetData blueLinkUpData = new SpriteSheetData("Blue_Link_Up", 7, 1);
        private Texture2D redLinkUpTexture;
        private SpriteSheetData redLinkUpData = new SpriteSheetData("Red_Link_Up", 7, 1);

        private Texture2D greenLinkDownTexture;
        private SpriteSheetData greenLinkDownData = new SpriteSheetData("Green_Link_Down", 7, 1);
        private Texture2D blueLinkDownTexture;
        private SpriteSheetData blueLinkDownData = new SpriteSheetData("Blue_Link_Down", 7, 1);
        private Texture2D redLinkDownTexture;
        private SpriteSheetData redLinkDownData = new SpriteSheetData("Red_Link_Down", 7, 1);

        private Texture2D greenLinkLeftTexture;
        private SpriteSheetData greenLinkLeftData = new SpriteSheetData("Green_Link_Left", 7, 1);
        private Texture2D blueLinkLeftTexture;
        private SpriteSheetData blueLinkLeftData = new SpriteSheetData("Blue_Link_Left", 7, 1);
        private Texture2D redLinkLeftTexture;
        private SpriteSheetData redLinkLeftData = new SpriteSheetData("Red_Link_Left", 7, 1);

        private Texture2D greenLinkRightTexture;
        private SpriteSheetData greenLinkRightData = new SpriteSheetData("Green_Link_Right", 7, 1);
        private Texture2D blueLinkRightTexture;
        private SpriteSheetData blueLinkRightData = new SpriteSheetData("Blue_Link_Right", 7, 1);
        private Texture2D redLinkRightTexture;
        private SpriteSheetData redLinkRightData = new SpriteSheetData("Red_Link_Right", 7, 1);

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
            greenLinkUpTexture = content.Load<Texture2D>(greenLinkUpData.FilePath);
            blueLinkUpTexture = content.Load<Texture2D>(blueLinkUpData.FilePath);
            redLinkUpTexture = content.Load<Texture2D>(redLinkUpData.FilePath);

            greenLinkDownTexture = content.Load<Texture2D>(greenLinkDownData.FilePath);
            blueLinkDownTexture = content.Load<Texture2D>(blueLinkDownData.FilePath);
            redLinkDownTexture = content.Load<Texture2D>(redLinkDownData.FilePath);

            greenLinkLeftTexture = content.Load<Texture2D>(greenLinkLeftData.FilePath);
            blueLinkLeftTexture = content.Load<Texture2D>(blueLinkLeftData.FilePath);
            redLinkLeftTexture = content.Load<Texture2D>(redLinkLeftData.FilePath);

            greenLinkRightTexture = content.Load<Texture2D>(greenLinkRightData.FilePath);
            blueLinkRightTexture = content.Load<Texture2D>(blueLinkRightData.FilePath);
            redLinkRightTexture = content.Load<Texture2D>(redLinkRightData.FilePath);
        }

        public LinkIdleUpSprite createSpriteLinkIdleUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkIdleUpSprite(redLinkUpTexture, redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkIdleUpSprite(blueLinkUpTexture, blueLinkUpData);
            }
            else
            {
                return new LinkIdleUpSprite(greenLinkUpTexture, greenLinkUpData);
            }
        }
        public LinkIdleDownSprite createSpriteLinkIdleDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkIdleDownSprite(redLinkDownTexture, redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkIdleDownSprite(blueLinkDownTexture, blueLinkDownData);
            }
            else
            {
                return new LinkIdleDownSprite(greenLinkDownTexture, greenLinkDownData);
            }
        }
        public LinkIdleLeftSprite createSpriteLinkIdleLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkIdleLeftSprite(redLinkLeftTexture, redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkIdleLeftSprite(blueLinkLeftTexture, blueLinkLeftData);
            }
            else
            {
                return new LinkIdleLeftSprite(greenLinkLeftTexture, greenLinkLeftData);
            }
        }
        public LinkIdleRightSprite createSpriteLinkIdleRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkIdleRightSprite(redLinkRightTexture, redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkIdleRightSprite(blueLinkRightTexture, blueLinkRightData);
            }
            else
            {
                return new LinkIdleRightSprite(greenLinkRightTexture, greenLinkRightData);
            }
        }

        public LinkMoveUpSprite createSpriteLinkMoveUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkMoveUpSprite(redLinkUpTexture, redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkMoveUpSprite(blueLinkUpTexture, blueLinkUpData);
            }
            else
            {
                return new LinkMoveUpSprite(greenLinkUpTexture, greenLinkUpData);
            }
        }
        public LinkMoveDownSprite createSpriteLinkMoveDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkMoveDownSprite(redLinkDownTexture, redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkMoveDownSprite(blueLinkDownTexture, blueLinkDownData);
            }
            else
            {
                return new LinkMoveDownSprite(greenLinkDownTexture, greenLinkDownData);
            }
        }
        public LinkMoveLeftSprite createSpriteLinkMoveLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkMoveLeftSprite(redLinkLeftTexture, redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkMoveLeftSprite(blueLinkLeftTexture, blueLinkLeftData);
            }
            else
            {
                return new LinkMoveLeftSprite(greenLinkLeftTexture, greenLinkLeftData);
            }
        }
        public LinkMoveRightSprite createSpriteLinkMoveRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkMoveRightSprite(redLinkRightTexture, redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkMoveRightSprite(blueLinkRightTexture, blueLinkRightData);
            }
            else
            {
                return new LinkMoveRightSprite(greenLinkRightTexture, greenLinkRightData);
            }
        }
        public LinkAttackUpSprite createSpriteLinkAttackUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkAttackUpSprite(redLinkUpTexture, redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkAttackUpSprite(blueLinkUpTexture, blueLinkUpData);
            }
            else
            {
                return new LinkAttackUpSprite(greenLinkUpTexture, greenLinkUpData);
            }
        }
        public LinkAttackDownSprite createSpriteLinkAttackDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkAttackDownSprite(redLinkDownTexture, redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkAttackDownSprite(blueLinkDownTexture, blueLinkDownData);
            }
            else
            {
                return new LinkAttackDownSprite(greenLinkDownTexture, greenLinkDownData);
            }
        }
        public LinkAttackLeftSprite createSpriteLinkAttackLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkAttackLeftSprite(redLinkLeftTexture, redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkAttackLeftSprite(blueLinkLeftTexture, blueLinkLeftData);
            }
            else
            {
                return new LinkAttackLeftSprite(greenLinkLeftTexture, greenLinkLeftData);
            }
        }
        public LinkAttackRightSprite createSpriteLinkAttackRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkAttackRightSprite(redLinkRightTexture, redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkAttackRightSprite(blueLinkRightTexture, blueLinkRightData);
            }
            else
            {
                return new LinkAttackRightSprite(greenLinkRightTexture, greenLinkRightData);
            }
        }
    }
}
