namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class EnemySpriteFactory
    {
        private Texture2D stalfos;
        private readonly SpriteSheetData stalfosData = new SpriteSheetData("stalfos", 30, 35, 2, 1);

        private Texture2D downGoriya;
        private readonly SpriteSheetData downGoriyaData = new SpriteSheetData("redGoriyaDown", 25, 30, 2, 1);
        private Texture2D upGoriya;
        private readonly SpriteSheetData upGoriyaData = new SpriteSheetData("redGoriyaUp", 25, 30, 2, 1);
        private Texture2D leftGoriya;
        private readonly SpriteSheetData leftGoriyaData = new SpriteSheetData("redGoriyaLeft", 25, 30, 2, 1);
        private Texture2D rightGoriya;
        private readonly SpriteSheetData rightGoriyaData = new SpriteSheetData("redGoriyaRight", 25, 30, 2, 1);

        private Texture2D leftWallMaster;
        private readonly SpriteSheetData leftWallMasterData = new SpriteSheetData("wallMasterLeft", 25, 25, 2, 1);
        private Texture2D rightWallMaster;
        private readonly SpriteSheetData rightWallMasterData = new SpriteSheetData("wallMasterRight", 25, 25, 2, 1);

        private Texture2D leftRope;
        private readonly SpriteSheetData leftRopeData = new SpriteSheetData("ropeLeft", 25, 25, 2, 1);
        private Texture2D rightRope;
        private readonly SpriteSheetData rightRopeData = new SpriteSheetData("ropeRight", 25, 25, 2, 1);

        private Texture2D gel;
        private readonly SpriteSheetData gelData = new SpriteSheetData("tealGel", 15, 15, 2, 1);
        private Texture2D zol;
        private readonly SpriteSheetData zolData = new SpriteSheetData("grayXol", 25, 25, 2, 1);

        private Texture2D spikeCross;
        private readonly SpriteSheetData spikeCrossData = new SpriteSheetData("spike", 25, 25, 1, 1);

        private Texture2D keese;
        private readonly SpriteSheetData keeseData = new SpriteSheetData("keese", 20, 20, 2, 1);

        private Texture2D dragon;
        private readonly SpriteSheetData dragonData = new SpriteSheetData("aquamentus", 50, 70, 1, 4);
        private Texture2D damagedDragon;
        private readonly SpriteSheetData damagedDragonData = new SpriteSheetData("damagedAqua", 50, 70, 1, 4);
        private Texture2D fireball;
        private readonly SpriteSheetData fireballData = new SpriteSheetData("fireball", 12, 12, 1, 4);

        private Texture2D downDodongo;
        private readonly SpriteSheetData downDodongoData = new SpriteSheetData("dodongoDown", 16, 16, 1, 3);
        private Texture2D upDodongo;
        private readonly SpriteSheetData upDodongoData = new SpriteSheetData("dodongoUp", 16, 16, 1, 3);
        private Texture2D leftDodongo;
        private readonly SpriteSheetData leftDodongoData = new SpriteSheetData("dodongoLeft", 32, 16, 1, 3);
        private Texture2D rightDodongo;
        private readonly SpriteSheetData rightDodongoData = new SpriteSheetData("dodongoRight", 32, 16, 1, 3);

        private Texture2D oldMan;
        private readonly SpriteSheetData oldManData = new SpriteSheetData("oldMan", 30, 30, 1, 1);
        private Texture2D merchant;
        private readonly SpriteSheetData merchantData = new SpriteSheetData("merchant", 25, 25, 1, 1);

        private Texture2D deadEnemy;
        private readonly SpriteSheetData deadEnemyData = new SpriteSheetData("enemyDeath", 50, 50, 1, 2);

        private static readonly EnemySpriteFactory InstanceValue = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return InstanceValue;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.stalfos = content.Load<Texture2D>(this.stalfosData.FilePath);

            this.downGoriya = content.Load<Texture2D>(this.downGoriyaData.FilePath);
            this.upGoriya = content.Load<Texture2D>(this.upGoriyaData.FilePath);
            this.leftGoriya = content.Load<Texture2D>(this.leftGoriyaData.FilePath);
            this.rightGoriya = content.Load<Texture2D>(this.rightGoriyaData.FilePath);

            this.leftWallMaster = content.Load<Texture2D>(this.leftWallMasterData.FilePath);
            this.rightWallMaster = content.Load<Texture2D>(this.rightWallMasterData.FilePath);

            this.leftRope = content.Load<Texture2D>(this.leftRopeData.FilePath);
            this.rightRope = content.Load<Texture2D>(this.rightRopeData.FilePath);

            this.gel = content.Load<Texture2D>(this.gelData.FilePath);
            this.zol = content.Load<Texture2D>(this.zolData.FilePath);

            this.spikeCross = content.Load<Texture2D>(this.spikeCrossData.FilePath);

            this.fireball = content.Load<Texture2D>(this.fireballData.FilePath);

            this.keese = content.Load<Texture2D>(this.keeseData.FilePath);

            this.dragon = content.Load<Texture2D>(this.dragonData.FilePath);
            this.damagedDragon = content.Load<Texture2D>(this.damagedDragonData.FilePath);

            this.downDodongo = content.Load<Texture2D>(this.downDodongoData.FilePath);
            this.upDodongo = content.Load<Texture2D>(this.upDodongoData.FilePath);
            this.leftDodongo = content.Load<Texture2D>(this.leftDodongoData.FilePath);
            this.rightDodongo = content.Load<Texture2D>(this.rightDodongoData.FilePath);

            this.oldMan = content.Load<Texture2D>(this.oldManData.FilePath);
            this.merchant = content.Load<Texture2D>(this.merchantData.FilePath);

            this.deadEnemy = content.Load<Texture2D>(this.deadEnemyData.FilePath);
        }

        // Stalfos Sprites
        public StalfosSprite CreateStalfosSprite()
        {
            return new StalfosSprite(this.stalfos, this.stalfosData);
        }

        // Goriya Sprites
        public GoriyaDownSprite CreateDownMovingGoriyaSprite()
        {
            return new GoriyaDownSprite(this.downGoriya, this.downGoriyaData);
        }

        public GoriyaUpSprite CreateUpMovingGoriyaSprite()
        {
            return new GoriyaUpSprite(this.upGoriya, this.upGoriyaData);
        }

        public GoriyaLeftSprite CreateLeftMovingGoriyaSprite()
        {
            return new GoriyaLeftSprite(this.leftGoriya, this.leftGoriyaData);
        }

        public GoriyaRightSprite CreateRightMovingGoriyaSprite()
        {
            return new GoriyaRightSprite(this.rightGoriya, this.rightGoriyaData);
        }

        // Wallmaster Sprites
        public WallMasterLeftSprite CreateLeftMovingWallMasterSprite()
        {
            return new WallMasterLeftSprite(this.leftWallMaster, this.leftWallMasterData);
        }

        public WallMasterRightSprite CreateRightMovingWallMasterSprite()
        {
            return new WallMasterRightSprite(this.rightWallMaster, this.rightWallMasterData);
        }

        // Rope sprites
        public RopeLeftSprite CreateLeftMovingRopeSprite()
        {
            return new RopeLeftSprite(this.leftRope, this.leftRopeData);
        }

        public RopeRightSprite CreateRightMovingRopeSprite()
        {
            return new RopeRightSprite(this.rightRope, this.rightRopeData);
        }

        // Gel Sprites
        public GelSprite CreateGelSprite()
        {
            return new GelSprite(this.gel, this.gelData);
        }

        // Zol Sprites
        public ZolSprite CreateZolSprite()
        {
            return new ZolSprite(this.zol, this.zolData);
        }

        // SpikeCrossSprite
        public SpikeCrossSprite CreateSpikeCrossSprite()
        {
            return new SpikeCrossSprite(this.spikeCross, this.spikeCrossData);
        }

        // Keese Sprites
        public KeeseSprite CreateKeeseSprite()
        {
            return new KeeseSprite(this.keese, this.keeseData);
        }

        // Dragon Sprites
        public DragonSprite CreateDragonSprite()
        {
            return new DragonSprite(this.dragon, this.dragonData);
        }

        public DragonDamagedSprite CreateDamagedDragonSprite()
        {
            return new DragonDamagedSprite(this.damagedDragon, this.damagedDragonData);
        }

        public FireballSprite CreateLeftFireballSprite(Vector2 location, int id, int scale)
        {
            return new FireballSprite(this.fireball, this.fireballData, "left", location, id, scale);
        }

        public FireballSprite CreateDownLeftFireballSprite(Vector2 location, int id, int scale)
        {
            return new FireballSprite(this.fireball, this.fireballData, "down", location, id, scale);
        }

        public FireballSprite CreateUpLeftFireballSprite(Vector2 location, int id, int scale)
        {
            return new FireballSprite(this.fireball, this.fireballData, "up", location, id, scale);
        }

        // DodongoSprites
        public DodongoDownSprite CreateDownMovingDodongoSprite()
        {
            return new DodongoDownSprite(this.downDodongo, this.downDodongoData);
        }

        public DodongoUpSprite CreateUpMovingDodongoSprite()
        {
            return new DodongoUpSprite(this.upDodongo, this.upDodongoData);
        }

        public DodongoLeftSprite CreateLeftMovingDodongoSprite()
        {
            return new DodongoLeftSprite(this.leftDodongo, this.leftDodongoData);
        }

        public DodongoRightSprite CreateRightMovingDodongoSprite()
        {
            return new DodongoRightSprite(this.rightDodongo, this.rightDodongoData);
        }

        // Old Man Sprite
        public OldManSprite CreateOldManSprite()
        {
            return new OldManSprite(this.oldMan, this.oldManData);
        }

        // Merchant Sprite
        public MerchantSprite CreateMerchantSprite()
        {
            return new MerchantSprite(this.merchant, this.merchantData);
        }

         // Enemy Death Sprite
        public DeadEnemySprite CreateDeadEnemySprite()
        {
            return new DeadEnemySprite(this.deadEnemy, this.deadEnemyData);
        }
    }
}
