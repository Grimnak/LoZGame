using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class EnemySpriteFactory
    {
        private Texture2D enemies;
        private Texture2D stalfos;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            enemies = content.Load<Texture2D>(enemies);
        }

        //Stalfos Sprites

        public StalfosSprite createSpriteDownMovingStalfos()
        {
            // Initial sprite direction is down
            return new StalfosSprite(enemies);
           
        }

        public StalfosSprite createSpriteUpMovingStalfos()
        {
            StalfosSprite sprite = new StalfosSprite(enemies);
            sprite.state = new UpMovingStalfosState(sprite);
            return sprite;
        }

        public StalfosSprite createSpriteLeftMovingStalfos()
        {
            StalfosSprite sprite = new StalfosSprite(enemies);
            sprite.state = new LeftMovingStalfosState(sprite);
            return sprite;
        }

        public StalfosSprite createSpriteRightMovingStalfos()
        {
            StalfosSprite sprite = new StalfosSprite(enemies);
            sprite.state = new RightMovingStalfosState(sprite);
            return sprite;
        }

        //Goriya Sprites

        public GoriyaSprite createSpriteDownMovingGoriya()
        {
            // Initial sprite direction is down
            return new GoriyaSprite(enemies);

        }

        public GoriyaSprite createSpriteUpMovingGoriya()
        {
            GoriyaSprite sprite = new GoriyaSprite(enemies);
            sprite.state = new UpMovingGoriyaState(sprite);
            return sprite;
        }

        public GoriyaSprite createSpriteLeftMovingGoriya()
        {
            GoriyaSprite sprite = new GoriyaSprite(enemies);
            sprite.state = new LeftMovingGoriyaState(sprite);
            return sprite;
        }

        public GoriyaSprite createSpriteRightMovingGoriya()
        {
            GoriyaSprite sprite = new GoriyaSprite(enemies);
            sprite.state = new RightMovingGoriyaState(sprite);
            return sprite;
        }

        //Wallmaster Sprites

        public WallMasterSprite createSpriteDownMovingWallMaster()
        {
            // Initial sprite direction is down
            return new WallMasterSprite(enemies);

        }

        public WallMasterSprite createSpriteUpMovingWallMaster()
        {
            WallMasterSprite sprite = new WallMasterSprite(enemies);
            sprite.state = new UpMovingWallMasterState(sprite);
            return sprite;
        }

        public WallMasterSprite createSpriteLeftMovingWallMaster()
        {
            WallMasterSprite sprite = new WallMasterSprite(enemies);
            sprite.state = new LeftMovingWallMasterState(sprite);
            return sprite;
        }

        public WallMasterSprite createSpriteRightMovingWallMaster()
        {
            WallMasterSprite sprite = new WallMasterSprite(enemies);
            sprite.state = new RightMovingWallMasterState(sprite);
            return sprite;
        }

        //Rope sprites
        public RopeSprite createSpriteDownMovingRope()
        {
            // Initial sprite direction is down
            return new RopeSprite(enemies);

        }

        public RopeSprite createSpriteUpMovingRope()
        {
            RopeSprite sprite = new RopeSprite(enemies);
            sprite.state = new UpMovingRopeState(sprite);
            return sprite;
        }

        public RopeSprite createSpriteLeftMovingRope()
        {
            RopeSprite sprite = new RopeSprite(enemies);
            sprite.state = new LeftMovingRopeState(sprite);
            return sprite;
        }

        public RopeSprite createSpriteRightMovingRope()
        {
            RopeSprite sprite = new RopeSprite(enemies);
            sprite.state = new RightMovingRopeState(sprite);
            return sprite;
        }

        //Gel Sprites
        public GelSprite createSpriteDownMovingGel()
        {
            // Initial sprite direction is down
            return new GelSprite(enemies);

        }

        public GelSprite createSpriteUpMovingGel()
        {
            GelSprite sprite = new GelSprite(enemies);
            sprite.state = new UpMovingGelState(sprite);
            return sprite;
        }

        public GelSprite createSpriteLeftMovingGel()
        {
            GelSprite sprite = new GelSprite(enemies);
            sprite.state = new LeftMovingGelState(sprite);
            return sprite;
        }

        public GelSprite createSpriteRightMovingGel()
        {
            GelSprite sprite = new GelSprite(enemies);
            sprite.state = new RightMovingGelState(sprite);
            return sprite;
        }

        // Zol Sprites
        public ZolSprite createSpriteDownMovingZol()
        {
            // Initial sprite direction is down
            return new ZolSprite(enemies);

        }

        public ZolSprite createSpriteUpMovingZol()
        {
            ZolSprite sprite = new ZolSprite(enemies);
            sprite.state = new UpMovingZolState(sprite);
            return sprite;
        }

        public ZolSprite createSpriteLeftMovingZol()
        {
            ZolSprite sprite = new ZolSprite(enemies);
            sprite.state = new LeftMovingZolState(sprite);
            return sprite;
        }

        public ZolSprite createSpriteRightMovingZol()
        {
            ZolSprite sprite = new ZolSprite(enemies);
            sprite.state = new RightMovingZolState(sprite);
            return sprite;
        }

        //SpikeCrossSprite
        public SpikeCrossSprite createSpriteDownMovingSpikeCross()
        {
            // Initial sprite direction is down
            return new SpikeCrossSprite(enemies);

        }

        public SpikeCrossSprite createSpriteUpMovingSpikeCross()
        {
            SpikeCrossSprite sprite = new SpikeCrossSprite(enemies);
            sprite.state = new UpMovingSpikeCrossState(sprite);
            return sprite;
        }

        public SpikeCrossSprite createSpriteLeftMovingSpikeCross()
        {
            SpikeCrossSprite sprite = new SpikeCrossSprite(enemies);
            sprite.state = new LeftMovingSpikeCrossState(sprite);
            return sprite;
        }

        public SpikeCrossSprite createSpriteRightMovingSpikeCross()
        {
            SpikeCrossSprite sprite = new SpikeCrossSprite(enemies);
            sprite.state = new RightMovingSpikeCrossState(sprite);
            return sprite;
        }

        //Keese Sprites
        public KeeseSprite createSpriteDownMovingKeese()
        {
            // Initial sprite direction is down
            return new KeeseSprite(enemies);

        }

        public KeeseSprite createSpriteUpMovingKeese()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new UpMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createSpriteLeftMovingKeese()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new LeftMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createSpriteRightMovingKeese()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new RightMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createSpriteUpLeftMovingKeese()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new UpLeftMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createSpriteUpRightMovingKeese()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new UpRightMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createSpriteDownLeftMovingKeese()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new DownLeftMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createSpriteDownRightMovingKeese()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new DownRightMovingKeeseState(sprite);
            return sprite;
        }

        //Dragon Sprites
        public DragonSprite createSpriteLeftMovingDragon()
        {
            DragonSprite sprite = new DragonSprite(enemies);
            sprite.state = new LeftMovingDragonState(sprite);
            return sprite;
        }

        public DragonSprite createSpriteRightMovingDragon()
        {
            DragonSprite sprite = new DragonSprite(enemies);
            sprite.state = new RightMovingDragonState(sprite);
            return sprite;
        }

        //DodongoSprites
        public DodongoSprite createSpriteDownMovingDodongo()
        {
            // Initial sprite direction is down
            return new DodongoSprite(enemies);

        }

        public DodongoSprite createSpriteUpMovingDodongo()
        {
            DodongoSprite sprite = new DodongoSprite(enemies);
            sprite.state = new UpMovingDodongoState(sprite);
            return sprite;
        }

        public DodongoSprite createSpriteLeftMovingDodongo()
        {
            DodongoSprite sprite = new DodongoSprite(enemies);
            sprite.state = new LeftMovingDodongoState(sprite);
            return sprite;
        }

        public DodongoSprite createSpriteRightMovingDodongo()
        {
            DodongoSprite sprite = new DodongoSprite(enemies);
            sprite.state = new RightMovingDodongoState(sprite);
            return sprite;
        }

        //Old Man Sprite
        public OldManSprite createSpriteOldMan()
        {
            return new OldManSprite(enemies); 
        }

        //Merchant Sprite
        public MerchantSprite createSpriteMerchant()
        {
            return new MerchantSprite(enemies);
        }
    }
}
