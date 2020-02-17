using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class EnemySpriteFactory
    {
        private Texture2D stalfos;
        private SpriteSheetData stalfosData = new SpriteSheetData("stalfos", 25, 25, 2, 1);

        private Texture2D downGoriya;
        private SpriteSheetData downGoriyaData = new SpriteSheetData("redGoriyaDown", 25, 30, 2, 1);
        private Texture2D upGoriya;
        private SpriteSheetData upGoriyaData = new SpriteSheetData("redGoriyaUp", 25, 30, 2, 1);
        private Texture2D leftGoriya;
        private SpriteSheetData leftGoriyaData = new SpriteSheetData("redGoriyaLeft", 25, 30, 2, 1);
        private Texture2D rightGoriya;
        private SpriteSheetData rightGoriyaData = new SpriteSheetData("redGoriyaRight", 25, 30, 2, 1);

        private Texture2D leftWallMaster;
        private SpriteSheetData leftWallMasterData = new SpriteSheetData("wallMasterLeft", 25, 25, 2, 1);
        private Texture2D rightWallMaster;
        private SpriteSheetData rightWallMasterData = new SpriteSheetData("wallMasterRight", 25, 25, 2, 1);

        private Texture2D leftRope;
        private SpriteSheetData leftRopeData = new SpriteSheetData("ropeLeft", 25, 25, 2, 1);
        private Texture2D rightRope;
        private SpriteSheetData rightRopeData = new SpriteSheetData("ropeRight", 25, 25, 2, 1);

        private Texture2D gel;
        private SpriteSheetData gelData = new SpriteSheetData("gel/tealGel", 15, 15, 2, 1);
        private Texture2D zol;
        private SpriteSheetData zolData = new SpriteSheetData("xol/grayXol", 25, 25, 2, 1);

        private Texture2D spikeCross;
        private SpriteSheetData spikeCrossData = new SpriteSheetData("spike", 25, 25, 1, 1);

        private Texture2D keese;
        private SpriteSheetData keeseData = new SpriteSheetData("keese", 20, 20, 2, 1);


        private Texture2D dragon;
        private SpriteSheetData dragonData = new SpriteSheetData("aquamentus", 65, 85, 1, 4);
        private Texture2D damagedDragon;
        private SpriteSheetData damagedDragonData = new SpriteSheetData("damagedAqua", 65, 85, 1, 4);
        private Texture2D fireball;
        private SpriteSheetData fireballData = new SpriteSheetData("fireball", 12, 12, 1, 4);

        private Texture2D downDodongo;
        private SpriteSheetData downDodongoData = new SpriteSheetData("dodongoDown", 30, 35, 1, 2);
        private Texture2D upDodongo;
        private SpriteSheetData upDodongoData = new SpriteSheetData("dodongoUp", 30, 35, 1, 2);
        private Texture2D leftDodongo;
        private SpriteSheetData leftDodongoData = new SpriteSheetData("dodongoLeft", 40, 30, 1, 2);
        private Texture2D rightDodongo;
        private SpriteSheetData rightDodongoData = new SpriteSheetData("dodongoRight", 40, 30, 1, 2);

        private Texture2D oldMan;
        private SpriteSheetData oldManData = new SpriteSheetData("oldMan", 30, 30, 1, 1);
        private Texture2D merchant;
        private SpriteSheetData merchantData = new SpriteSheetData("merchant", 25, 25, 1, 1);
        private Texture2D flame;
        private SpriteSheetData flameData = new SpriteSheetData("flame", 30, 30, 1, 2);

         private Texture2D deadEnemy;
        private SpriteSheetData deadEnemyData = new SpriteSheetData("enemyDeath", 50, 50, 1, 2);




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
            stalfos = content.Load<Texture2D>(stalfosData.FilePath);

            downGoriya = content.Load<Texture2D>(downGoriyaData.FilePath);
            upGoriya = content.Load<Texture2D>(upGoriyaData.FilePath);
            leftGoriya = content.Load<Texture2D>(leftGoriyaData.FilePath);
            rightGoriya = content.Load<Texture2D>(rightGoriyaData.FilePath);

            leftWallMaster = content.Load<Texture2D>(leftWallMasterData.FilePath);
            rightWallMaster = content.Load<Texture2D>(rightWallMasterData.FilePath);

            leftRope = content.Load<Texture2D>(leftRopeData.FilePath);
            rightRope = content.Load<Texture2D>(rightRopeData.FilePath);

            gel = content.Load<Texture2D>(gelData.FilePath);
            zol = content.Load<Texture2D>(zolData.FilePath);

            spikeCross = content.Load<Texture2D>(spikeCrossData.FilePath);

            fireball = content.Load<Texture2D>(fireballData.FilePath);

            keese = content.Load<Texture2D>(keeseData.FilePath);

            dragon = content.Load<Texture2D>(dragonData.FilePath);
            damagedDragon = content.Load<Texture2D>(damagedDragonData.FilePath);

            downDodongo = content.Load<Texture2D>(downDodongoData.FilePath);
            upDodongo = content.Load<Texture2D>(upDodongoData.FilePath);
            leftDodongo = content.Load<Texture2D>(leftDodongoData.FilePath);
            rightDodongo = content.Load<Texture2D>(rightDodongoData.FilePath);

            oldMan = content.Load<Texture2D>(oldManData.FilePath);
            merchant = content.Load<Texture2D>(merchantData.FilePath);
           // flame = content.Load<Texture2D>(flameData.FilePath);

            deadEnemy = content.Load<Texture2D>(deadEnemyData.FilePath);
        }

        //Stalfos Sprites

        public StalfosSprite createStalfosSprite()
        {
            return new StalfosSprite(stalfos, stalfosData);
        }


        //Goriya Sprites

        public GoriyaDownSprite createDownMovingGoriyaSprite()
        {
            return new GoriyaDownSprite(downGoriya, downGoriyaData);
        }

        public GoriyaUpSprite createUpMovingGoriyaSprite()
        {
            return new GoriyaUpSprite(upGoriya, upGoriyaData);
        }

        public GoriyaLeftSprite createLeftMovingGoriyaSprite()
        {
            return new GoriyaLeftSprite(leftGoriya, leftGoriyaData);
        }

        public GoriyaRightSprite createRightMovingGoriyaSprite()
        {
            return new GoriyaRightSprite(rightGoriya, rightGoriyaData);
        }

        //Wallmaster Sprites

        public WallMasterLeftSprite createLeftMovingWallMasterSprite()
        {
            return new WallMasterLeftSprite(leftWallMaster, leftWallMasterData);
        }

        public WallMasterRightSprite createRightMovingWallMasterSprite()
        {
            return new WallMasterRightSprite(rightWallMaster, rightWallMasterData);
        }

        //Rope sprites

        public RopeLeftSprite createLeftMovingRopeSprite()
        {
            return new RopeLeftSprite(leftRope, leftRopeData);
        }

        public RopeRightSprite createRightMovingRopeSprite()
        {
            return new RopeRightSprite(rightRope, rightRopeData);
        }

        //Gel Sprites

        public GelSprite createGelSprite()
        {
            return new GelSprite(gel, gelData);
        }

        // Zol Sprites
        public ZolSprite createZolSprite()
        {
            return new ZolSprite(zol, zolData);
        }

        //SpikeCrossSprite
        public SpikeCrossSprite createSpikeCrossSprite()
        {
            return new SpikeCrossSprite(spikeCross, spikeCrossData);
        }

        //Keese Sprites

        public KeeseSprite createKeeseSprite()
        {
            return new KeeseSprite(keese, keeseData);
        }

        //Dragon Sprites
        public DragonSprite createDragonSprite()
        {
            return new DragonSprite(dragon, dragonData);
        }
        public DragonDamagedSprite createDamagedDragonSprite()
        {
            return new DragonDamagedSprite(damagedDragon, damagedDragonData);
        }
        public FireballSprite createLeftFireballSprite(Vector2 location)
        {
            return new FireballSprite(fireball, fireballData, "left", location);
        }

        public FireballSprite createDownLeftFireballSprite(Vector2 location)
        {
            return new FireballSprite(fireball, fireballData, "down", location);
        }

        public FireballSprite createUpLeftFireballSprite(Vector2 location)
        {
            return new FireballSprite(fireball, fireballData, "up", location);
        }

        //DodongoSprites
        public DodongoDownSprite createDownMovingDodongoSprite()
        {
            return new DodongoDownSprite(downDodongo, downDodongoData);
        }

        public DodongoUpSprite createUpMovingDodongoSprite()
        {
            return new DodongoUpSprite(upDodongo, upDodongoData);
        }

        public DodongoLeftSprite createLeftMovingDodongoSprite()
        {
            return new DodongoLeftSprite(leftDodongo, leftDodongoData);
        }

        public DodongoRightSprite createRightMovingDodongoSprite()
        {
            return new DodongoRightSprite(rightDodongo, rightDodongoData);
        }

        //Old Man Sprite
        
        public OldManSprite createOldManSprite()
        {
            return new OldManSprite(oldMan, oldManData);
        }

        //Merchant Sprite
        public MerchantSprite createMerchantSprite()
        {
            return new MerchantSprite(merchant, merchantData);
        }

        //Flame Sprite
       // public FlameSprite createFlameSprite()
        //{
          //  return new FlameSprite(flame, flameData);
        //}
        
         //Enemy Death Sprite
        public DeadEnemySprite createDeadEnemySprite()
        {
            return new DeadEnemySprite(deadEnemy, deadEnemyData);
        }
    }
}