namespace LoZClone
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class LinkSpriteFactory
    {
        private static readonly int linkWidth = 40;
        private static readonly int linkHeight = 40;

        public static int LinkWidth
        {
            get { return linkWidth; }
        }

        public static int LinkHeight
        {
            get { return linkHeight; }
        }

        private static readonly int itemWidth = 40; // items Link holds in his hand during attack
        private static readonly int itemHeight = 40;

        public static int ItemWidth
        {
            get { return itemWidth; }
        }

        public static int ItemHeight
        {
            get { return itemHeight; }
        }

        private Texture2D greenLinkUpTexture;
        private readonly SpriteSheetData greenLinkUpData = new SpriteSheetData("Green_Link_Up", linkWidth, linkHeight, 3, 1);
        private Texture2D blueLinkUpTexture;
        private readonly SpriteSheetData blueLinkUpData = new SpriteSheetData("Blue_Link_Up", linkWidth, linkHeight, 3, 1);
        private Texture2D redLinkUpTexture;
        private readonly SpriteSheetData redLinkUpData = new SpriteSheetData("Red_Link_Up", linkWidth, linkHeight, 3, 1);

        private Texture2D greenLinkDownTexture;
        private readonly SpriteSheetData greenLinkDownData = new SpriteSheetData("Green_Link_Down", linkWidth, linkHeight, 3, 1);
        private Texture2D blueLinkDownTexture;
        private readonly SpriteSheetData blueLinkDownData = new SpriteSheetData("Blue_Link_Down", linkWidth, linkHeight, 3, 1);
        private Texture2D redLinkDownTexture;
        private readonly SpriteSheetData redLinkDownData = new SpriteSheetData("Red_Link_Down", linkWidth, linkHeight, 3, 1);

        private Texture2D greenLinkLeftTexture;
        private readonly SpriteSheetData greenLinkLeftData = new SpriteSheetData("Green_Link_Left", linkWidth, linkHeight, 3, 1);
        private Texture2D blueLinkLeftTexture;
        private readonly SpriteSheetData blueLinkLeftData = new SpriteSheetData("Blue_Link_Left", linkWidth, linkHeight, 3, 1);
        private Texture2D redLinkLeftTexture;
        private readonly SpriteSheetData redLinkLeftData = new SpriteSheetData("Red_Link_Left", linkWidth, linkHeight, 3, 1);

        private Texture2D greenLinkRightTexture;
        private readonly SpriteSheetData greenLinkRightData = new SpriteSheetData("Green_Link_Right", linkWidth, linkHeight, 3, 1);
        private Texture2D blueLinkRightTexture;
        private readonly SpriteSheetData blueLinkRightData = new SpriteSheetData("Blue_Link_Right", linkWidth, linkHeight, 3, 1);
        private Texture2D redLinkRightTexture;
        private readonly SpriteSheetData redLinkRightData = new SpriteSheetData("Red_Link_Right", linkWidth, linkHeight, 3, 1);

        private Texture2D greenLinkDieTexture;
        private readonly SpriteSheetData greenLinkDieData = new SpriteSheetData("Green_Link_Die", linkWidth, linkHeight, 1, 17);
        private Texture2D blueLinkDieTexture;
        private readonly SpriteSheetData blueLinkDieData = new SpriteSheetData("Blue_Link_Die", linkWidth, linkHeight, 1, 17);
        private Texture2D redLinkDieTexture;
        private readonly SpriteSheetData redLinkDieData = new SpriteSheetData("Red_Link_Die", linkWidth, linkHeight, 1, 17);

        private Texture2D greenLinkPickupTexture;
        private readonly SpriteSheetData greenLinkPickupData = new SpriteSheetData("Green_Link_Pickup", linkWidth, linkHeight, 2, 1);
        private Texture2D blueLinkPickupTexture;
        private readonly SpriteSheetData blueLinkPickupData = new SpriteSheetData("Blue_Link_Pickup", linkWidth, linkHeight, 2, 1);
        private Texture2D redLinkPickupTexture;
        private readonly SpriteSheetData redLinkPickupData = new SpriteSheetData("Red_Link_Pickup", linkWidth, linkHeight, 2, 1);

        // items Link holds in his hand during attack
        private Texture2D greenWoodDownTexture;
        private readonly SpriteSheetData greenWoodDownData = new SpriteSheetData("Green_Wood_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D greenWoodLeftTexture;
        private readonly SpriteSheetData greenWoodLeftData = new SpriteSheetData("Green_Wood_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D greenWoodRightTexture;
        private readonly SpriteSheetData greenWoodRightData = new SpriteSheetData("Green_Wood_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D greenWoodUpTexture;
        private readonly SpriteSheetData greenWoodUpData = new SpriteSheetData("Green_Wood_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D blueWoodDownTexture;
        private readonly SpriteSheetData blueWoodDownData = new SpriteSheetData("Blue_Wood_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D blueWoodLeftTexture;
        private readonly SpriteSheetData blueWoodLeftData = new SpriteSheetData("Blue_Wood_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D blueWoodRightTexture;
        private readonly SpriteSheetData blueWoodRightData = new SpriteSheetData("Blue_Wood_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D blueWoodUpTexture;
        private readonly SpriteSheetData blueWoodUpData = new SpriteSheetData("Blue_Wood_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D redWoodDownTexture;
        private readonly SpriteSheetData redWoodDownData = new SpriteSheetData("Red_Wood_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D redWoodLeftTexture;
        private readonly SpriteSheetData redWoodLeftData = new SpriteSheetData("Red_Wood_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D redWoodRightTexture;
        private readonly SpriteSheetData redWoodRightData = new SpriteSheetData("Red_Wood_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D redWoodUpTexture;
        private readonly SpriteSheetData redWoodUpData = new SpriteSheetData("Red_Wood_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D wandDownTexture;
        private readonly SpriteSheetData wandDownData = new SpriteSheetData("Wand_Down", itemWidth, itemHeight, 1, 1);
        private Texture2D wandLeftTexture;
        private readonly SpriteSheetData wandLeftData = new SpriteSheetData("Wand_Left", itemWidth, itemHeight, 1, 1);
        private Texture2D wandRightTexture;
        private readonly SpriteSheetData wandRightData = new SpriteSheetData("Wand_Right", itemWidth, itemHeight, 1, 1);
        private Texture2D wandUpTexture;
        private readonly SpriteSheetData wandUpData = new SpriteSheetData("Wand_Up", itemWidth, itemHeight, 1, 1);

        private Texture2D greenMagicDownTexture;
        private readonly SpriteSheetData greenMagicDownData = new SpriteSheetData("Green_Magic_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D greenMagicLeftTexture;
        private readonly SpriteSheetData greenMagicLeftData = new SpriteSheetData("Green_Magic_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D greenMagicRightTexture;
        private readonly SpriteSheetData greenMagicRightData = new SpriteSheetData("Green_Magic_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D greenMagicUpTexture;
        private readonly SpriteSheetData greenMagicUpData = new SpriteSheetData("Green_Magic_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D blueMagicDownTexture;
        private readonly SpriteSheetData blueMagicDownData = new SpriteSheetData("Blue_Magic_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D blueMagicLeftTexture;
        private readonly SpriteSheetData blueMagicLeftData = new SpriteSheetData("Blue_Magic_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D blueMagicRightTexture;
        private readonly SpriteSheetData blueMagicRightData = new SpriteSheetData("Blue_Magic_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D blueMagicUpTexture;
        private readonly SpriteSheetData blueMagicUpData = new SpriteSheetData("Blue_Magic_Up", itemWidth, itemHeight, 1, 2);

        private Texture2D redMagicDownTexture;
        private readonly SpriteSheetData redMagicDownData = new SpriteSheetData("Red_Magic_Down", itemWidth, itemHeight, 1, 2);
        private Texture2D redMagicLeftTexture;
        private readonly SpriteSheetData redMagicLeftData = new SpriteSheetData("Red_Magic_Left", itemWidth, itemHeight, 1, 2);
        private Texture2D redMagicRightTexture;
        private readonly SpriteSheetData redMagicRightData = new SpriteSheetData("Red_Magic_Right", itemWidth, itemHeight, 1, 2);
        private Texture2D redMagicUpTexture;
        private readonly SpriteSheetData redMagicUpData = new SpriteSheetData("Red_Magic_Up", itemWidth, itemHeight, 1, 2);

        private static readonly LinkSpriteFactory InstanceValue = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance => InstanceValue;

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.greenLinkUpTexture = content.Load<Texture2D>(this.greenLinkUpData.FilePath);
            this.blueLinkUpTexture = content.Load<Texture2D>(this.blueLinkUpData.FilePath);
            this.redLinkUpTexture = content.Load<Texture2D>(this.redLinkUpData.FilePath);

            this.greenLinkDownTexture = content.Load<Texture2D>(this.greenLinkDownData.FilePath);
            this.blueLinkDownTexture = content.Load<Texture2D>(this.blueLinkDownData.FilePath);
            this.redLinkDownTexture = content.Load<Texture2D>(this.redLinkDownData.FilePath);

            this.greenLinkLeftTexture = content.Load<Texture2D>(this.greenLinkLeftData.FilePath);
            this.blueLinkLeftTexture = content.Load<Texture2D>(this.blueLinkLeftData.FilePath);
            this.redLinkLeftTexture = content.Load<Texture2D>(this.redLinkLeftData.FilePath);

            this.greenLinkRightTexture = content.Load<Texture2D>(this.greenLinkRightData.FilePath);
            this.blueLinkRightTexture = content.Load<Texture2D>(this.blueLinkRightData.FilePath);
            this.redLinkRightTexture = content.Load<Texture2D>(this.redLinkRightData.FilePath);

            this.greenLinkDieTexture = content.Load<Texture2D>(this.greenLinkDieData.FilePath);
            this.blueLinkDieTexture = content.Load<Texture2D>(this.blueLinkDieData.FilePath);
            this.redLinkDieTexture = content.Load<Texture2D>(this.redLinkDieData.FilePath);

            this.greenLinkPickupTexture = content.Load<Texture2D>(this.greenLinkPickupData.FilePath);
            this.blueLinkPickupTexture = content.Load<Texture2D>(this.blueLinkPickupData.FilePath);
            this.redLinkPickupTexture = content.Load<Texture2D>(this.redLinkPickupData.FilePath);

            // Load Attack Items
            this.greenWoodDownTexture = content.Load<Texture2D>(this.greenWoodDownData.FilePath);
            this.greenWoodLeftTexture = content.Load<Texture2D>(this.greenWoodLeftData.FilePath);
            this.greenWoodRightTexture = content.Load<Texture2D>(this.greenWoodRightData.FilePath);
            this.greenWoodUpTexture = content.Load<Texture2D>(this.greenWoodUpData.FilePath);

            this.blueWoodDownTexture = content.Load<Texture2D>(this.blueWoodDownData.FilePath);
            this.blueWoodLeftTexture = content.Load<Texture2D>(this.blueWoodLeftData.FilePath);
            this.blueWoodRightTexture = content.Load<Texture2D>(this.blueWoodRightData.FilePath);
            this.blueWoodUpTexture = content.Load<Texture2D>(this.blueWoodUpData.FilePath);

            this.redWoodDownTexture = content.Load<Texture2D>(this.redWoodDownData.FilePath);
            this.redWoodLeftTexture = content.Load<Texture2D>(this.redWoodLeftData.FilePath);
            this.redWoodRightTexture = content.Load<Texture2D>(this.redWoodRightData.FilePath);
            this.redWoodUpTexture = content.Load<Texture2D>(this.redWoodUpData.FilePath);

            this.wandDownTexture = content.Load<Texture2D>(this.wandDownData.FilePath);
            this.wandLeftTexture = content.Load<Texture2D>(this.wandLeftData.FilePath);
            this.wandRightTexture = content.Load<Texture2D>(this.wandRightData.FilePath);
            this.wandUpTexture = content.Load<Texture2D>(this.wandUpData.FilePath);

            this.greenMagicDownTexture = content.Load<Texture2D>(this.greenMagicDownData.FilePath);
            this.greenMagicLeftTexture = content.Load<Texture2D>(this.greenMagicLeftData.FilePath);
            this.greenMagicRightTexture = content.Load<Texture2D>(this.greenMagicRightData.FilePath);
            this.greenMagicUpTexture = content.Load<Texture2D>(this.greenMagicUpData.FilePath);

            this.blueMagicDownTexture = content.Load<Texture2D>(this.blueMagicDownData.FilePath);
            this.blueMagicLeftTexture = content.Load<Texture2D>(this.blueMagicLeftData.FilePath);
            this.blueMagicRightTexture = content.Load<Texture2D>(this.blueMagicRightData.FilePath);
            this.blueMagicUpTexture = content.Load<Texture2D>(this.blueMagicUpData.FilePath);

            this.redMagicDownTexture = content.Load<Texture2D>(this.redMagicDownData.FilePath);
            this.redMagicLeftTexture = content.Load<Texture2D>(this.redMagicLeftData.FilePath);
            this.redMagicRightTexture = content.Load<Texture2D>(this.redMagicRightData.FilePath);
            this.redMagicUpTexture = content.Load<Texture2D>(this.redMagicUpData.FilePath);

        }

        public LinkIdleUpSprite CreateSpriteLinkIdleUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkIdleUpSprite(this.redLinkUpTexture, this.redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkIdleUpSprite(this.blueLinkUpTexture, this.blueLinkUpData);
            }
            else
            {
                return new LinkIdleUpSprite(this.greenLinkUpTexture, this.greenLinkUpData);
            }
        }

        public LinkIdleDownSprite CreateSpriteLinkIdleDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkIdleDownSprite(this.redLinkDownTexture, this.redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkIdleDownSprite(this.blueLinkDownTexture, this.blueLinkDownData);
            }
            else
            {
                return new LinkIdleDownSprite(this.greenLinkDownTexture, this.greenLinkDownData);
            }
        }

        public LinkIdleLeftSprite CreateSpriteLinkIdleLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkIdleLeftSprite(this.redLinkLeftTexture, this.redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkIdleLeftSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
            }
            else
            {
                return new LinkIdleLeftSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
            }
        }

        public LinkIdleRightSprite CreateSpriteLinkIdleRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkIdleRightSprite(this.redLinkRightTexture, this.redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkIdleRightSprite(this.blueLinkRightTexture, this.blueLinkRightData);
            }
            else
            {
                return new LinkIdleRightSprite(this.greenLinkRightTexture, this.greenLinkRightData);
            }
        }

        public LinkMoveUpSprite CreateSpriteLinkMoveUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkMoveUpSprite(this.redLinkUpTexture, this.redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkMoveUpSprite(this.blueLinkUpTexture, this.blueLinkUpData);
            }
            else
            {
                return new LinkMoveUpSprite(this.greenLinkUpTexture, this.greenLinkUpData);
            }
        }

        public LinkMoveDownSprite CreateSpriteLinkMoveDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkMoveDownSprite(this.redLinkDownTexture, this.redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkMoveDownSprite(this.blueLinkDownTexture, this.blueLinkDownData);
            }
            else
            {
                return new LinkMoveDownSprite(this.greenLinkDownTexture, this.greenLinkDownData);
            }
        }

        public LinkMoveLeftSprite CreateSpriteLinkMoveLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkMoveLeftSprite(this.redLinkLeftTexture, this.redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkMoveLeftSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
            }
            else
            {
                return new LinkMoveLeftSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
            }
        }

        public LinkMoveRightSprite CreateSpriteLinkMoveRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkMoveRightSprite(this.redLinkRightTexture, this.redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkMoveRightSprite(this.blueLinkRightTexture, this.blueLinkRightData);
            }
            else
            {
                return new LinkMoveRightSprite(this.greenLinkRightTexture, this.greenLinkRightData);
            }
        }

        public LinkAttackUpSprite CreateSpriteLinkAttackUp(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackUpSprite(this.redLinkUpTexture, this.redLinkUpData, this.redWoodUpTexture, this.redWoodUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackUpSprite(this.redLinkUpTexture, this.redLinkUpData, this.redMagicUpTexture, this.redMagicUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackUpSprite(this.redLinkUpTexture, this.redLinkUpData, this.wandDownTexture, this.wandDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackUpSprite(this.blueLinkUpTexture, this.blueLinkUpData, this.blueWoodUpTexture, this.blueWoodUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackUpSprite(this.blueLinkUpTexture, this.blueLinkUpData, this.blueMagicUpTexture, this.blueMagicUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackUpSprite(this.blueLinkUpTexture, this.blueLinkUpData, this.wandUpTexture, this.wandUpData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackUpSprite(this.greenLinkUpTexture, this.greenLinkUpData, this.greenWoodUpTexture, this.greenWoodUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackUpSprite(this.greenLinkUpTexture, this.greenLinkUpData, this.greenMagicUpTexture, this.greenMagicUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackUpSprite(this.greenLinkUpTexture, this.greenLinkUpData, this.wandUpTexture, this.wandUpData);
                }

            }
        }

        public LinkAttackDownSprite CreateSpriteLinkAttackDown(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackDownSprite(this.redLinkDownTexture, this.redLinkDownData, this.redWoodDownTexture, this.redWoodDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackDownSprite(this.redLinkDownTexture, this.redLinkDownData, this.redMagicDownTexture, this.redMagicDownData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackDownSprite(this.redLinkDownTexture, this.redLinkDownData, this.wandDownTexture, this.wandDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackDownSprite(this.blueLinkDownTexture, this.blueLinkDownData, this.blueWoodDownTexture, this.blueWoodDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackDownSprite(this.blueLinkDownTexture, this.blueLinkDownData, this.blueMagicDownTexture, this.blueMagicDownData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackDownSprite(this.blueLinkDownTexture, this.blueLinkDownData, this.wandDownTexture, this.wandDownData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackDownSprite(this.greenLinkDownTexture, this.greenLinkDownData, this.greenWoodDownTexture, this.greenWoodDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackDownSprite(this.greenLinkDownTexture, this.greenLinkDownData, this.greenMagicDownTexture, this.greenMagicDownData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackDownSprite(this.greenLinkDownTexture, this.greenLinkDownData, this.wandDownTexture, this.wandDownData);
                }

            }
        }

        public LinkAttackLeftSprite CreateSpriteLinkAttackLeft(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackLeftSprite(this.redLinkLeftTexture, this.redLinkLeftData, this.redWoodLeftTexture, this.redWoodLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackLeftSprite(this.redLinkLeftTexture, this.redLinkLeftData, this.redMagicLeftTexture, this.redMagicLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackLeftSprite(this.redLinkLeftTexture, this.redLinkLeftData, this.wandDownTexture, this.wandDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackLeftSprite(this.blueLinkLeftTexture, this.blueLinkLeftData, this.blueWoodLeftTexture, this.blueWoodLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackLeftSprite(this.blueLinkLeftTexture, this.blueLinkLeftData, this.blueMagicLeftTexture, this.blueMagicLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackLeftSprite(this.blueLinkLeftTexture, this.blueLinkLeftData, this.wandLeftTexture, this.wandLeftData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackLeftSprite(this.greenLinkLeftTexture, this.greenLinkLeftData, this.greenWoodLeftTexture, this.greenWoodLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackLeftSprite(this.greenLinkLeftTexture, this.greenLinkLeftData, this.greenMagicLeftTexture, this.greenMagicLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackLeftSprite(this.greenLinkLeftTexture, this.greenLinkLeftData, this.wandLeftTexture, this.wandLeftData);
                }

            }
        }

        public LinkAttackRightSprite CreateSpriteLinkAttackRight(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackRightSprite(this.redLinkRightTexture, this.redLinkRightData, this.redWoodRightTexture, this.redWoodRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackRightSprite(this.redLinkRightTexture, this.redLinkRightData, this.redMagicRightTexture, this.redMagicRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackRightSprite(this.redLinkRightTexture, this.redLinkRightData, this.wandDownTexture, this.wandDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackRightSprite(this.blueLinkRightTexture, this.blueLinkRightData, this.blueWoodRightTexture, this.blueWoodRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackRightSprite(this.blueLinkRightTexture, this.blueLinkRightData, this.blueMagicRightTexture, this.blueMagicRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackRightSprite(this.blueLinkRightTexture, this.blueLinkRightData, this.wandRightTexture, this.wandRightData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new LinkAttackRightSprite(this.greenLinkRightTexture, this.greenLinkRightData, this.greenWoodRightTexture, this.greenWoodRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new LinkAttackRightSprite(this.greenLinkRightTexture, this.greenLinkRightData, this.greenMagicRightTexture, this.greenMagicRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new LinkAttackRightSprite(this.greenLinkRightTexture, this.greenLinkRightData, this.wandRightTexture, this.wandRightData);
                }

            }
        }

        public LinkPickupItemSprite CreateSpriteLinkPickupItem(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkPickupItemSprite(this.redLinkPickupTexture, this.redLinkPickupData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkPickupItemSprite(this.blueLinkPickupTexture, this.blueLinkPickupData);
            }
            else
            {
                return new LinkPickupItemSprite(this.greenLinkPickupTexture, this.greenLinkPickupData);
            }
        }

        public LinkPickupTriforceSprite CreateSpriteLinkPickupTriforce(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkPickupTriforceSprite(this.redLinkPickupTexture, this.redLinkPickupData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkPickupTriforceSprite(this.blueLinkPickupTexture, this.blueLinkPickupData);
            }
            else
            {
                return new LinkPickupTriforceSprite(this.greenLinkPickupTexture, this.greenLinkPickupData);
            }
        }

        public LinkUseItemUpSprite CreateSpriteLinkUseItemUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkUseItemUpSprite(this.redLinkUpTexture, this.redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkUseItemUpSprite(this.blueLinkUpTexture, this.blueLinkUpData);
            }
            else
            {
                return new LinkUseItemUpSprite(this.greenLinkUpTexture, this.greenLinkUpData);
            }
        }

        public LinkUseItemDownSprite CreateSpriteLinkUseItemDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkUseItemDownSprite(this.redLinkDownTexture, this.redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkUseItemDownSprite(this.blueLinkDownTexture, this.blueLinkDownData);
            }
            else
            {
                return new LinkUseItemDownSprite(this.greenLinkDownTexture, this.greenLinkDownData);
            }
        }

        public LinkUseItemLeftSprite CreateSpriteLinkUseItemLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkUseItemLeftSprite(this.redLinkLeftTexture, this.redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkUseItemLeftSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
            }
            else
            {
                return new LinkUseItemLeftSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
            }
        }

        public LinkUseItemRightSprite CreateSpriteLinkUseItemRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkUseItemRightSprite(this.redLinkRightTexture, this.redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkUseItemRightSprite(this.blueLinkRightTexture, this.blueLinkRightData);
            }
            else
            {
                return new LinkUseItemRightSprite(this.greenLinkRightTexture, this.greenLinkRightData);
            }
        }

        public LinkDieSprite CreateSpriteLinkDie(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new LinkDieSprite(this.redLinkDieTexture, this.redLinkDieData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new LinkDieSprite(this.blueLinkDieTexture, this.blueLinkDieData);
            }
            else
            {
                return new LinkDieSprite(this.greenLinkDieTexture, this.greenLinkDieData);
            }
        }
    }
}