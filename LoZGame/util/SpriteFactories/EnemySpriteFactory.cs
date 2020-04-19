namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class EnemySpriteFactory
    {
        private static readonly int dodongoWidthDown = 60;
        private static readonly int dodongoWidthUp = 60;
        private static readonly int dodongoWidthLeftRight = 96;

        private static readonly int dodongoHeight = 32;

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

        private static readonly int ropeWidth = 40;
        private static readonly int ropeHeight = 40;

        private static readonly int spikeCrossWidth = 48;
        private static readonly int spikeCrossHeight = 48;

        private static readonly int stalfosWidth = 48;
        private static readonly int stalfosHeight = 54;

        private static readonly int wallMasterWidth = 35;
        private static readonly int wallMasterHeight = 45;

        private static readonly int zolWidth = 40;
        private static readonly int zolHeight = 40;

        private static readonly int fireSnakeWidth = 28;
        private static readonly int fireSnakeHeight = 35;

        private static readonly int darknutWidth = 48;
        private static readonly int darknutHeight = 54;

        private static readonly int vireWidth = 42;
        private static readonly int vireHeight = 40;

        private static readonly int ManhandlaBodyHeight = 64;
        private static readonly int ManhandlaBodyWidth = 64;

        private static readonly int ManhandlaHeadHeight = 48;
        private static readonly int ManhandlaHeadWidth = 48;

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
            else if (enemy is Goriya || enemy is BlueGoriya)
            {
                return goriyaWidth;
            }
            else if (enemy is Keese || enemy is VireKeese)
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
            else if (enemy is FireSnakeHead || enemy is FireSnakeSegment)
            {
                return fireSnakeWidth;
            }
            else if (enemy is Darknut)
            {
                return darknutWidth;
            }
            else if (enemy is Vire)
            {
                return vireWidth;
            }
            else if (enemy is ManhandlaBody)
            {
                return ManhandlaBodyWidth;
            }
            else if (enemy is ManhandlaHead)
            {
                return ManhandlaHeadWidth;
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
            else if (enemy is Goriya || enemy is BlueGoriya)
            {
                return goriyaHeight;
            }
            else if (enemy is Keese || enemy is VireKeese)
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
            else if (enemy is FireSnakeHead || enemy is FireSnakeSegment)
            {
                return fireSnakeHeight;
            }
            else if (enemy is Darknut)
            {
                return darknutHeight;
            }
            else if (enemy is Vire)
            {
                return vireHeight;
            }
            else if (enemy is ManhandlaBody)
            {
                return ManhandlaBodyHeight;
            }
            else if (enemy is ManhandlaHead)
            {
                return ManhandlaHeadHeight;
            }
            else
            {
                return 0;
            }
        }

        private Texture2D manhandlaBodyTexture;
        private SpriteData manhandlaBodyData;
        private Texture2D manhandlaHeadCloseLeftTexture;
        private Texture2D manhandlaHeadOpenLeftTexture;
        private Texture2D manhandlaHeadCloseRightTexture;
        private Texture2D manhandlaHeadOpenRightTexture;
        private Texture2D manhandlaHeadCloseUpTexture;
        private Texture2D manhandlaHeadOpenUpTexture;
        private Texture2D manhandlaHeadCloseDownTexture;
        private Texture2D manhandlaHeadOpenDownTexture;
        private SpriteData manhandlaHeadData;

        private Texture2D stalfos;
        private SpriteData stalfosData;

        private Texture2D downGoriya;
        private Texture2D downBlueGoriya;
        private SpriteData downGoriyaData;
        private Texture2D upGoriya;
        private Texture2D upBlueGoriya;
        private SpriteData upGoriyaData;
        private Texture2D leftGoriya;
        private Texture2D leftBlueGoriya;
        private SpriteData leftGoriyaData;
        private Texture2D rightGoriya;
        private Texture2D rightBlueGoriya;
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
        private Texture2D downVire;
        private SpriteData downVireData;
        private Texture2D upVire;
        private SpriteData upVireData;
        private Texture2D vireKeese;
        private SpriteData vireKeeseData;

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

        private SpriteData attackingDownDodongoData;
        private SpriteData attackingUpDodongoData;
        private SpriteData attackingLeftDodongoData;
        private SpriteData attackingRightDodongoData;

        private Texture2D fireSnake;
        private SpriteData fireSnakeData;

        private Texture2D upDarknut;
        private SpriteData upDarknutData;
        private Texture2D downDarknut;
        private SpriteData downDarknutData;
        private Texture2D leftDarknut;
        private SpriteData leftDarknutData;
        private Texture2D rightDarknut;
        private SpriteData rightDarknutData;

        private Texture2D oldMan;
        private Texture2D angryOldMan;
        private SpriteData oldManData;
        private Texture2D merchant;
        private SpriteData merchantData;

        private Texture2D spawnEnemy;
        private SpriteData spawnEnemyData;
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
            this.manhandlaBodyTexture = content.Load<Texture2D>("man_body");
            this.manhandlaHeadOpenLeftTexture = content.Load<Texture2D>("man_head_left_open");
            this.manhandlaHeadCloseLeftTexture = content.Load<Texture2D>("man_head_left_closed");
            this.manhandlaHeadOpenRightTexture = content.Load<Texture2D>("man_head_right_open");
            this.manhandlaHeadCloseRightTexture = content.Load<Texture2D>("man_head_right_closed");
            this.manhandlaHeadOpenDownTexture = content.Load<Texture2D>("man_head_down_open");
            this.manhandlaHeadCloseDownTexture = content.Load<Texture2D>("man_head_down_closed");
            this.manhandlaHeadOpenUpTexture = content.Load<Texture2D>("man_head_up_open");
            this.manhandlaHeadCloseUpTexture = content.Load<Texture2D>("man_head_up_closed");

            this.stalfos = content.Load<Texture2D>("stalfos");

            this.downGoriya = content.Load<Texture2D>("redGoriyaDown");
            this.upGoriya = content.Load<Texture2D>("redGoriyaUp");
            this.leftGoriya = content.Load<Texture2D>("redGoriyaLeft");
            this.rightGoriya = content.Load<Texture2D>("redGoriyaRight");

            this.downBlueGoriya = content.Load<Texture2D>("blueGoriyaDown");
            this.upBlueGoriya = content.Load<Texture2D>("blueGoriyaUp");
            this.leftBlueGoriya = content.Load<Texture2D>("blueGoriyaLeft");
            this.rightBlueGoriya = content.Load<Texture2D>("blueGoriyaRight");

            this.leftWallMaster = content.Load<Texture2D>("wallMasterLeft");
            this.rightWallMaster = content.Load<Texture2D>("wallMasterRight");

            this.leftRope = content.Load<Texture2D>("ropeLeft");
            this.rightRope = content.Load<Texture2D>("ropeRight");

            this.gel = content.Load<Texture2D>("tealGel");
            this.zol = content.Load<Texture2D>("greenZol");

            this.spikeCross = content.Load<Texture2D>("spike");

            this.keese = content.Load<Texture2D>("keese");
            this.downVire = content.Load<Texture2D>("vire_down");
            this.upVire = content.Load<Texture2D>("vire_up");
            this.vireKeese = content.Load<Texture2D>("vire_keese");

            this.dragon = content.Load<Texture2D>("aquamentus");
            this.damagedDragon = content.Load<Texture2D>("damagedAqua");

            this.downDodongo = content.Load<Texture2D>("dodongoDown");
            this.upDodongo = content.Load<Texture2D>("dodongoUp");
            this.leftDodongo = content.Load<Texture2D>("dodongoLeft");
            this.rightDodongo = content.Load<Texture2D>("dodongoRight");

            this.fireSnake = content.Load<Texture2D>("fireball");

            this.upDarknut = content.Load<Texture2D>("red_darknut_up");
            this.downDarknut = content.Load<Texture2D>("red_darknut_down");
            this.leftDarknut = content.Load<Texture2D>("red_darknut_left");
            this.rightDarknut = content.Load<Texture2D>("red_darknut_right");

            this.oldMan = content.Load<Texture2D>("oldMan");
            this.angryOldMan = content.Load<Texture2D>("angryOldMan");
            this.merchant = content.Load<Texture2D>("merchant");

            this.spawnEnemy = content.Load<Texture2D>("enemySpawn");
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
            this.zolData = new SpriteData(new Vector2(zolWidth, zolHeight), zol, 2, 1);
            this.spikeCrossData = new SpriteData(new Vector2(spikeCrossWidth, spikeCrossHeight), spikeCross, 1, 1);
            this.keeseData = new SpriteData(new Vector2(keeseWidth, keeseHeight), keese, 2, 1);
            this.dragonData = new SpriteData(new Vector2(dragonWidth, dragonHeight), dragon, 1, 4);
            this.damagedDragonData = new SpriteData(new Vector2(dragonWidth, dragonHeight), damagedDragon, 1, 4);
            this.downDodongoData = new SpriteData(new Vector2(dodongoWidthDown, dodongoHeight), downDodongo, 1, 3);
            this.upDodongoData = new SpriteData(new Vector2(dodongoWidthUp, dodongoHeight), upDodongo, 1, 3);
            this.leftDodongoData = new SpriteData(new Vector2(dodongoWidthLeftRight, dodongoHeight), leftDodongo, 1, 3);
            this.rightDodongoData = new SpriteData(new Vector2(dodongoWidthLeftRight, dodongoHeight), rightDodongo, 1, 3);
            this.upDarknutData = new SpriteData(new Vector2(darknutWidth, darknutHeight), upDarknut, 2, 1);
            this.downDarknutData = new SpriteData(new Vector2(darknutWidth, darknutHeight), downDarknut, 2, 1);
            this.leftDarknutData = new SpriteData(new Vector2(darknutWidth, darknutHeight), leftDarknut, 2, 1);
            this.rightDarknutData = new SpriteData(new Vector2(darknutWidth, darknutHeight), rightDarknut, 2, 1);
            this.fireSnakeData = new SpriteData(new Vector2(fireSnakeWidth, fireSnakeHeight), fireSnake, 1, 4);
            this.oldManData = new SpriteData(new Vector2(oldManWidth, oldManHeight), oldMan, 1, 1);
            this.merchantData = new SpriteData(new Vector2(merchantWidth, merchantHeight), merchant, 1, 1);
            this.spawnEnemyData = new SpriteData(new Vector2(40, 40), spawnEnemy, 3, 1);
            this.deadEnemyData = new SpriteData(new Vector2(40, 40), deadEnemy, 1, 6);
            this.downVireData = new SpriteData(new Vector2(vireWidth, vireHeight), downVire, 2, 1);
            this.upVireData = new SpriteData(new Vector2(vireWidth, vireHeight), upVire, 2, 1);
            this.vireKeeseData = new SpriteData(new Vector2(keeseWidth, keeseHeight), vireKeese, 2, 1);

            this.manhandlaBodyData = new SpriteData(new Vector2(ManhandlaBodyWidth, ManhandlaBodyHeight), manhandlaBodyTexture, 1, 1);
            this.manhandlaHeadData = new SpriteData(new Vector2(ManhandlaHeadWidth, ManhandlaHeadHeight), manhandlaHeadCloseDownTexture, 1, 1);
        }

        // Stalfos Sprites
        public ISprite CreateStalfosSprite()
        {
            return new ObjectSprite(this.stalfos, this.stalfosData);
        }
        
        // Firesnake sprites
        public ISprite CreateFireSnakeSprite()
        {
            return new ObjectSprite(this.fireSnake, this.fireSnakeData);
        }

        // Darknut Sprites
        public ISprite CreateDarknutSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(this.upDarknut, this.upDarknutData);
                case Physics.Direction.South:
                    return new ObjectSprite(this.downDarknut, this.downDarknutData);
                case Physics.Direction.East:
                    return new ObjectSprite(this.rightDarknut, this.rightDarknutData);
                default:
                    return new ObjectSprite(this.leftDarknut, this.leftDarknutData);
            }
        }

        // Goriya Sprites
        public ISprite CreateGoriyaSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(this.upGoriya, this.upGoriyaData);
                case Physics.Direction.South:
                    return new ObjectSprite(this.downGoriya, this.downGoriyaData);
                case Physics.Direction.East:
                    return new ObjectSprite(this.rightGoriya, this.rightGoriyaData);
                default:
                    return new ObjectSprite(this.leftGoriya, this.leftGoriyaData);
            }
        }

        public ISprite CreateBlueGoriyaSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(this.upBlueGoriya, this.upGoriyaData);
                case Physics.Direction.South:
                    return new ObjectSprite(this.downBlueGoriya, this.downGoriyaData);
                case Physics.Direction.East:
                    return new ObjectSprite(this.rightBlueGoriya, this.rightGoriyaData);
                default:
                    return new ObjectSprite(this.leftBlueGoriya, this.leftGoriyaData);
            }
        }

        public ISprite CreateManhandlaBodySprite()
        {
            return new ObjectSprite(this.manhandlaBodyTexture, this.manhandlaBodyData);
        }

        public ISprite CreateManhandleHeadClosedSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(this.manhandlaHeadCloseUpTexture, this.manhandlaHeadData);
                case Physics.Direction.South:
                    return new ObjectSprite(this.manhandlaHeadCloseDownTexture, this.manhandlaHeadData);
                case Physics.Direction.East:
                    return new ObjectSprite(this.manhandlaHeadCloseRightTexture, this.manhandlaHeadData);
                default:
                    return new ObjectSprite(this.manhandlaHeadCloseLeftTexture, this.manhandlaHeadData);
            }
        }

        public ISprite CreateManhandlaHeadOpenSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(this.manhandlaHeadOpenUpTexture, this.manhandlaHeadData);
                case Physics.Direction.South:
                    return new ObjectSprite(this.manhandlaHeadOpenDownTexture, this.manhandlaHeadData);
                case Physics.Direction.East:
                    return new ObjectSprite(this.manhandlaHeadOpenRightTexture, this.manhandlaHeadData);
                default:
                    return new ObjectSprite(this.manhandlaHeadOpenLeftTexture, this.manhandlaHeadData);
            }
        }

        // Wallmaster Sprites
        public ISprite CreateLeftMovingWallMasterSprite()
        {
            return new ObjectSprite(this.leftWallMaster, this.leftWallMasterData);
        }

        public ISprite CreateRightMovingWallMasterSprite()
        {
            return new ObjectSprite(this.rightWallMaster, this.rightWallMasterData);
        }

        public ISprite CreateAttackingWallMasterSprite()
        {
            return new ObjectSprite(this.leftWallMaster, this.leftWallMasterData);
        }

        // Rope Sprites
        public ISprite CreateLeftMovingRopeSprite()
        {
            return new ObjectSprite(this.leftRope, this.leftRopeData);
        }

        public ISprite CreateRightMovingRopeSprite()
        {
            return new ObjectSprite(this.rightRope, this.rightRopeData);
        }

        // Gel Sprites
        public ISprite CreateGelSprite()
        {
            return new ObjectSprite(this.gel, this.gelData);
        }

        // Zol Sprites
        public ISprite CreateZolSprite()
        {
            return new ObjectSprite(this.zol, this.zolData);
        }

        // Spike Cross Sprites
        public ISprite CreateSpikeCrossSprite()
        {
            return new ObjectSprite(this.spikeCross, this.spikeCrossData);
        }

        // Keese Sprites
        public ISprite CreateKeeseSprite()
        {
            return new ObjectSprite(this.keese, this.keeseData);
        }

        // Dragon Sprites
        public ISprite CreateDragonSprite()
        {
            return new ObjectSprite(this.dragon, this.dragonData);
        }

        public ISprite CreateDamagedDragonSprite()
        {
            return new ObjectSprite(this.damagedDragon, this.damagedDragonData);
        }

        // Dodongo Sprites
        public ISprite CreateDownMovingDodongoSprite()
        {
            return new ObjectSprite(this.downDodongo, this.downDodongoData);
        }

        public ISprite CreateUpMovingDodongoSprite()
        {
            return new ObjectSprite(this.upDodongo, this.upDodongoData);
        }

        public ISprite CreateLeftMovingDodongoSprite()
        {
            return new ObjectSprite(this.leftDodongo, this.leftDodongoData);
        }

        public ISprite CreateRightMovingDodongoSprite()
        {
            return new ObjectSprite(this.rightDodongo, this.rightDodongoData);
        }

        // Old Man Sprites
        public ISprite CreateOldManSprite()
        {
            return new ObjectSprite(this.oldMan, this.oldManData);
        }

        public ISprite CreateAngryOldManSprite()
        {
            return new ObjectSprite(this.angryOldMan, this.oldManData);
        }

        // Merchant Sprites
        public ISprite CreateMerchantSprite()
        {
            return new ObjectSprite(this.merchant, this.merchantData);
        }

        public ISprite CreateDownMovingVireSprite()
        {
            return new ObjectSprite(this.downVire, this.downVireData);
        }

        public ISprite CreateUpMovingVireSprite()
        {
            return new ObjectSprite(this.upVire, this.upVireData);
        }

        public ISprite CreateVireKeeseSprite()
        {
            return new ObjectSprite(this.vireKeese, this.vireKeeseData);
        }

        // Enemy Spawn Sprites
        public ISprite CreateEnemySpawn()
        {
            return new ObjectSprite(this.spawnEnemy, this.spawnEnemyData);
        }

        // Enemy Death Sprites
        public ISprite CreateDeadEnemySprite()
        {
            return new ObjectSprite(this.deadEnemy, this.deadEnemyData);
        }
    }
}