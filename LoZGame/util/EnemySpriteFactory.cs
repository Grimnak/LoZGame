namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class EnemySpriteFactory
    {
        private static readonly int dodongoWidthUpDown = 32;
        private static readonly int dodongoWidthLeftRight = 64;
        private static readonly int dodongoHeight = 32;

        private static readonly int dragonWidth = 50;
        private static readonly int dragonHeight = 70;

        private static readonly int gelWidth = 15;
        private static readonly int gelHeight = 15;

        private static readonly int goriyaWidth = 25;
        private static readonly int goriyaHeight = 30;

        private static readonly int keeseWidth = 20;
        private static readonly int keeseHeight = 20;

        private static readonly int merchantWidth = 25;
        private static readonly int merchantHeight = 25;

        private static readonly int oldManWidth = 30;
        private static readonly int oldManHeight = 30;

        private static readonly int ropeWidth = 25;
        private static readonly int ropeHeight = 25;

        private static readonly int spikeCrossWidth = 25;
        private static readonly int spikeCrossHeight = 25;

        private static readonly int stalfosWidth = 30;
        private static readonly int stalfosHeight = 35;

        private static readonly int wallMasterWidth = 25;
        private static readonly int wallMasterHeight = 25;

        private static readonly int zolWidth = 25;
        private static readonly int zolHeight = 25;

        public static int GetEnemyWidth(IEnemy enemy)
        {
            if (enemy is Dodongo)
            {
                // doesn't account for state yet
                return dodongoWidthLeftRight;
            }
            else if (enemy is Dragon)
            {
                return dragonWidth;
            }
            else if (enemy is Gel)
            {
                return gelWidth;
            }
            else if (enemy is Goriya)
            {
                return goriyaWidth;
            }
            else if (enemy is Keese)
            {
                return keeseWidth;
            }
            else if (enemy is Merchant)
            {
                return merchantWidth;
            }
            else if (enemy is OldMan)
            {
                return oldManWidth;
            }
            else if (enemy is Rope)
            {
                return ropeWidth;
            }
            else if (enemy is SpikeCross)
            {
                return spikeCrossWidth;
            }
            else if (enemy is Stalfos)
            {
                return stalfosWidth;
            }
            else if (enemy is WallMaster)
            {
                return wallMasterWidth;
            }
            else if (enemy is Zol)
            {
                return zolWidth;
            }
            else
            {
                return 0;
            }
        }

        public static int GetEnemyHeight(IEnemy enemy)
        {
            if (enemy is Dodongo)
            {
                return dodongoHeight;
            }
            else if (enemy is Dragon)
            {
                return dragonHeight;
            }
            else if (enemy is Gel)
            {
                return gelHeight;
            }
            else if (enemy is Goriya)
            {
                return goriyaHeight;
            }
            else if (enemy is Keese)
            {
                return keeseHeight;
            }
            else if (enemy is Merchant)
            {
                return merchantHeight;
            }
            else if (enemy is OldMan)
            {
                return oldManHeight;
            }
            else if (enemy is Rope)
            {
                return ropeHeight;
            }
            else if (enemy is SpikeCross)
            {
                return spikeCrossHeight;
            }
            else if (enemy is Stalfos)
            {
                return stalfosHeight;
            }
            else if (enemy is WallMaster)
            {
                return wallMasterHeight;
            }
            else if (enemy is Zol)
            {
                return zolHeight;
            }
            else
            {
                return 0;
            }
        }

        private Texture2D stalfos;
        private readonly SpriteSheetData stalfosData = new SpriteSheetData("stalfos", stalfosWidth, stalfosHeight, 2, 1);

        private Texture2D downGoriya;
        private readonly SpriteSheetData downGoriyaData = new SpriteSheetData("redGoriyaDown", goriyaWidth, goriyaHeight, 2, 1);
        private Texture2D upGoriya;
        private readonly SpriteSheetData upGoriyaData = new SpriteSheetData("redGoriyaUp", goriyaWidth, goriyaHeight, 2, 1);
        private Texture2D leftGoriya;
        private readonly SpriteSheetData leftGoriyaData = new SpriteSheetData("redGoriyaLeft", goriyaWidth, goriyaHeight, 2, 1);
        private Texture2D rightGoriya;
        private readonly SpriteSheetData rightGoriyaData = new SpriteSheetData("redGoriyaRight", goriyaWidth, goriyaHeight, 2, 1);

        private Texture2D leftWallMaster;
        private readonly SpriteSheetData leftWallMasterData = new SpriteSheetData("wallMasterLeft", wallMasterWidth, wallMasterHeight, 2, 1);
        private Texture2D rightWallMaster;
        private readonly SpriteSheetData rightWallMasterData = new SpriteSheetData("wallMasterRight", wallMasterWidth, wallMasterHeight, 2, 1);

        private Texture2D leftRope;
        private readonly SpriteSheetData leftRopeData = new SpriteSheetData("ropeLeft", ropeWidth, ropeHeight, 2, 1);
        private Texture2D rightRope;
        private readonly SpriteSheetData rightRopeData = new SpriteSheetData("ropeRight", ropeWidth, ropeHeight, 2, 1);

        private Texture2D gel;
        private readonly SpriteSheetData gelData = new SpriteSheetData("tealGel", gelWidth, gelHeight, 2, 1);
        private Texture2D zol;
        private readonly SpriteSheetData zolData = new SpriteSheetData("grayXol", gelWidth, gelHeight, 2, 1);

        private Texture2D spikeCross;
        private readonly SpriteSheetData spikeCrossData = new SpriteSheetData("spike", spikeCrossWidth, spikeCrossHeight, 1, 1);

        private Texture2D keese;
        private readonly SpriteSheetData keeseData = new SpriteSheetData("keese", keeseWidth, keeseHeight, 2, 1);

        private Texture2D dragon;
        private readonly SpriteSheetData dragonData = new SpriteSheetData("aquamentus", dragonWidth, dragonHeight, 1, 4);
        private Texture2D damagedDragon;
        private readonly SpriteSheetData damagedDragonData = new SpriteSheetData("damagedAqua", dragonWidth, dragonHeight, 1, 4);
        private Texture2D fireball;
        private readonly SpriteSheetData fireballData = new SpriteSheetData("fireball", 12, 12, 1, 4);

        private Texture2D downDodongo;
        private readonly SpriteSheetData downDodongoData = new SpriteSheetData("dodongoDown", dodongoWidthUpDown, dodongoHeight, 1, 3);
        private Texture2D upDodongo;
        private readonly SpriteSheetData upDodongoData = new SpriteSheetData("dodongoUp", dodongoWidthUpDown, dodongoHeight, 1, 3);
        private Texture2D leftDodongo;
        private readonly SpriteSheetData leftDodongoData = new SpriteSheetData("dodongoLeft", dodongoWidthLeftRight, dodongoHeight, 1, 3);
        private Texture2D rightDodongo;
        private readonly SpriteSheetData rightDodongoData = new SpriteSheetData("dodongoRight", dodongoWidthLeftRight, dodongoHeight, 1, 3);

        private Texture2D oldMan;
        private readonly SpriteSheetData oldManData = new SpriteSheetData("oldMan", oldManWidth, oldManHeight, 1, 1);
        private Texture2D merchant;
        private readonly SpriteSheetData merchantData = new SpriteSheetData("merchant", merchantWidth, merchantHeight, 1, 1);

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

        // Rope Sprites
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

        // Spike Cross Sprites
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

        // Dodongo Sprites
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

        // Old Man Sprites
        public OldManSprite CreateOldManSprite()
        {
            return new OldManSprite(this.oldMan, this.oldManData);
        }

        // Merchant Sprites
        public MerchantSprite CreateMerchantSprite()
        {
            return new MerchantSprite(this.merchant, this.merchantData);
        }

         // Enemy Death Sprites
        public DeadEnemySprite CreateDeadEnemySprite()
        {
            return new DeadEnemySprite(this.deadEnemy, this.deadEnemyData);
        }
    }
}