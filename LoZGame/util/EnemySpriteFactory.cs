using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class EnemySpriteFactory
    {
        private Texture2D enemies;

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
            return new GoriyaSprite(enemies, "up");
        }

        public GoriyaSprite createLeftMovingGoriyaSprite()
        {
            return new GoriyaSprite(enemies, "left");
        }

        public GoriyaSprite createRightMovingGoriyaSprite()
        {
            return new GoriyaSprite(enemies, "right");
        }

        //Wallmaster Sprites

        public WallMasterSprite createDownMovingWallMasterSprite()
        {
            return new WallMasterSprite(enemies, "down");
        }

        public WallMasterSprite createUpMovingWallMasterSprite()
        {
            return new WallMasterSprite(enemies, "up");
        }

        public WallMasterSprite createSpriteLeftMovingWallMaster()
        {
            return new WallMasterSprite(enemies, "left");
        }

        public WallMasterSprite createRightMovingWallMasterSprite()
        {
            return new WallMasterSprite(enemies, "right");
        }

        //Rope sprites
        public RopeSprite createDownMovingRopeSprite()
        {
            return new RopeSprite(enemies, "down");
        }

        public RopeSprite createUpMovingRopeSprite()
        {
            return new RopeSprite(enemies, "up");
        }

        public RopeSprite createLeftMovingRopeSprite()
        {
            return new RopeSprite(enemies, "left");
        }

        public RopeSprite createRightMovingRopeSprite()
        {
            return new RopeSprite(enemies, "right");
        }

        //Gel Sprites
        public GelSprite createDownMovingGelSprite()
        {
            return new GelSprite(enemies, "down");
        }

        public GelSprite createUpMovingGelSprite()
        {
            return new GelSprite(enemies, "up");
        }

        public GelSprite createLeftMovingGelSprite()
        {
            return new GelSprite(enemies, "left");
        }

        public GelSprite createRightMovingGelSprite()
        {
            return new GelSprite(enemies, "right");
        }

        // Zol Sprites
        public ZolSprite createDownMovingZolSprite()
        {
            return new ZolSprite(enemies, "down");
        }

        public ZolSprite createUpMovingZolSprite()
        {
            return new ZolSprite(enemies, "up");
        }

        public ZolSprite createLeftMovingZolSprite()
        {
            return new ZolSprite(enemies, "left");
        }

        public ZolSprite createRightMovingZolSprite()
        {
            return new ZolSprite(enemies, "right");
        }

        //SpikeCrossSprite
        public SpikeCrossSprite createIdleSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "idle");
        }
        public SpikeCrossSprite createDownMovingSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "down");
        }

        public SpikeCrossSprite createUpMovingSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "up");
        }

        public SpikeCrossSprite createLeftMovingSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "left");
        }

        public SpikeCrossSprite createRightMovingSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies, "right");
        }

        //Keese Sprites
        public KeeseSprite createDownMovingKeeseSprite()
        {
            return new KeeseSprite(enemies, "down");
        }

        public KeeseSprite createUpMovingKeeseSprite()
        {
            return new KeeseSprite(enemies, "up");
        }

        public KeeseSprite createLeftMovingKeeseSprite()
        {
            return new KeeseSprite(enemies, "left");
        }

        public KeeseSprite createRightMovingKeeseSprite()
        {
            return new KeeseSprite(enemies, "right");
        }

        public KeeseSprite createUpLeftMovingKeeseSprite()
        {
            return new KeeseSprite(enemies, "up_left");
        }

            public KeeseSprite createSpriteUpRightMovingKeese()
        {
            return new KeeseSprite(enemies, "up_right");
        }

        public KeeseSprite createDownLeftMovingKeeseSprite()
        {
            return new KeeseSprite(enemies, "down_left");
        }

        public KeeseSprite createDownRightMovingKeeseSprite()
        {
            return new KeeseSprite(enemies, "down_right");
        }

        //Dragon Sprites
        public DragonSprite createIdleDragonSprite()
        {
            DragonSprite sprite = new DragonSprite(enemies, "idle");
        }
        public DragonSprite createLeftMovingDragonSprite()
        {
            DragonSprite sprite = new DragonSprite(enemies, "left");
        }

        public DragonSprite createRightMovingDragonSprite()
        {
            DragonSprite sprite = new DragonSprite(enemies, "right");
        }

        //DodongoSprites
        public DodongoSprite createDownMovingDodongoSprite()
        {
            return new DodongoSprite(enemies, "down");
        }

        public DodongoSprite createUpMovingDodongoSprite()
        {
            return new DodongoSprite(enemies, "up");
        }

        public DodongoSprite createLeftMovingDodongoSprite()
        {
            return new DodongoSprite(enemies, "left");
        }

        public DodongoSprite createRightMovingDodongoSprite()
        {
            return new DodongoSprite(enemies, "right");
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
