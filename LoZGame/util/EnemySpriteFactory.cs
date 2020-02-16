using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class EnemySpriteFactory
    {
        private Texture2D stalfos;
        private SpriteSheetData stalfosData = new SpriteSheetData("stalfos", 50, 50, 2, 1);

        private Texture2D downGoriya;
        private SpriteSheetData downGoriyaData = new SpriteSheetData("redGoriyaDown", 50, 60, 2, 1);
        private Texture2D upGoriya;
        private SpriteSheetData upGoriyaData = new SpriteSheetData("redGoriyaUp", 50, 60, 2, 1);
        private Texture2D leftGoriya;
        private SpriteSheetData leftGoriyaData = new SpriteSheetData("redGoriyaLeft", 50, 60, 2, 1);
        private Texture2D rightGoriya;
        private SpriteSheetData rightGoriyaData = new SpriteSheetData("redGoriyaRight", 50, 60, 2, 1);

        private Texture2D leftWallMaster;
        private SpriteSheetData leftWallMasterData = new SpriteSheetData("wallMasterLeft", 50, 50, 2, 1);
        private Texture2D rightWallMaster;
        private SpriteSheetData rightWallMasterData = new SpriteSheetData("wallMasterRight", 50, 50, 2, 1);

        private Texture2D leftRope;
        private SpriteSheetData leftRopeData = new SpriteSheetData("ropeLeft", 40, 40, 2, 1);
        private Texture2D rightRope;
        private SpriteSheetData rightRopeData = new SpriteSheetData("ropeRight", 40, 40, 2, 1);

        private Texture2D gel;
        private SpriteSheetData gelData = new SpriteSheetData("tealGel", 25, 25, 2, 1);
        private Texture2D zol;
        private SpriteSheetData zolData = new SpriteSheetData("grayXol", 50, 50, 2, 1);

        private Texture2D spikeCross;
        private SpriteSheetData spikeCrossData = new SpriteSheetData("spike", 50, 50, 1, 1);

        private Texture2D keese;
        private SpriteSheetData keeseData = new SpriteSheetData("keese", 40, 40, 2, 1);


        private Texture2D dragon;
        private SpriteSheetData dragonData = new SpriteSheetData("aquamentus", 75, 100, 1, 1);
        private Texture2D damagedDragon;
        private SpriteSheetData damagedDragonData = new SpriteSheetData("damagedAqua", 75, 100, 1, 1);
        private Texture2D fireball;
        private SpriteSheetData fireballData = new SpriteSheetData("fireball", 35, 35, 4, 1);

        private Texture2D downDodongo;
        private SpriteSheetData downDodongoData = new SpriteSheetData("dodongoDown", 50, 50, 1, 3);
        private Texture2D upDodongo;
        private SpriteSheetData upDodongoData = new SpriteSheetData("dodongoUp", 50, 50, 1, 3);
        private Texture2D leftDodongo;
        private SpriteSheetData leftDodongoData = new SpriteSheetData("dodongoLeft", 70, 50, 1, 3);
        private Texture2D rightDodongo;
        private SpriteSheetData rightDodongoData = new SpriteSheetData("dodongoRight", 70, 50, 1, 3);

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
            return new StalfosSprite(stalfos);
        }


        //Goriya Sprites

        public GoriyaDownSprite createDownMovingGoriyaSprite()
        {
            return new GoriyaDownSprite(downGoriya);
        }

        public GoriyaUpSprite createUpMovingGoriyaSprite()
        {
            return new GoriyaUpSprite(upGoriya);
        }

        public GoriyaLeftSprite createLeftMovingGoriyaSprite()
        {
            return new GoriyaLeftSprite(leftGoriya);
        }

        public GoriyaRightSprite createRightMovingGoriyaSprite()
        {
            return new GoriyaRightSprite(rightGoriya);
        }

        //Wallmaster Sprites

        public WallMasterLeftSprite createSpriteLeftMovingWallMaster()
        {
            return new WallMasterLeftSprite(leftWallMaster);
        }

        public WallMasterRightSprite createRightMovingWallMasterSprite()
        {
            return new WallMasterRightSprite(rightWallMaster);
        }

        //Rope sprites

        public RopeLeftSprite createLeftMovingRopeSprite()
        {
            return new RopeLeftSprite(leftRope);
        }

        public RopeRightSprite createRightMovingRopeSprite()
        {
            return new RopeRightSprite(rightRope);
        }

        //Gel Sprites

        public GelSprite createGelSprite()
        {
            return new GelSprite(gel);
        }

        // Zol Sprites
        public ZolSprite createZolSprite()
        {
            return new ZolSprite(zol);
        }

        //SpikeCrossSprite
        public SpikeCrossSprite createSpikeCrossSprite()
        {
            return new SpikeCrossSprite(spikeCross);
        }

        //Keese Sprites

        public KeeseSprite createDownKeeseSprite()
        {
            return new KeeseSprite(keese);
        }

        //Dragon Sprites
        public DragonSprite createDragonSprite()
        {
            return new DragonSprite(dragon);
        }
        public DragonSprite createDamagedDragonSprite()
        {
            return new DragonDamagedSprite(damagedDragon);
        }
        public FireballSprite createLeftFireBallSprite()
        {
            return new FireballSprite(fireball, "left");
        }

        public FireballSprite createDownLeftFireBallSprite()
        {
            return new FireballSprite(fireball, "down");
        }

        public FireballSprite createUpLeftFireBallSprite()
        {
            return new FireballSprite(fireball, "up");
        }

        //DodongoSprites
        public DodongoDownSprite createDownMovingDodongoSprite()
        {
            return new DodongoDownSprite(downDodongo);
        }

        public DodongoUpSprite createUpMovingDodongoSprite()
        {
            return new DodongoUpSprite(upDodongo);
        }

        public DodongoLeftSprite createLeftMovingDodongoSprite()
        {
            return new DodongoLeftSprite(leftDodongo);
        }

        public DodongoRightSprite createRightMovingDodongoSprite()
        {
            return new DodongoRightSprite(rightDodongo);
        }

        //Old Man Sprite
        public OldManSprite createOldManSprite()
        {
            return new OldManSprite(oldMan);
        }

        //Merchant Sprite
        public MerchantSprite createMerchantSprite()
        {
            return new MerchantSprite(Merchant);
        }

        //Flame Sprite
        public FlameSprite createFlameSprite()
        {
            return new FlameSprite(flame);
        }

    }
}