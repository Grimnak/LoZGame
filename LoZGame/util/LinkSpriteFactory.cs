using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LinkSpriteFactory
    {
        private static int linkWidth = 30;
        private static int linkHeight = 30;

        private static int itemWidth = 30; // items link holds in his hand during attack
        private static int itemHeight = 30;

        private Texture2D greenLinkUpTexture;
        private SpriteSheetData greenLinkUpData = new SpriteSheetData("Green_Link_Up", linkWidth, linkHeight, 3, 1);
        private Texture2D blueLinkUpTexture;
        private SpriteSheetData blueLinkUpData = new SpriteSheetData("Blue_Link_Up", linkWidth, linkHeight, 3, 1);
        private Texture2D redLinkUpTexture;
        private SpriteSheetData redLinkUpData = new SpriteSheetData("Red_Link_Up", linkWidth, linkHeight, 3, 1);

        private Texture2D greenLinkDownTexture;
        private SpriteSheetData greenLinkDownData = new SpriteSheetData("Green_Link_Down", linkWidth, linkHeight, 3, 1);
        private Texture2D blueLinkDownTexture;
        private SpriteSheetData blueLinkDownData = new SpriteSheetData("Blue_Link_Down", linkWidth, linkHeight, 3, 1);
        private Texture2D redLinkDownTexture;
        private SpriteSheetData redLinkDownData = new SpriteSheetData("Red_Link_Down", linkWidth, linkHeight, 3, 1);

        private Texture2D greenLinkLeftTexture;
        private SpriteSheetData greenLinkLeftData = new SpriteSheetData("Green_Link_Left", linkWidth, linkHeight, 3, 1);
        private Texture2D blueLinkLeftTexture;
        private SpriteSheetData blueLinkLeftData = new SpriteSheetData("Blue_Link_Left", linkWidth, linkHeight, 3, 1);
        private Texture2D redLinkLeftTexture;
        private SpriteSheetData redLinkLeftData = new SpriteSheetData("Red_Link_Left", linkWidth, linkHeight, 3, 1);

        private Texture2D greenLinkRightTexture;
        private SpriteSheetData greenLinkRightData = new SpriteSheetData("Green_Link_Right", linkWidth, linkHeight, 3, 1);
        private Texture2D blueLinkRightTexture;
        private SpriteSheetData blueLinkRightData = new SpriteSheetData("Blue_Link_Right", linkWidth, linkHeight, 3, 1);
        private Texture2D redLinkRightTexture;
        private SpriteSheetData redLinkRightData = new SpriteSheetData("Red_Link_Right", linkWidth, linkHeight, 3, 1);

        private Texture2D greenLinkDieTexture;
        private SpriteSheetData greenLinkDieData = new SpriteSheetData("Green_Link_Die", linkWidth, linkHeight, 1, 17);
        private Texture2D blueLinkDieTexture;
        private SpriteSheetData blueLinkDieData = new SpriteSheetData("Blue_Link_Die", linkWidth, linkHeight, 1, 17);
        private Texture2D redLinkDieTexture;
        private SpriteSheetData redLinkDieData = new SpriteSheetData("Red_Link_Die", linkWidth, linkHeight, 1, 17);

        private Texture2D greenLinkPickupTexture;
        private SpriteSheetData greenLinkPickupData = new SpriteSheetData("Green_Link_Pickup", linkWidth, linkHeight, 2, 1);
        private Texture2D blueLinkPickupTexture;
        private SpriteSheetData blueLinkPickupData = new SpriteSheetData("Blue_Link_Pickup", linkWidth, linkHeight, 2, 1);
        private Texture2D redLinkPickupTexture;
        private SpriteSheetData redLinkPickupData = new SpriteSheetData("Red_Link_Pickup", linkWidth, linkHeight, 2, 1);

        // items link holds in his hand during attack
        private Texture2D greenWoodDownTexture;
        private SpriteSheetData greenWoodDownData = new SpriteSheetData("Green_Wood_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D greenWoodLeftTexture;
        private SpriteSheetData greenWoodLeftData = new SpriteSheetData("Green_Wood_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D greenWoodRightTexture;
        private SpriteSheetData greenWoodRightData = new SpriteSheetData("Green_Wood_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D greenWoodUpTexture;
        private SpriteSheetData greenWoodUpData = new SpriteSheetData("Green_Wood_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D blueWoodDownTexture;
        private SpriteSheetData blueWoodDownData = new SpriteSheetData("Blue_Wood_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D blueWoodLeftTexture;
        private SpriteSheetData blueWoodLeftData = new SpriteSheetData("Blue_Wood_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D blueWoodRightTexture;
        private SpriteSheetData blueWoodRightData = new SpriteSheetData("Blue_Wood_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D blueWoodUpTexture;
        private SpriteSheetData blueWoodUpData = new SpriteSheetData("Blue_Wood_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D redWoodDownTexture;
        private SpriteSheetData redWoodDownData = new SpriteSheetData("Red_Wood_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D redWoodLeftTexture;
        private SpriteSheetData redWoodLeftData = new SpriteSheetData("Red_Wood_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D redWoodRightTexture;
        private SpriteSheetData redWoodRightData = new SpriteSheetData("Red_Wood_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D redWoodUpTexture;
        private SpriteSheetData redWoodUpData = new SpriteSheetData("Red_Wood_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D WandDownTexture;
        private SpriteSheetData WandDownData = new SpriteSheetData("Wand_Down", itemWidth, itemHeight, 1, 1);
        private Texture2D WandLeftTexture;
        private SpriteSheetData WandLeftData = new SpriteSheetData("Wand_Left", itemWidth, itemHeight, 1, 1);
        private Texture2D WandRightTexture;
        private SpriteSheetData WandRightData = new SpriteSheetData("Wand_Right", itemWidth, itemHeight, 1, 1);
        private Texture2D WandUpTexture;
        private SpriteSheetData WandUpData = new SpriteSheetData("Wand_Up", itemWidth, itemHeight, 1, 1);

        private Texture2D greenMagicDownTexture;
        private SpriteSheetData greenMagicDownData = new SpriteSheetData("Green_Magic_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D greenMagicLeftTexture;
        private SpriteSheetData greenMagicLeftData = new SpriteSheetData("Green_Magic_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D greenMagicRightTexture;
        private SpriteSheetData greenMagicRightData = new SpriteSheetData("Green_Magic_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D greenMagicUpTexture;
        private SpriteSheetData greenMagicUpData = new SpriteSheetData("Green_Magic_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D blueMagicDownTexture;
        private SpriteSheetData blueMagicDownData = new SpriteSheetData("Blue_Magic_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D blueMagicLeftTexture;
        private SpriteSheetData blueMagicLeftData = new SpriteSheetData("Blue_Magic_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D blueMagicRightTexture;
        private SpriteSheetData blueMagicRightData = new SpriteSheetData("Blue_Magic_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D blueMagicUpTexture;
        private SpriteSheetData blueMagicUpData = new SpriteSheetData("Blue_Magic_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D redMagicDownTexture;
        private SpriteSheetData redMagicDownData = new SpriteSheetData("Red_Magic_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D redMagicLeftTexture;
        private SpriteSheetData redMagicLeftData = new SpriteSheetData("Red_Magic_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D redMagicRightTexture;
        private SpriteSheetData redMagicRightData = new SpriteSheetData("Red_Magic_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D redMagicUpTexture;
        private SpriteSheetData redMagicUpData = new SpriteSheetData("Red_Magic_Up", itemWidth, itemHeight, 1, 2);




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

            // Load Attack Items

            greenWoodDownTexture = content.Load<Texture2D>(greenWoodDownData.FilePath);
            greenWoodLeftTexture = content.Load<Texture2D>(greenWoodLeftData.FilePath);
            greenWoodRightTexture = content.Load<Texture2D>(greenWoodRightData.FilePath);
            greenWoodUpTexture = content.Load<Texture2D>(greenWoodUpData.FilePath);

            blueWoodDownTexture = content.Load<Texture2D>(blueWoodDownData.FilePath);
            blueWoodLeftTexture = content.Load<Texture2D>(blueWoodLeftData.FilePath);
            blueWoodRightTexture = content.Load<Texture2D>(blueWoodRightData.FilePath);
            blueWoodUpTexture = content.Load<Texture2D>(blueWoodUpData.FilePath);

            redWoodDownTexture = content.Load<Texture2D>(redWoodDownData.FilePath);
            redWoodLeftTexture = content.Load<Texture2D>(redWoodLeftData.FilePath);
            redWoodRightTexture = content.Load<Texture2D>(redWoodRightData.FilePath);
            redWoodUpTexture = content.Load<Texture2D>(redWoodUpData.FilePath);

            WandDownTexture = content.Load<Texture2D>(WandDownData.FilePath);
            WandLeftTexture = content.Load<Texture2D>(WandLeftData.FilePath);
            WandRightTexture = content.Load<Texture2D>(WandRightData.FilePath);
            WandUpTexture = content.Load<Texture2D>(WandUpData.FilePath);

            greenMagicDownTexture = content.Load<Texture2D>(greenMagicDownData.FilePath);
            greenMagicLeftTexture = content.Load<Texture2D>(greenMagicLeftData.FilePath);
            greenMagicRightTexture = content.Load<Texture2D>(greenMagicRightData.FilePath);
            greenMagicUpTexture = content.Load<Texture2D>(greenMagicUpData.FilePath);

            blueMagicDownTexture = content.Load<Texture2D>(blueMagicDownData.FilePath);
            blueMagicLeftTexture = content.Load<Texture2D>(blueMagicLeftData.FilePath);
            blueMagicRightTexture = content.Load<Texture2D>(blueMagicRightData.FilePath);
            blueMagicUpTexture = content.Load<Texture2D>(blueMagicUpData.FilePath);

            redMagicDownTexture = content.Load<Texture2D>(redMagicDownData.FilePath);
            redMagicLeftTexture = content.Load<Texture2D>(redMagicLeftData.FilePath);
            redMagicRightTexture = content.Load<Texture2D>(redMagicRightData.FilePath);
            redMagicUpTexture = content.Load<Texture2D>(redMagicUpData.FilePath);


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
        public LinkAttackUpSprite createSpriteLinkAttackUp(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackUpSprite(redLinkUpTexture, redLinkUpData, redWoodUpTexture, redWoodUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackUpSprite(redLinkUpTexture, redLinkUpData, redMagicUpTexture, redMagicUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackUpSprite(redLinkUpTexture, redLinkUpData, WandDownTexture, WandDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackUpSprite(blueLinkUpTexture, blueLinkUpData, blueWoodUpTexture, blueWoodUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackUpSprite(blueLinkUpTexture, blueLinkUpData, blueMagicUpTexture, blueMagicUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackUpSprite(blueLinkUpTexture, blueLinkUpData, WandUpTexture, WandUpData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackUpSprite(greenLinkUpTexture, greenLinkUpData, greenWoodUpTexture, greenWoodUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackUpSprite(greenLinkUpTexture, greenLinkUpData, greenMagicUpTexture, greenMagicUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackUpSprite(greenLinkUpTexture, greenLinkUpData, WandUpTexture, WandUpData);
                }

            }
        }
        public LinkAttackDownSprite createSpriteLinkAttackDown(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackDownSprite(redLinkDownTexture, redLinkDownData, redWoodDownTexture, redWoodDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackDownSprite(redLinkDownTexture, redLinkDownData, redMagicDownTexture, redMagicDownData);
                } else // currentWeapon is "Wand"
                {
                    return new LinkAttackDownSprite(redLinkDownTexture, redLinkDownData, WandDownTexture, WandDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackDownSprite(blueLinkDownTexture, blueLinkDownData, blueWoodDownTexture, blueWoodDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackDownSprite(blueLinkDownTexture, blueLinkDownData, blueMagicDownTexture, blueMagicDownData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackDownSprite(blueLinkDownTexture, blueLinkDownData, WandDownTexture, WandDownData);
                }
                
            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackDownSprite(greenLinkDownTexture, greenLinkDownData, greenWoodDownTexture, greenWoodDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackDownSprite(greenLinkDownTexture, greenLinkDownData, greenMagicDownTexture, greenMagicDownData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackDownSprite(greenLinkDownTexture, greenLinkDownData, WandDownTexture, WandDownData);
                }
                
            }
        }
        public LinkAttackLeftSprite createSpriteLinkAttackLeft(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackLeftSprite(redLinkLeftTexture, redLinkLeftData, redWoodLeftTexture, redWoodLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackLeftSprite(redLinkLeftTexture, redLinkLeftData, redMagicLeftTexture, redMagicLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackLeftSprite(redLinkLeftTexture, redLinkLeftData, WandDownTexture, WandDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackLeftSprite(blueLinkLeftTexture, blueLinkLeftData, blueWoodLeftTexture, blueWoodLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackLeftSprite(blueLinkLeftTexture, blueLinkLeftData, blueMagicLeftTexture, blueMagicLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackLeftSprite(blueLinkLeftTexture, blueLinkLeftData, WandLeftTexture, WandLeftData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackLeftSprite(greenLinkLeftTexture, greenLinkLeftData, greenWoodLeftTexture, greenWoodLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackLeftSprite(greenLinkLeftTexture, greenLinkLeftData, greenMagicLeftTexture, greenMagicLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackLeftSprite(greenLinkLeftTexture, greenLinkLeftData, WandLeftTexture, WandLeftData);
                }

            }
        }
        public LinkAttackRightSprite createSpriteLinkAttackRight(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackRightSprite(redLinkRightTexture, redLinkRightData, redWoodRightTexture, redWoodRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackRightSprite(redLinkRightTexture, redLinkRightData, redMagicRightTexture, redMagicRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackRightSprite(redLinkRightTexture, redLinkRightData, WandDownTexture, WandDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackRightSprite(blueLinkRightTexture, blueLinkRightData, blueWoodRightTexture, blueWoodRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackRightSprite(blueLinkRightTexture, blueLinkRightData, blueMagicRightTexture, blueMagicRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackRightSprite(blueLinkRightTexture, blueLinkRightData, WandRightTexture, WandRightData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackRightSprite(greenLinkRightTexture, greenLinkRightData, greenWoodRightTexture, greenWoodRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackRightSprite(greenLinkRightTexture, greenLinkRightData, greenMagicRightTexture, greenMagicRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackRightSprite(greenLinkRightTexture, greenLinkRightData, WandRightTexture, WandRightData);
                }

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