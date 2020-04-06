namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class LinkSpriteFactory
    {
        private static readonly Vector2 DrawSize = new Vector2(40, 40);

        public static int LinkWidth
        {
            get { return (int)DrawSize.X; }
        }

        public static int LinkHeight
        {
            get { return (int)DrawSize.Y; }
        }

        private SpriteData greenLinkUpData;
        private SpriteData blueLinkUpData;
        private SpriteData redLinkUpData;
        private SpriteData greenLinkDownData;
        private SpriteData blueLinkDownData;
        private SpriteData redLinkDownData;
        private SpriteData greenLinkLeftData;
        private SpriteData blueLinkLeftData;
        private SpriteData redLinkLeftData;
        private SpriteData greenLinkRightData;
        private SpriteData blueLinkRightData;
        private SpriteData redLinkRightData;
        private SpriteData greenLinkDieData;
        private SpriteData blueLinkDieData;
        private SpriteData redLinkDieData;
        private SpriteData greenLinkPickupData;
        private SpriteData blueLinkPickupData;
        private SpriteData redLinkPickupData;

        private Texture2D greenLinkUpTexture;
        private Texture2D blueLinkUpTexture;
        private Texture2D redLinkUpTexture;

        private Texture2D greenLinkDownTexture;
        private Texture2D blueLinkDownTexture;
        private Texture2D redLinkDownTexture;

        private Texture2D greenLinkLeftTexture;
        private Texture2D blueLinkLeftTexture;
        private Texture2D redLinkLeftTexture;

        private Texture2D greenLinkRightTexture;
        private Texture2D blueLinkRightTexture;
        private Texture2D redLinkRightTexture;

        private Texture2D greenLinkDieTexture;
        private Texture2D blueLinkDieTexture;
        private Texture2D redLinkDieTexture;

        private Texture2D greenLinkPickupTexture;
        private Texture2D blueLinkPickupTexture;
        private Texture2D redLinkPickupTexture;

        private static readonly LinkSpriteFactory InstanceValue = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance => InstanceValue;

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.LoadTextures(content);
            this.LoadData();
        }

        public void LoadTextures(ContentManager content)
        {
            this.greenLinkUpTexture = content.Load<Texture2D>("Green_Link_Up");
            this.blueLinkUpTexture = content.Load<Texture2D>("Blue_Link_Up");
            this.redLinkUpTexture = content.Load<Texture2D>("Red_Link_Up");

            this.greenLinkDownTexture = content.Load<Texture2D>("Green_Link_Down");
            this.blueLinkDownTexture = content.Load<Texture2D>("Blue_Link_Down");
            this.redLinkDownTexture = content.Load<Texture2D>("Red_Link_Down");

            this.greenLinkLeftTexture = content.Load<Texture2D>("Green_Link_Left");
            this.blueLinkLeftTexture = content.Load<Texture2D>("Blue_Link_Left");
            this.redLinkLeftTexture = content.Load<Texture2D>("Red_Link_Left");

            this.greenLinkRightTexture = content.Load<Texture2D>("Green_Link_Right");
            this.blueLinkRightTexture = content.Load<Texture2D>("Blue_Link_Right");
            this.redLinkRightTexture = content.Load<Texture2D>("Red_Link_Right");

            this.greenLinkDieTexture = content.Load<Texture2D>("Green_Link_Die");
            this.blueLinkDieTexture = content.Load<Texture2D>("Blue_Link_Die");
            this.redLinkDieTexture = content.Load<Texture2D>("Red_Link_Die");

            this.greenLinkPickupTexture = content.Load<Texture2D>("Green_Link_Pickup");
            this.blueLinkPickupTexture = content.Load<Texture2D>("Blue_Link_Pickup");
            this.redLinkPickupTexture = content.Load<Texture2D>("Red_Link_Pickup");
        }

        public void LoadData()
        {
            this.greenLinkUpData = new SpriteData(DrawSize, greenLinkUpTexture, 3, 1);
            this.blueLinkUpData = new SpriteData(DrawSize, blueLinkUpTexture, 3, 1);
            this.redLinkUpData = new SpriteData(DrawSize, redLinkUpTexture, 3, 1);
            this.greenLinkDownData = new SpriteData(DrawSize, greenLinkDownTexture, 3, 1);
            this.blueLinkDownData = new SpriteData(DrawSize, blueLinkDownTexture, 3, 1);
            this.redLinkDownData = new SpriteData(DrawSize, redLinkDownTexture, 3, 1);
            this.greenLinkLeftData = new SpriteData(DrawSize, greenLinkLeftTexture, 3, 1);
            this.blueLinkLeftData = new SpriteData(DrawSize, blueLinkLeftTexture, 3, 1);
            this.redLinkLeftData = new SpriteData(DrawSize, redLinkLeftTexture, 3, 1);
            this.greenLinkRightData = new SpriteData(DrawSize, greenLinkLeftTexture, 3, 1);
            this.blueLinkRightData = new SpriteData(DrawSize, blueLinkRightTexture, 3, 1);
            this.redLinkRightData = new SpriteData(DrawSize, redLinkLeftTexture, 3, 1);
            this.greenLinkDieData = new SpriteData(DrawSize, greenLinkDieTexture, 1, 17);
            this.blueLinkDieData = new SpriteData(DrawSize, blueLinkDieTexture, 1, 17);
            this.redLinkDieData = new SpriteData(DrawSize, redLinkDieTexture, 1, 17);
            this.greenLinkPickupData = new SpriteData(DrawSize, greenLinkPickupTexture, 2, 1);
            this.blueLinkPickupData = new SpriteData(DrawSize, blueLinkPickupTexture, 2, 1);
            this.redLinkPickupData = new SpriteData(DrawSize, redLinkPickupTexture, 2, 1);
        }

        public ISprite CreateSpriteLinkIdleUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkUpTexture, this.redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkUpTexture, this.blueLinkUpData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkUpTexture, this.greenLinkUpData);
            }
        }

        public ISprite CreateSpriteLinkIdleDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkDownTexture, this.redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkDownTexture, this.blueLinkDownData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkDownTexture, this.greenLinkDownData);
            }
        }

        public ISprite CreateSpriteLinkIdleLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkLeftTexture, this.redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
            }
        }

        public ISprite CreateSpriteLinkIdleRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkRightTexture, this.redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkRightTexture, this.blueLinkRightData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkRightTexture, this.greenLinkRightData);
            }
        }

        public ISprite CreateSpriteLinkMoveUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkUpTexture, this.redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkUpTexture, this.blueLinkUpData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkUpTexture, this.greenLinkUpData);
            }
        }

        public ISprite CreateSpriteLinkMoveDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkDownTexture, this.redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkDownTexture, this.blueLinkDownData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkDownTexture, this.greenLinkDownData);
            }
        }

        public ISprite CreateSpriteLinkMoveLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkLeftTexture, this.redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
            }
        }

        public ISprite CreateSpriteLinkMoveRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkRightTexture, this.redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkRightTexture, this.blueLinkRightData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkRightTexture, this.greenLinkRightData);
            }
        }

        public ISprite CreateSpriteLinkAttackUp(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.redLinkUpTexture, this.redLinkUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.redLinkUpTexture, this.redLinkUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.redLinkUpTexture, this.redLinkUpData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.blueLinkUpTexture, this.blueLinkUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.blueLinkUpTexture, this.blueLinkUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.blueLinkUpTexture, this.blueLinkUpData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.greenLinkUpTexture, this.greenLinkUpData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.greenLinkUpTexture, this.greenLinkUpData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.greenLinkUpTexture, this.greenLinkUpData);
                }

            }
        }

        public ISprite CreateSpriteLinkAttackDown(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.redLinkDownTexture, this.redLinkDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.redLinkDownTexture, this.redLinkDownData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.redLinkDownTexture, this.redLinkDownData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.blueLinkDownTexture, this.blueLinkDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.blueLinkDownTexture, this.blueLinkDownData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.blueLinkDownTexture, this.blueLinkDownData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.greenLinkDownTexture, this.greenLinkDownData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.greenLinkDownTexture, this.greenLinkDownData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.greenLinkDownTexture, this.greenLinkDownData);
                }

            }
        }

        public ISprite CreateSpriteLinkAttackLeft(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.redLinkLeftTexture, this.redLinkLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.redLinkLeftTexture, this.redLinkLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.redLinkLeftTexture, this.redLinkLeftData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
                }

            }
        }

        public ISprite CreateSpriteLinkAttackRight(string currentColor, string currentWeapon)
        {
            if (currentColor.Equals("Red"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.redLinkRightTexture, this.redLinkRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.redLinkRightTexture, this.redLinkRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.redLinkRightTexture, this.redLinkRightData);
                }
            }
            else if (currentColor.Equals("Blue"))
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.blueLinkRightTexture, this.blueLinkRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.blueLinkRightTexture, this.blueLinkRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.blueLinkRightTexture, this.blueLinkRightData);
                }

            }
            else
            {
                if (currentWeapon.Equals("Wood"))
                {
                    return new ObjectSprite(this.greenLinkRightTexture, this.greenLinkRightData);
                }
                else if (currentWeapon.Equals("Magic"))
                {
                    return new ObjectSprite(this.greenLinkRightTexture, this.greenLinkRightData);
                }
                else // currentWeapon is "Wand"
                {
                    return new ObjectSprite(this.greenLinkRightTexture, this.greenLinkRightData);
                }

            }
        }

        public ISprite CreateSpriteLinkPickupItem(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkPickupTexture, this.redLinkPickupData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkPickupTexture, this.blueLinkPickupData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkPickupTexture, this.greenLinkPickupData);
            }
        }

        public ISprite CreateSpriteLinkPickupTriforce(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkPickupTexture, this.redLinkPickupData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkPickupTexture, this.blueLinkPickupData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkPickupTexture, this.greenLinkPickupData);
            }
        }

        public ISprite CreateSpriteLinkUseItemUp(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkUpTexture, this.redLinkUpData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkUpTexture, this.blueLinkUpData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkUpTexture, this.greenLinkUpData);
            }
        }

        public ISprite CreateSpriteLinkUseItemDown(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkDownTexture, this.redLinkDownData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkDownTexture, this.blueLinkDownData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkDownTexture, this.greenLinkDownData);
            }
        }

        public ISprite CreateSpriteLinkUseItemLeft(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkLeftTexture, this.redLinkLeftData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkLeftTexture, this.blueLinkLeftData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkLeftTexture, this.greenLinkLeftData);
            }
        }

        public ISprite CreateSpriteLinkUseItemRight(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkRightTexture, this.redLinkRightData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkRightTexture, this.blueLinkRightData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkRightTexture, this.greenLinkRightData);
            }
        }

        public ISprite CreateSpriteLinkDie(string currentColor)
        {
            if (currentColor.Equals("Red"))
            {
                return new ObjectSprite(this.redLinkDieTexture, this.redLinkDieData);
            }
            else if (currentColor.Equals("Blue"))
            {
                return new ObjectSprite(this.blueLinkDieTexture, this.blueLinkDieData);
            }
            else
            {
                return new ObjectSprite(this.greenLinkDieTexture, this.greenLinkDieData);
            }
        }
    }
}