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
            return new StalfosSprite(enemies, "down"); 
        }

        public StalfosSprite createUpMovingStalfosSprite()
        {
            return new StalfosSprite(enemies, "up");
        }

        public StalfosSprite createLeftMovingStalfosSprite()
        {
            return new StalfosSprite(enemies, "left");
        }

        public StalfosSprite createRightMovingStalfosSprite()
        {
            return new StalfosSprite(enemies, "right");
        }

        //Goriya Sprites

        public GoriyaSprite createDownMovingGoriyaSprite()
        {
            return new GoriyaSprite(enemies, "down");
        }

        public GoriyaSprite createUpMovingGoriyaSprite()
        {
            return new GoriyaSprite(enemies, "down");
        }

        public GoriyaSprite createLeftMovingGoriyaSprite()
        {
            return new GoriyaSprite(enemies, "down");
        }

        public GoriyaSprite createRightMovingGoriyaSprite()
        {
            return new GoriyaSprite(enemies, "down");
        }

        //Wallmaster Sprites

        public WallMasterSprite createDownMovingWallMasterSprite()
        {
            return new WallMasterSprite(enemies, "down");
        }

        public WallMasterSprite createUpMovingWallMasterSprite()
        {
            return new WallMasterSprite(enemies, "down");
        }

        public WallMasterSprite createSpriteLeftMovingWallMaster()
        {
            return new WallMasterSprite(enemies, "down");
        }

        public WallMasterSprite createRightMovingWallMasterSprite()
        {
            return new WallMasterSprite(enemies, "down");
        }

        //Rope sprites
        public RopeSprite createDownMovingRopeSprite()
        {
            return new RopeSprite(enemies, "down");
        }

        public RopeSprite createUpMovingRopeSprite()
        {
            return new RopeSprite(enemies, "down");
        }

        public RopeSprite createLeftMovingRopeSprite()
        {
            return new RopeSprite(enemies, "down");
        }

        public RopeSprite createRightMovingRopeSprite()
        {
            return new RopeSprite(enemies, "down");
        }

        //Gel Sprites
        public GelSprite createDownMovingGelSprite()
        {
            return new GelSprite(enemies, "down");
        }

        public GelSprite createUpMovingGelSprite()
        {
            return new GelSprite(enemies, "down");
        }

        public GelSprite createLeftMovingGelSprite()
        {
            return new GelSprite(enemies, "down");
        }

        public GelSprite createightMovingGelSprite()
        {
            return new GelSprite(enemies, "down");
        }

        // Zol Sprites
        public ZolSprite createDownMovingZolSprite()
        {
            return new ZolSprite(enemies, "down");
        }

        public ZolSprite createUpMovingZolSprite()
        {
            return new ZolSprite(enemies, "down");
        }

        public ZolSprite createLeftMovingZolSprite()
        {
            return new ZolSprite(enemies, "down");
        }

        public ZolSprite createRightMovingZolSprite()
        {
            return new ZolSprite(enemies, "down");
        }

        //SpikeCrossSprite
        public SpikeCrossSprite createDownMovingSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "down");
        }

        public SpikeCrossSprite createUpMovingSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "down");
        }

        public SpikeCrossSprite createLeftMovingSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "down");
        }

        public SpikeCrossSprite createRightMovingSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "down");
        }

        //Keese Sprites
        public KeeseSprite createDownMovingKeeseSprite()
        {
            return new KeeseSprite(enemies);
        }

        public KeeseSprite createUpMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
        }

        public KeeseSprite createLeftMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
        }

        public KeeseSprite createRightMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
        }

        public KeeseSprite createUpLeftMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
        }

        public KeeseSprite createSpriteUpRightMovingKeese()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
        }

        public KeeseSprite createDownLeftMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
        }

        public KeeseSprite createDownRightMovingKeeseSprite()
        {
            KeeseSprite sprite = new KeeseSprite(enemies);
        }

        //Dragon Sprites
        public DragonSprite createLeftMovingDragonSprite()
        {
            DragonSprite sprite = new DragonSprite(enemies);
        }

        public DragonSprite createRightMovingDragonSprite()
        {
            DragonSprite sprite = new DragonSprite(enemies);
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
        }

        public DodongoSprite createLeftMovingDodongoSprite()
        {
            DodongoSprite sprite = new DodongoSprite(enemies);
        }

        public DodongoSprite createRightMovingDodongoSprite()
        {
            DodongoSprite sprite = new DodongoSprite(enemies);
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
