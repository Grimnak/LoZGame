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
            LoadTextures(content);
            LoadData();
        }

        public void LoadTextures(ContentManager content)
        {
            greenLinkUpTexture = content.Load<Texture2D>("Green_Link_Up");
            blueLinkUpTexture = content.Load<Texture2D>("Blue_Link_Up");
            redLinkUpTexture = content.Load<Texture2D>("Red_Link_Up");

            greenLinkDownTexture = content.Load<Texture2D>("Green_Link_Down");
            blueLinkDownTexture = content.Load<Texture2D>("Blue_Link_Down");
            redLinkDownTexture = content.Load<Texture2D>("Red_Link_Down");

            greenLinkLeftTexture = content.Load<Texture2D>("Green_Link_Left");
            blueLinkLeftTexture = content.Load<Texture2D>("Blue_Link_Left");
            redLinkLeftTexture = content.Load<Texture2D>("Red_Link_Left");

            greenLinkRightTexture = content.Load<Texture2D>("Green_Link_Right");
            blueLinkRightTexture = content.Load<Texture2D>("Blue_Link_Right");
            redLinkRightTexture = content.Load<Texture2D>("Red_Link_Right");

            greenLinkDieTexture = content.Load<Texture2D>("Green_Link_Die");
            blueLinkDieTexture = content.Load<Texture2D>("Blue_Link_Die");
            redLinkDieTexture = content.Load<Texture2D>("Red_Link_Die");

            greenLinkPickupTexture = content.Load<Texture2D>("Green_Link_Pickup");
            blueLinkPickupTexture = content.Load<Texture2D>("Blue_Link_Pickup");
            redLinkPickupTexture = content.Load<Texture2D>("Red_Link_Pickup");
        }

        public void LoadData()
        {
            greenLinkUpData = new SpriteData(DrawSize, greenLinkUpTexture, 3, 1);
            blueLinkUpData = new SpriteData(DrawSize, blueLinkUpTexture, 3, 1);
            redLinkUpData = new SpriteData(DrawSize, redLinkUpTexture, 3, 1);
            greenLinkDownData = new SpriteData(DrawSize, greenLinkDownTexture, 3, 1);
            blueLinkDownData = new SpriteData(DrawSize, blueLinkDownTexture, 3, 1);
            redLinkDownData = new SpriteData(DrawSize, redLinkDownTexture, 3, 1);
            greenLinkLeftData = new SpriteData(DrawSize, greenLinkLeftTexture, 3, 1);
            blueLinkLeftData = new SpriteData(DrawSize, blueLinkLeftTexture, 3, 1);
            redLinkLeftData = new SpriteData(DrawSize, redLinkLeftTexture, 3, 1);
            greenLinkRightData = new SpriteData(DrawSize, greenLinkLeftTexture, 3, 1);
            blueLinkRightData = new SpriteData(DrawSize, blueLinkRightTexture, 3, 1);
            redLinkRightData = new SpriteData(DrawSize, redLinkLeftTexture, 3, 1);
            greenLinkDieData = new SpriteData(DrawSize, greenLinkDieTexture, 1, 17);
            blueLinkDieData = new SpriteData(DrawSize, blueLinkDieTexture, 1, 17);
            redLinkDieData = new SpriteData(DrawSize, redLinkDieTexture, 1, 17);
            greenLinkPickupData = new SpriteData(DrawSize, greenLinkPickupTexture, 2, 1);
            blueLinkPickupData = new SpriteData(DrawSize, blueLinkPickupTexture, 2, 1);
            redLinkPickupData = new SpriteData(DrawSize, redLinkPickupTexture, 2, 1);
        }

        public ISprite CreateSpriteLinkUp(Link.LinkColor currentColor)
        {
            if (currentColor.Equals(Link.LinkColor.Red))
            {
                return new ObjectSprite(redLinkUpTexture, redLinkUpData);
            }
            else if (currentColor.Equals(Link.LinkColor.Blue))
            {
                return new ObjectSprite(blueLinkUpTexture, blueLinkUpData);
            }
            else
            {
                return new ObjectSprite(greenLinkUpTexture, greenLinkUpData);
            }
        }

        public ISprite CreateSpriteLinkDown(Link.LinkColor currentColor)
        {
            if (currentColor.Equals(Link.LinkColor.Red))
            {
                return new ObjectSprite(redLinkDownTexture, redLinkDownData);
            }
            else if (currentColor.Equals(Link.LinkColor.Blue))
            {
                return new ObjectSprite(blueLinkDownTexture, blueLinkDownData);
            }
            else
            {
                return new ObjectSprite(greenLinkDownTexture, greenLinkDownData);
            }
        }

        public ISprite CreateSpriteLinkLeft(Link.LinkColor currentColor)
        {
            if (currentColor.Equals(Link.LinkColor.Red))
            {
                return new ObjectSprite(redLinkLeftTexture, redLinkLeftData);
            }
            else if (currentColor.Equals(Link.LinkColor.Blue))
            {
                return new ObjectSprite(blueLinkLeftTexture, blueLinkLeftData);
            }
            else
            {
                return new ObjectSprite(greenLinkLeftTexture, greenLinkLeftData);
            }
        }

        public ISprite CreateSpriteLinkRight(Link.LinkColor currentColor)
        {
            if (currentColor.Equals(Link.LinkColor.Red))
            {
                return new ObjectSprite(redLinkRightTexture, redLinkRightData);
            }
            else if (currentColor.Equals(Link.LinkColor.Blue))
            {
                return new ObjectSprite(blueLinkRightTexture, blueLinkRightData);
            }
            else
            {
                return new ObjectSprite(greenLinkRightTexture, greenLinkRightData);
            }
        }

        public ISprite CreateSpriteLinkPickupItem(Link.LinkColor currentColor)
        {
            if (currentColor.Equals(Link.LinkColor.Red))
            {
                return new ObjectSprite(redLinkPickupTexture, redLinkPickupData);
            }
            else if (currentColor.Equals(Link.LinkColor.Blue))
            {
                return new ObjectSprite(blueLinkPickupTexture, blueLinkPickupData);
            }
            else
            {
                return new ObjectSprite(greenLinkPickupTexture, greenLinkPickupData);
            }
        }

        public ISprite CreateSpriteLinkDie(Link.LinkColor currentColor)
        {
            if (currentColor.Equals(Link.LinkColor.Red))
            {
                return new ObjectSprite(redLinkDieTexture, redLinkDieData);
            }
            else if (currentColor.Equals(Link.LinkColor.Blue))
            {
                return new ObjectSprite(blueLinkDieTexture, blueLinkDieData);
            }
            else
            {
                return new ObjectSprite(greenLinkDieTexture, greenLinkDieData);
            }
        }
    }
}