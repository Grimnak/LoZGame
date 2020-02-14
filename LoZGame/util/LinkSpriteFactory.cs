using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LinkSpriteFactory
    {
        private Texture2D greenLinkUpTexture;
        private SpriteSheetData greenLinkUpData = new SpriteSheetData("Green_Link_Up", 50, 50, 7, 1);
        private Texture2D blueLinkUpTexture;
        private SpriteSheetData blueLinkUpData = new SpriteSheetData("Blue_Link_Up", 50, 50, 7, 1);
        private Texture2D redLinkUpTexture;
        private SpriteSheetData redLinkUpData = new SpriteSheetData("Red_Link_Up", 50, 50, 7, 1);

        private Texture2D greenLinkDownTexture;
        private SpriteSheetData greenLinkDownData = new SpriteSheetData("Green_Link_Down", 50, 50, 7, 1);
        private Texture2D blueLinkDownTexture;
        private SpriteSheetData blueLinkDownData = new SpriteSheetData("Blue_Link_Down", 50, 50, 7, 1);
        private Texture2D redLinkDownTexture;
        private SpriteSheetData redLinkDownData = new SpriteSheetData("Red_Link_Down", 50, 50, 7, 1);

        private Texture2D greenLinkLeftTexture;
        private SpriteSheetData greenLinkLeftData = new SpriteSheetData("Green_Link_Left", 50, 50, 7, 1);
        private Texture2D blueLinkLeftTexture;
        private SpriteSheetData blueLinkLeftData = new SpriteSheetData("Blue_Link_Left", 50, 50, 7, 1);
        private Texture2D redLinkLeftTexture;
        private SpriteSheetData redLinkLeftData = new SpriteSheetData("Red_Link_Left", 50, 50, 7, 1);

        private Texture2D greenLinkRightTexture;
        private SpriteSheetData greenLinkRightData = new SpriteSheetData("Green_Link_Right", 50, 50, 7, 1);
        private Texture2D blueLinkRightTexture;
        private SpriteSheetData blueLinkRightData = new SpriteSheetData("Blue_Link_Right", 50, 50, 7, 1);
        private Texture2D redLinkRightTexture;
        private SpriteSheetData redLinkRightData = new SpriteSheetData("Red_Link_Right", 50, 50, 7, 1);

        private Texture2D greenLinkDieTexture;
        private SpriteSheetData greenLinkDieData = new SpriteSheetData("Green_Link_Die", 33, 33, 1, 16);
        private Texture2D blueLinkDieTexture;
        private SpriteSheetData blueLinkDieData = new SpriteSheetData("Blue_Link_Die", 33, 33, 1, 16);
        private Texture2D redLinkDieTexture;
        private SpriteSheetData redLinkDieData = new SpriteSheetData("Red_Link_Die", 30, 30, 1, 16);

        private Texture2D greenLinkPickupTexture;
        private SpriteSheetData greenLinkPickupData = new SpriteSheetData("Green_Link_Pickup", 30, 30, 1, 2);
        private Texture2D blueLinkPickupTexture;
        private SpriteSheetData blueLinkPickupData = new SpriteSheetData("Blue_Link_Pickup", 30, 30, 1, 2);
        private Texture2D redLinkPickupTexture;
        private SpriteSheetData redLinkPickupData = new SpriteSheetData("Red_Link_Pickup", 30, 30, 1, 2);


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

            greenLinkDieTexture = content.Load<Texture2D>(greenLinkDieData.FilePath);
            blueLinkDieTexture = content.Load<Texture2D>(blueLinkDieData.FilePath);
            redLinkDieTexture = content.Load<Texture2D>(redLinkDieData.FilePath);

            greenLinkPickupTexture = content.Load<Texture2D>(greenLinkPickupData.FilePath);
            blueLinkPickupTexture = content.Load<Texture2D>(blueLinkPickupData.FilePath);
            redLinkPickupTexture = content.Load<Texture2D>(redLinkPickupData.FilePath);
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
        public LinkPickupItemSprite createSpriteLinkPickupItem(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkPickupItemSprite(redLinkPickupTexture, redLinkPickupData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkPickupItemSprite(blueLinkPickupTexture, blueLinkPickupData);
            }
            else
            {
                return new LinkPickupItemSprite(greenLinkPickupTexture, greenLinkPickupData);
            }
        }
        public LinkUseItemUpSprite createSpriteLinkUseItemUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkUseItemUpSprite(redLinkUpTexture, redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkUseItemUpSprite(blueLinkUpTexture, blueLinkUpData);
            }
            else
            {
                return new LinkUseItemUpSprite(greenLinkUpTexture, greenLinkUpData);
            }
        }
        public LinkUseItemDownSprite createSpriteLinkUseItemDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkUseItemDownSprite(redLinkDownTexture, redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkUseItemDownSprite(blueLinkDownTexture, blueLinkDownData);
            }
            else
            {
                return new LinkUseItemDownSprite(greenLinkDownTexture, greenLinkDownData);
            }
        }
        public LinkUseItemLeftSprite createSpriteLinkUseItemLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkUseItemLeftSprite(redLinkLeftTexture, redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkUseItemLeftSprite(blueLinkLeftTexture, blueLinkLeftData);
            }
            else
            {
                return new LinkUseItemLeftSprite(greenLinkLeftTexture, greenLinkLeftData);
            }
        }
        public LinkUseItemRightSprite createSpriteLinkUseItemRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkUseItemRightSprite(redLinkRightTexture, redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkUseItemRightSprite(blueLinkRightTexture, blueLinkRightData);
            }
            else
            {
                return new LinkUseItemRightSprite(greenLinkRightTexture, greenLinkRightData);
            }
        }
        public LinkDieSprite createSpriteLinkDie(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkDieSprite(redLinkDieTexture, redLinkDieData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkDieSprite(blueLinkDieTexture, blueLinkDieData);
            }
            else
            {
                return new LinkDieSprite(greenLinkDieTexture, greenLinkDieData);
            }
        }
    }
}
