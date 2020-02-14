using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class EnemySpriteFactory
    {
        private Texture2D stalfos;
        private SpriteSheetData stalfosData = new SpriteSheetData("stalfos", 50, 50, 1, 1);

        private Texture2D downGoriya;
        private SpriteSheetData downGoriyaData = new SpriteSheetData("redGoriyaDown", 50, 60, 1, 1);
        private Texture2D upGoriya;
        private SpriteSheetData upGoriyaData = new SpriteSheetData("redGoriyaUp", 50, 60, 1, 1);
        private Texture2D leftGoriya;
        private SpriteSheetData leftGoriyaData = new SpriteSheetData("redGoriyaLeft", 50, 60, 1, 1);
        private Texture2D rightGoriya;
        private SpriteSheetData rightGoriyaData = new SpriteSheetData("redGoriyaRight", 50, 60, 1, 1);

        private Texture2D leftWallMaster;
        private SpriteSheetData leftWallMaster = new SpriteSheetData("wallMasterLeft", 50, 50, 1, 1);
        private Texture2D rightWallMaster;
        private SpriteSheetData rightWallMaster = new SpriteSheetData("wallMasterRight", 50, 50, 1, 1);

        private Texture2D leftRope;
        private SpriteSheetData leftRopeData = new SpriteSheetData("ropeLeft", 40, 40, 1, 1);
        private Texture2D rightRope;
        private SpriteSheetData rightRopeData = new SpriteSheetData("ropeRight", 40, 40, 1, 1);

        private Texture2D gel;
        private SpriteSheetData gelData = new SpriteSheetData("tealGel", 25, 25, 1, 1);
        private Texture2D zol;
        private SpriteSheetData zolData = new SpriteSheetData("grayXol", 50, 50, 1, 1);

        private Texture2D spikeCross;
        private SpriteSheetData spikeCrossData = new SpriteSheetData("spike", 50, 50, 1, 1);

        private Texture2D keese;
        private SpriteSheetData keeseData = new SpriteSheetData("keese", 40, 40, 1, 1);


        private Texture2D dragon;
        private SpriteSheetData dragonData = new SpriteSheetData("aquamentus", 75, 100, 1, 1);
        private Texture2D damagedDragon;
        private SpriteSheetData damagedDragonData = new SpriteSheetData("damagedAqua", 75, 100, 1, 1);

        private Texture2D downDodongo;
        private SpriteSheetData downDodongoData = new SpriteSheetData("dodongoDown", 50, 50, 1, 3);
        private Texture2D upDodongo;
        private SpriteSheetData upDodongoData = new SpriteSheetData("dodongoUp", 50, 50, 1, 1);
        private Texture2D leftDodongo;
        private SpriteSheetData leftDodongoData = new SpriteSheetData("dodongoLeft", 70, 50, 1, 1);
        private Texture2D rightDodongo;
        private SpriteSheetData rightDodongoData = new SpriteSheetData("dodongoRight", 70, 50, 1, 1);

        private Texture2D oldMan;
        private SpriteSheetData oldManData = new SpriteSheetData("oldMan", 50, 50, 1, 1);
        private Texture2D Merchant;
        private SpriteSheetData merchantData = new SpriteSheetData("merchant", 50, 50, 1, 1);
        private Texture2D flame;
        private SpriteSheetData flameData = new SpriteSheetData("fire", 50, 50, 1, 2);



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
            stalfos = content.Load<Texture2D>(stalfosData.spriteFileName);

            downGoriya = content.Load<Texture2D>(downGoriyaData.spriteFileName);
            upGoriya = content.Load<Texture2D>(upGoriyaData.spriteFileName);
            leftGoriya = content.Load<Texture2D>(leftGoriyaData.spriteFileName);
            rightGoriya = content.Load<Texture2D>(rightGoriyaData.spriteFileName);

            leftWallMaster = content.Load<Texture2D>(leftWallMasterData.spriteFileName);
            rightWallMaster = content.Load<Texture2D>(rightWallMasterData.spriteFileName);

            leftRope = content.Load<Texture2D>(leftRopeData.spriteFileName);
            rightRope = content.Load<Texture2D>(rightRopeData.spriteFileName);

            gel = content.Load<Texture2D>(gelData.spriteFileName);
            zol = content.Load<Texture2D>(zolData.spriteFileName);

            spikeCross = content.Load<Texture2D>(spikeCrossData.spriteFileName);

            keese = content.Load<Texture2D>(keeseData.spriteFileName);

            dragon = content.Load<Texture2D>(dragonData.spriteFileName);
            damagedDragon = content.Load<Texture2D>(damagedDragonData.spriteFileName);

            downDodongo = content.Load<Texture2D>(downDodongoData.spriteFileName);
            upDodongo = content.Load<Texture2D>(upDodongoData.spriteFileName);
            leftDodongo = content.Load<Texture2D>(leftDodongoData.spriteFileName);
            rightDodongo = content.Load<Texture2D>(rightDodongoData.spriteFileName);

            oldMan = content.Load<Texture2D>(oldManData.spriteFileName);
            merchant = content.Load<Texture2D>(merchantData.spriteFileName);
            flame = content.Load<Texture2D>(flameData.spriteFileName);
        }

        //Stalfos Sprites

        public StalfosSprite createStalfosSprite()
        {
            return new StalfosSprite(enemies); 
        }


        //Goriya Sprites

        public GoriyaSprite createDownMovingGoriyaSprite()
        {
            return new GoriyaDownSprite(enemies);
        }

        public GoriyaSprite createUpMovingGoriyaSprite()
        {
            return new GoriyaUpSprite(enemies);
        }

        public GoriyaSprite createLeftMovingGoriyaSprite()
        {
            return new GoriyaLeftSprite(enemies);
        }

        public GoriyaSprite createRightMovingGoriyaSprite()
        {
            return new GoriyaRightSprite(enemies);
        }

        //Wallmaster Sprites

        public WallMasterSprite createSpriteLeftMovingWallMaster()
        {
            return new WallMasterLeftSprite(enemies);
        }

        public WallMasterSprite createRightMovingWallMasterSprite()
        {
            return new WallMasterRightSprite(enemies);
        }

        //Rope sprites

        public RopeSprite createLeftMovingRopeSprite()
        {
            return new RopeLeftSprite(enemies);
        }

        public RopeSprite createRightMovingRopeSprite()
        {
            return new RopeRightSprite(enemies);
        }

        //Gel Sprites
       
        public GelSprite createGelSprite()
        {
            return new GelSprite(enemies);
        }

        // Zol Sprites
        public ZolSprite createZolSprite()
        {
            return new ZolSprite(enemies);
        }

        //SpikeCrossSprite
        public SpikeCrossSprite createSpikeCrossSprite()
        {
            return new SpikeCrossSprite(enemies);
        }

        //Keese Sprites
        
        public KeeseSprite createDownKeeseSprite()
        {
            return new KeeseSprite(enemies);
        }

        //Dragon Sprites
        public DragonSprite createDragonSprite()
        {
            return new DragonSprite(enemies);
        }
        public DragonSprite createDamagedDragonSprite()
        {
            return new DragonDamagedSprite(enemies);
        }

        //DodongoSprites
        public DodongoSprite createDownMovingDodongoSprite()
        {
            return new DodongoDownSprite(enemies);
        }

        public DodongoSprite createUpMovingDodongoSprite()
        {
            return new DodongoUpSprite(enemies);
        }

        public DodongoSprite createLeftMovingDodongoSprite()
        {
            return new DodongoLeftSprite(enemies);
        }

        public DodongoSprite createRightMovingDodongoSprite()
        {
            return new DodongoRightSprite(enemies);
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
