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

        public StalfosSprite createDownMovingStalfosSprite()
        {
            // Initial sprite direction is down
            return new StalfosSprite(enemies);
           
        }

        public StalfosSprite createUpMovingStalfosSprite()
        {
            StalfosSprite sprite = new StalfosSprite(enemies);
            sprite.state = new UpMovingStalfosState(sprite);
            return sprite;
        }

        public StalfosSprite createLeftMovingStalfosSprite()
        {
            StalfosSprite sprite = new StalfosSprite(enemies);
            sprite.state = new LeftMovingStalfosState(sprite);
            return sprite;
        }

        public StalfosSprite createRightMovingStalfosSprite()
        {
            StalfosSprite sprite = new StalfosSprite(enemies);
            sprite.state = new RightMovingStalfosState(sprite);
            return sprite;
        }

        //Goriya Sprites

        public GoriyaSprite createDownMovingGoriyaSprite()
        {
            // Initial sprite direction is down
            return new GoriyaSprite(enemies);

        }

        public GoriyaSprite createUpMovingGoriyaSprite()
        {
            GoriyaSprite sprite = new GoriyaSprite(enemies);
            sprite.state = new UpMovingGoriyaState(sprite);
            return sprite;
        }

        public GoriyaSprite createLeftMovingGoriyaSprite()
        {
            GoriyaSprite sprite = new GoriyaSprite(enemies);
            sprite.state = new LeftMovingGoriyaState(sprite);
            return sprite;
        }

        public GoriyaSprite createRightMovingGoriyaSprite()
        {
            GoriyaSprite sprite = new GoriyaSprite(enemies);
            sprite.state = new RightMovingGoriyaState(sprite);
            return sprite;
        }

        //Wallmaster Sprites

        public WallMasterSprite createDownMovingWallMasterSprite()
        {
            // Initial sprite direction is down
            return new WallMasterSprite(enemies);

        }

        public WallMasterSprite createUpMovingWallMasterSprite()
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

        public WallMasterSprite createRightMovingWallMasterSprite()
        {
            WallMasterSprite sprite = new WallMasterSprite(enemies);
            sprite.state = new RightMovingWallMasterState(sprite);
            return sprite;
        }

        //Rope sprites
        public RopeSprite createDownMovingRopeSprite()
        {
            // Initial sprite direction is down
            return new RopeSprite(enemies);

        }

        public RopeSprite createUpMovingRopeSprite()
        {
            RopeSprite sprite = new RopeSprite(enemies);
            sprite.state = new UpMovingRopeState(sprite);
            return sprite;
        }

        public RopeSprite createLeftMovingRopeSprite()
        {
            RopeSprite sprite = new RopeSprite(enemies);
            sprite.state = new LeftMovingRopeState(sprite);
            return sprite;
        }

        public RopeSprite createRightMovingRopeSprite()
        {
            RopeSprite sprite = new RopeSprite(enemies);
            sprite.state = new RightMovingRopeState(sprite);
            return sprite;
        }

        //Gel Sprites
        public GelSprite createDownMovingGelSprite()
        {
            // Initial sprite direction is down
            return new GelSprite(enemies);

        }

        public GelSprite createUpMovingGelSprite()
        {
            GelSprite sprite = new GelSprite(enemies);
            sprite.state = new UpMovingGelState(sprite);
            return sprite;
        }

        public GelSprite createLeftMovingGelSprite()
        {
            GelSprite sprite = new GelSprite(enemies);
            sprite.state = new LeftMovingGelState(sprite);
            return sprite;
        }

        public GelSprite createightMovingGelSprite()
        {
            GelSprite sprite = new GelSprite(enemies);
            sprite.state = new RightMovingGelState(sprite);
            return sprite;
        }

        // Zol Sprites
        public ZolSprite createDownMovingZolSprite()
        {
            // Initial sprite direction is down
            return new ZolSprite(enemies);

        }

        public ZolSprite createUpMovingZolSprite()
        {
            ZolSprite sprite = new ZolSprite(enemies);
            sprite.state = new UpMovingZolState(sprite);
            return sprite;
        }

        public ZolSprite createLeftMovingZolSprite()
        {
            ZolSprite sprite = new ZolSprite(enemies);
            sprite.state = new LeftMovingZolState(sprite);
            return sprite;
        }

        public ZolSprite createRightMovingZolSprite()
        {
            ZolSprite sprite = new ZolSprite(enemies);
            sprite.state = new RightMovingZolState(sprite);
            return sprite;
        }

        //SpikeCrossSprite
        public SpikeCrossSprite createDownMovingSpikeCrossSprite()
        {
            // Initial sprite direction is down
            return new SpikeCrossSprite(enemies);

        }

        public SpikeCrossSprite createUpMovingSpikeCrossSprite()
        {
            SpikeCrossSprite sprite = new SpikeCrossSprite(enemies);
            sprite.state = new UpMovingSpikeCrossState(sprite);
            return sprite;
        }

        public SpikeCrossSprite createLeftMovingSpikeCrossSprite()
        {
            SpikeCrossSprite sprite = new SpikeCrossSprite(enemies);
            sprite.state = new LeftMovingSpikeCrossState(sprite);
            return sprite;
        }

        public SpikeCrossSprite createRightMovingSpikeCrossSprite()
        {
            SpikeCrossSprite sprite = new SpikeCrossSprite(enemies);
            sprite.state = new RightMovingSpikeCrossState(sprite);
            return sprite;
        }

        //Keese Sprites
        public KeeseSprite createDownMovingKeeseSprite()
        {
            // Initial sprite direction is down
            return new KeeseSprite(enemies);

        }

        public KeeseSprite createUpMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new UpMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createLeftMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new LeftMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createRightMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new RightMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createUpLeftMovingKeeseSprite()
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

        public KeeseSprite createDownLeftMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new DownLeftMovingKeeseState(sprite);
            return sprite;
        }

        public KeeseSprite createDownRightMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
            sprite.state = new DownRightMovingKeeseState(sprite);
            return sprite;
        }

        //Dragon Sprites
        public DragonSprite createLeftMovingDragonSprite()
        {
            DragonSprite sprite = new DragonSprite(enemies);
            sprite.state = new LeftMovingDragonState(sprite);
            return sprite;
        }

        public DragonSprite createRightMovingDragonSprite()
        {
            DragonSprite sprite = new DragonSprite(enemies);
            sprite.state = new RightMovingDragonState(sprite);
            return sprite;
        }

        //DodongoSprites
        public DodongoSprite createDownMovingDodongoSprite()
        {
            // Initial sprite direction is down
            return new DodongoSprite(enemies);

        }

        public DodongoSprite createUpMovingDodongoSprite()
        {
            DodongoSprite sprite = new DodongoSprite(enemies);
            sprite.state = new UpMovingDodongoState(sprite);
            return sprite;
        }

        public DodongoSprite createLeftMovingDodongoSprite()
        {
            DodongoSprite sprite = new DodongoSprite(enemies);
            sprite.state = new LeftMovingDodongoState(sprite);
            return sprite;
        }

        public DodongoSprite createRightMovingDodongoSprite()
        {
            DodongoSprite sprite = new DodongoSprite(enemies);
            sprite.state = new RightMovingDodongoState(sprite);
            return sprite;
        }

        //Old Man Sprite
        public OldManSprite createOldManSprite()
        {
            return new OldManSprite(enemies); 
        }

        //Merchant Sprite
        public MerchantSprite createMerchantSprite()
        {
            return new MerchantSprite(enemies);
        }

        //Flame Sprite
        public FlameSprite createFlameSprite()
        {
            return new FlameSprite(enemies);
        }

    }
}
