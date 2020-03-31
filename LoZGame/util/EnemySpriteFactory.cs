namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class EnemySpriteFactory
    {
        private static readonly int dodongoWidthUpDown = 40;
        private static readonly int dodongoWidthLeftRight = 64;
        private static readonly int dodongoHeight = 50;

        private static readonly int dragonWidth = 68;
        private static readonly int dragonHeight = 100;

        private static readonly int gelWidth = 25;
        private static readonly int gelHeight = 25;

        private static readonly int goriyaWidth = 35;
        private static readonly int goriyaHeight = 46;

        private static readonly int keeseWidth = 48;
        private static readonly int keeseHeight = 32;

        private static readonly int merchantWidth = 48;
        private static readonly int merchantHeight = 54;

        private static readonly int oldManWidth = 48;
        private static readonly int oldManHeight = 54;

        private static readonly int ropeWidth = 25;
        private static readonly int ropeHeight = 25;

        private static readonly int spikeCrossWidth = 48;
        private static readonly int spikeCrossHeight = 48;

        private static readonly int stalfosWidth = 48;
        private static readonly int stalfosHeight = 54;

        private static readonly int wallMasterWidth = 35;
        private static readonly int wallMasterHeight = 45;

        private static readonly int zolWidth = 40;
        private static readonly int zolHeight = 50;

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
        private SpriteData stalfosData;

        private Texture2D downGoriya;
        private SpriteData downGoriyaData;
        private Texture2D upGoriya;
        private SpriteData upGoriyaData;
        private Texture2D leftGoriya;
        private SpriteData leftGoriyaData;
        private Texture2D rightGoriya;
        private SpriteData rightGoriyaData;

        private Texture2D leftWallMaster;
        private SpriteData leftWallMasterData;
        private Texture2D rightWallMaster;
        private SpriteData rightWallMasterData;

        private Texture2D leftRope;
        private SpriteData leftRopeData;
        private Texture2D rightRope;
        private SpriteData rightRopeData;

        private Texture2D gel;
        private SpriteData gelData;
        private Texture2D zol;
        private SpriteData zolData;

        private Texture2D spikeCross;
        private SpriteData spikeCrossData;

        private Texture2D keese;
        private SpriteData keeseData;

        private Texture2D dragon;
        private SpriteData dragonData;
        private Texture2D damagedDragon;
        private SpriteData damagedDragonData;
        private Texture2D fireball;
        private SpriteData fireballData;

        private Texture2D downDodongo;
        private SpriteData downDodongoData;
        private Texture2D upDodongo;
        private SpriteData upDodongoData;
        private Texture2D leftDodongo;
        private SpriteData leftDodongoData;
        private Texture2D rightDodongo;
        private SpriteData rightDodongoData;

        private Texture2D oldMan;
        private SpriteData oldManData;
        private Texture2D merchant;
        private SpriteData merchantData;

        private Texture2D deadEnemy;
        private SpriteData deadEnemyData;

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
            this.LoadTextures(content);
            this.LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            this.stalfos = content.Load<Texture2D>("stalfos");

            this.downGoriya = content.Load<Texture2D>("redGoriyaDown");
            this.upGoriya = content.Load<Texture2D>("redGoriyaUp");
            this.leftGoriya = content.Load<Texture2D>("redGoriyaLeft");
            this.rightGoriya = content.Load<Texture2D>("redGoriyaRight");

            this.leftWallMaster = content.Load<Texture2D>("wallMasterLeft");
            this.rightWallMaster = content.Load<Texture2D>("wallMasterRight");

            this.leftRope = content.Load<Texture2D>("ropeLeft");
            this.rightRope = content.Load<Texture2D>("ropeRight");

            this.gel = content.Load<Texture2D>("tealGel");
            this.zol = content.Load<Texture2D>("grayZol");

            this.spikeCross = content.Load<Texture2D>("spike");

            this.keese = content.Load<Texture2D>("keese");

            this.dragon = content.Load<Texture2D>("aquamentus");
            this.damagedDragon = content.Load<Texture2D>("damagedAqua");

            this.downDodongo = content.Load<Texture2D>("dodongoDown");
            this.upDodongo = content.Load<Texture2D>("dodongoUp");
            this.leftDodongo = content.Load<Texture2D>("dodongoLeft");
            this.rightDodongo = content.Load<Texture2D>("dodongoRight");

            this.oldMan = content.Load<Texture2D>("oldMan");
            this.merchant = content.Load<Texture2D>("merchant");

            this.deadEnemy = content.Load<Texture2D>("enemyDeath");
        }

        private void LoadData()
        {
            this.stalfosData = new SpriteData(new Vector2(stalfosWidth, stalfosHeight), stalfos, 2, 1);
            this.downGoriyaData = new SpriteData(new Vector2(goriyaWidth, goriyaHeight), downGoriya, 2, 1);
            this.upGoriyaData = new SpriteData(new Vector2(goriyaWidth, goriyaHeight), upGoriya, 2, 1);
            this.leftGoriyaData = new SpriteData(new Vector2(goriyaWidth, goriyaHeight), leftGoriya, 2, 1);
            this.rightGoriyaData = new SpriteData(new Vector2(goriyaWidth, goriyaHeight), rightGoriya, 2, 1);
            this.leftWallMasterData = new SpriteData(new Vector2(wallMasterWidth, wallMasterHeight), leftWallMaster, 2, 1);
            this.rightWallMasterData = new SpriteData(new Vector2(wallMasterWidth, wallMasterHeight), rightWallMaster, 2, 1);
            this.leftRopeData = new SpriteData(new Vector2(ropeWidth, ropeHeight), leftRope, 2, 1);
            this.rightRopeData = new SpriteData(new Vector2(ropeWidth, ropeHeight), rightRope, 2, 1);
            this.gelData = new SpriteData(new Vector2(gelWidth, gelHeight), gel, 2, 1);
            this.zolData = new SpriteData(new Vector2(gelWidth, gelHeight), zol, 2, 1);
            this.spikeCrossData = new SpriteData(new Vector2(spikeCrossWidth, spikeCrossHeight), spikeCross, 1, 1);
            this.keeseData = new SpriteData(new Vector2(keeseWidth, keeseHeight), keese, 2, 1);
            this.dragonData = new SpriteData(new Vector2(dragonWidth, dragonHeight), dragon, 1, 4);
            this.damagedDragonData = new SpriteData(new Vector2(dragonWidth, dragonHeight), damagedDragon, 1, 4);
            this.downDodongoData = new SpriteData(new Vector2(dodongoWidthUpDown, dodongoHeight), downDodongo, 1, 3);
            this.upDodongoData = new SpriteData(new Vector2(dodongoWidthUpDown, dodongoHeight), upDodongo, 1, 3);
            this.leftDodongoData = new SpriteData(new Vector2(dodongoWidthLeftRight, dodongoHeight), leftDodongo, 1, 3);
            this.rightDodongoData = new SpriteData(new Vector2(dodongoWidthLeftRight, dodongoHeight), rightDodongo, 1, 3);
            this.oldManData = new SpriteData(new Vector2(oldManWidth, oldManHeight), oldMan, 1, 1);
            this.merchantData = new SpriteData(new Vector2(merchantWidth, merchantHeight), merchant, 1, 1);
            this.deadEnemyData = new SpriteData(new Vector2(40, 40), deadEnemy, 1, 6);
        }

        // Stalfos Sprites
        public ISprite CreateStalfosSprite()
        {
            return new Sprite(this.stalfos, this.stalfosData);
        }

        // Goriya Sprites
        public ISprite CreateDownMovingGoriyaSprite()
        {
            return new Sprite(this.downGoriya, this.downGoriyaData);
        }

        public ISprite CreateUpMovingGoriyaSprite()
        {
            return new Sprite(this.upGoriya, this.upGoriyaData);
        }

        public ISprite CreateLeftMovingGoriyaSprite()
        {
            return new Sprite(this.leftGoriya, this.leftGoriyaData);
        }

        public ISprite CreateRightMovingGoriyaSprite()
        {
            return new Sprite(this.rightGoriya, this.rightGoriyaData);
        }

        // Wallmaster Sprites
        public ISprite CreateLeftMovingWallMasterSprite()
        {
            return new Sprite(this.leftWallMaster, this.leftWallMasterData);
        }

        public ISprite CreateRightMovingWallMasterSprite()
        {
            return new Sprite(this.rightWallMaster, this.rightWallMasterData);
        }

        public ISprite CreateAttackingWallMasterSprite()
        {
            return new Sprite(this.leftWallMaster, this.leftWallMasterData);
        }

        // Rope Sprites
        public ISprite CreateLeftMovingRopeSprite()
        {
            return new Sprite(this.leftRope, this.leftRopeData);
        }

        public ISprite CreateRightMovingRopeSprite()
        {
            return new Sprite(this.rightRope, this.rightRopeData);
        }

        // Gel Sprites
        public ISprite CreateGelSprite()
        {
            return new Sprite(this.gel, this.gelData);
        }

        // Zol Sprites
        public ISprite CreateZolSprite()
        {
            return new Sprite(this.zol, this.zolData);
        }

        // Spike Cross Sprites
        public ISprite CreateSpikeCrossSprite()
        {
            return new Sprite(this.spikeCross, this.spikeCrossData);
        }

        // Keese Sprites
        public ISprite CreateKeeseSprite()
        {
            return new Sprite(this.keese, this.keeseData);
        }

        // Dragon Sprites
        public ISprite CreateDragonSprite()
        {
            return new Sprite(this.dragon, this.dragonData);
        }

        public ISprite CreateDamagedDragonSprite()
        {
            return new Sprite(this.damagedDragon, this.damagedDragonData);
        }

        // Dodongo Sprites
        public ISprite CreateDownMovingDodongoSprite()
        {
            return new Sprite(this.downDodongo, this.downDodongoData);
        }

        public ISprite CreateUpMovingDodongoSprite()
        {
            return new Sprite(this.upDodongo, this.upDodongoData);
        }

        public ISprite CreateLeftMovingDodongoSprite()
        {
            return new Sprite(this.leftDodongo, this.leftDodongoData);
        }

        public ISprite CreateRightMovingDodongoSprite()
        {
            return new Sprite(this.rightDodongo, this.rightDodongoData);
        }

        // Old Man Sprites
        public ISprite CreateOldManSprite()
        {
            return new Sprite(this.oldMan, this.oldManData);
        }

        // Merchant Sprites
        public ISprite CreateMerchantSprite()
        {
            return new Sprite(this.merchant, this.merchantData);
        }

         // Enemy Death Sprites
        public ISprite CreateDeadEnemySprite()
        {
            return new Sprite(this.deadEnemy, this.deadEnemyData);
        }
    }
}