﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class EnemySpriteFactory
    {
        private static readonly int dodongoWidthDown = 60;
        private static readonly int dodongoWidthUp = 60;
        private static readonly int dodongoWidthLeftRight = 96;

        private static readonly int GleeockBodyWidth = 96;
        private static readonly int GleeockBodyHeight = 128;

        private static readonly int GleeockHeadWidth = 24;
        private static readonly int GleeockHeadHeight = 48;

        private static readonly int GleeockHeadOffWidth = 30;
        private static readonly int GleeockHeadOffHeight = 52;

        private static readonly int GleeockNeckWidth = 24;
        private static readonly int GleeockNeckHeight = 32;

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

        private static readonly int gibdoWidth = 48;
        private static readonly int gibdoHeight = 54;

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

        private static readonly int bubbleWidth = 40;
        private static readonly int bubbleHeight = 40;
      
        private static readonly int ManhandlaBodyHeight = 64;
        private static readonly int ManhandlaBodyWidth = 64;

        private static readonly int ManhandlaHeadHeight = 48;
        private static readonly int ManhandlaHeadWidth = 48;

        private static readonly int likelikeWidth = 40;
        private static readonly int likelikeHeight = 40;

        private static readonly int PolsVoiceWidth = 40;
        private static readonly int PolsVoiceHeight = 40;

        public static int GetEnemyWidth(IEnemy enemy)
        {
            if (enemy is Dodongo)
            {
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
            else if (enemy is RedGoriya || enemy is BlueGoriya)
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
            else if (enemy is Gibdo)
            {
                return gibdoWidth;
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
            else if (enemy is RedDarknut || enemy is BlueDarknut)
            {
                return darknutWidth;
            }
            else if (enemy is Vire)
            {
                return vireWidth;
            }
            else if (enemy is Bubble)
            {
                return bubbleWidth;
            }
            else if (enemy is ManhandlaBody)
            {
                return ManhandlaBodyWidth;
            }
            else if (enemy is ManhandlaHead)
            {
                return ManhandlaHeadWidth;
            }
            else if (enemy is GleeokBody)
            {
                return GleeockBodyWidth;
            }
            else if (enemy is GleeokHead)
            {
                return GleeockHeadWidth;
            }
            else if (enemy is GleeokHeadOff)
            {
                return GleeockHeadOffWidth;
            }
            else if (enemy is GleeokNeck)
            {
                return GleeockNeckWidth;
            }
            else if (enemy is Likelike)
            {
                return likelikeWidth;
            }
            else if (enemy is PolsVoice)
            {
                return PolsVoiceWidth;
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
            else if (enemy is RedGoriya || enemy is BlueGoriya)
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
            else if (enemy is Gibdo)
            {
                return gibdoHeight;
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
            else if (enemy is RedDarknut || enemy is BlueDarknut)
            {
                return darknutHeight;
            }
            else if (enemy is Vire)
            {
                return vireHeight;
            }
            else if (enemy is Bubble)
            {
                return bubbleHeight;
            }
            else if (enemy is ManhandlaBody)
            {
                return ManhandlaBodyHeight;
            }
            else if (enemy is ManhandlaHead)
            {
                return ManhandlaHeadHeight;
            }
            else if (enemy is GleeokBody)
            {
                return GleeockBodyHeight;
            }
            else if (enemy is GleeokHead)
            {
                return GleeockHeadHeight;
            }
            else if (enemy is GleeokHeadOff)
            {
                return GleeockHeadOffHeight;
            }
            else if (enemy is GleeokNeck)
            {
                return GleeockNeckHeight;
            }
            else if (enemy is Likelike)
            {
                return likelikeHeight;
            }
            else if (enemy is PolsVoice)
            {
                return PolsVoiceHeight;
            }
            else
            {
                return 0;
            }
        }

        private Texture2D manhandlaBodyTexture;
        private SpriteData manhandlaBodyData;
        private Texture2D manhandlaHeadLeftTexture;
        private Texture2D manhandlaHeadRightTexture;
        private Texture2D manhandlaHeadUpTexture;
        private Texture2D manhandlaHeadDownTexture;
        private SpriteData manhandlaHeadData;

        private Texture2D GleeokBodyTexture;
        private SpriteData GleeokBodyData;
        private Texture2D GleeokHeadTexture;
        private SpriteData GleeokHeadData;
        private Texture2D GleeokHeadOffTexture;
        private SpriteData GleeokHeadOffData;
        private Texture2D GleeokNeckTexture;
        private SpriteData GleeokNeckData;

        private Texture2D stalfos;
        private SpriteData stalfosData;
        private Texture2D gibdo;
        private SpriteData gibdoData;

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

        private Texture2D bubble;
        private SpriteData bubbleData;

        private Texture2D upRedDarknut;
        private Texture2D upBlueDarknut;
        private SpriteData upDarknutData;
        private Texture2D downRedDarknut;
        private Texture2D downBlueDarknut;
        private SpriteData downDarknutData;
        private Texture2D leftRedDarknut;
        private Texture2D leftBlueDarknut;
        private SpriteData leftDarknutData;
        private Texture2D rightRedDarknut;
        private Texture2D rightBlueDarknut;
        private SpriteData rightDarknutData;

        private Texture2D likelike;
        private SpriteData likelikeData;

        private Texture2D polsVoice;
        private SpriteData polsVoiceData;

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
            LoadTextures(content);
            LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            manhandlaBodyTexture = content.Load<Texture2D>("man_body");
            manhandlaHeadLeftTexture = content.Load<Texture2D>("man_head_left");
            manhandlaHeadRightTexture = content.Load<Texture2D>("man_head_right");
            manhandlaHeadDownTexture = content.Load<Texture2D>("man_head_down");
            manhandlaHeadUpTexture = content.Load<Texture2D>("man_head_up");

            GleeokBodyTexture = content.Load<Texture2D>("gleeok_body");
            GleeokHeadOffTexture = content.Load<Texture2D>("gleeok_head_off");
            GleeokHeadTexture = content.Load<Texture2D>("gleeok_head_on");
            GleeokNeckTexture = content.Load<Texture2D>("gleeok_neck");
          
            stalfos = content.Load<Texture2D>("stalfos");
            gibdo = content.Load<Texture2D>("gibdo");

            downGoriya = content.Load<Texture2D>("redGoriyaDown");
            upGoriya = content.Load<Texture2D>("redGoriyaUp");
            leftGoriya = content.Load<Texture2D>("redGoriyaLeft");
            rightGoriya = content.Load<Texture2D>("redGoriyaRight");

            downBlueGoriya = content.Load<Texture2D>("blueGoriyaDown");
            upBlueGoriya = content.Load<Texture2D>("blueGoriyaUp");
            leftBlueGoriya = content.Load<Texture2D>("blueGoriyaLeft");
            rightBlueGoriya = content.Load<Texture2D>("blueGoriyaRight");

            leftWallMaster = content.Load<Texture2D>("wallMasterLeft");
            rightWallMaster = content.Load<Texture2D>("wallMasterRight");

            leftRope = content.Load<Texture2D>("ropeLeft");
            rightRope = content.Load<Texture2D>("ropeRight");

            gel = content.Load<Texture2D>("tealGel");
            zol = content.Load<Texture2D>("greenZol");

            spikeCross = content.Load<Texture2D>("spike");

            keese = content.Load<Texture2D>("keese");
            downVire = content.Load<Texture2D>("vire_down");
            upVire = content.Load<Texture2D>("vire_up");
            vireKeese = content.Load<Texture2D>("vire_keese");

            dragon = content.Load<Texture2D>("aquamentus");
            damagedDragon = content.Load<Texture2D>("damagedAqua");

            downDodongo = content.Load<Texture2D>("dodongoDown");
            upDodongo = content.Load<Texture2D>("dodongoUp");
            leftDodongo = content.Load<Texture2D>("dodongoLeft");
            rightDodongo = content.Load<Texture2D>("dodongoRight");

            fireSnake = content.Load<Texture2D>("fireball");

            bubble = content.Load<Texture2D>("blue_bubble");

            upRedDarknut = content.Load<Texture2D>("red_darknut_up");
            downRedDarknut = content.Load<Texture2D>("red_darknut_down");
            leftRedDarknut = content.Load<Texture2D>("red_darknut_left");
            rightRedDarknut = content.Load<Texture2D>("red_darknut_right");

            upBlueDarknut = content.Load<Texture2D>("blue_darknut_up");
            downBlueDarknut = content.Load<Texture2D>("blue_darknut_down");
            leftBlueDarknut = content.Load<Texture2D>("blue_darknut_left");
            rightBlueDarknut = content.Load<Texture2D>("blue_darknut_right");

            likelike = content.Load<Texture2D>("likelike");

            polsVoice = content.Load<Texture2D>("polsvoice");

            oldMan = content.Load<Texture2D>("oldMan");
            angryOldMan = content.Load<Texture2D>("angryOldMan");
            merchant = content.Load<Texture2D>("merchant");

            spawnEnemy = content.Load<Texture2D>("enemySpawn");
            deadEnemy = content.Load<Texture2D>("enemyDeath");
        }

        private void LoadData()
        {
            stalfosData = new SpriteData(new Vector2(stalfosWidth, stalfosHeight), stalfos, 2, 1);
            gibdoData = new SpriteData(new Vector2(gibdoWidth, gibdoHeight), gibdo, 2, 1);
            downGoriyaData = new SpriteData(new Vector2(goriyaWidth, goriyaHeight), downGoriya, 2, 1);
            upGoriyaData = new SpriteData(new Vector2(goriyaWidth, goriyaHeight), upGoriya, 2, 1);
            leftGoriyaData = new SpriteData(new Vector2(goriyaWidth, goriyaHeight), leftGoriya, 2, 1);
            rightGoriyaData = new SpriteData(new Vector2(goriyaWidth, goriyaHeight), rightGoriya, 2, 1);
            leftWallMasterData = new SpriteData(new Vector2(wallMasterWidth, wallMasterHeight), leftWallMaster, 2, 1);
            rightWallMasterData = new SpriteData(new Vector2(wallMasterWidth, wallMasterHeight), rightWallMaster, 2, 1);
            leftRopeData = new SpriteData(new Vector2(ropeWidth, ropeHeight), leftRope, 2, 1);
            rightRopeData = new SpriteData(new Vector2(ropeWidth, ropeHeight), rightRope, 2, 1);
            gelData = new SpriteData(new Vector2(gelWidth, gelHeight), gel, 2, 1);
            zolData = new SpriteData(new Vector2(zolWidth, zolHeight), zol, 2, 1);
            spikeCrossData = new SpriteData(new Vector2(spikeCrossWidth, spikeCrossHeight), spikeCross, 1, 1);
            keeseData = new SpriteData(new Vector2(keeseWidth, keeseHeight), keese, 2, 1);
            dragonData = new SpriteData(new Vector2(dragonWidth, dragonHeight), dragon, 1, 4);
            damagedDragonData = new SpriteData(new Vector2(dragonWidth, dragonHeight), damagedDragon, 1, 4);
            downDodongoData = new SpriteData(new Vector2(dodongoWidthDown, dodongoHeight), downDodongo, 1, 3);
            upDodongoData = new SpriteData(new Vector2(dodongoWidthUp, dodongoHeight), upDodongo, 1, 3);
            leftDodongoData = new SpriteData(new Vector2(dodongoWidthLeftRight, dodongoHeight), leftDodongo, 1, 3);
            rightDodongoData = new SpriteData(new Vector2(dodongoWidthLeftRight, dodongoHeight), rightDodongo, 1, 3);
            upDarknutData = new SpriteData(new Vector2(darknutWidth, darknutHeight), upRedDarknut, 2, 1);
            downDarknutData = new SpriteData(new Vector2(darknutWidth, darknutHeight), downRedDarknut, 2, 1);
            leftDarknutData = new SpriteData(new Vector2(darknutWidth, darknutHeight), leftRedDarknut, 2, 1);
            rightDarknutData = new SpriteData(new Vector2(darknutWidth, darknutHeight), rightRedDarknut, 2, 1);
            fireSnakeData = new SpriteData(new Vector2(fireSnakeWidth, fireSnakeHeight), fireSnake, 1, 4);
            oldManData = new SpriteData(new Vector2(oldManWidth, oldManHeight), oldMan, 1, 1);
            merchantData = new SpriteData(new Vector2(merchantWidth, merchantHeight), merchant, 1, 1);
            spawnEnemyData = new SpriteData(new Vector2(40, 40), spawnEnemy, 3, 1);
            deadEnemyData = new SpriteData(new Vector2(40, 40), deadEnemy, 1, 6);
            downVireData = new SpriteData(new Vector2(vireWidth, vireHeight), downVire, 2, 1);
            upVireData = new SpriteData(new Vector2(vireWidth, vireHeight), upVire, 2, 1);
            vireKeeseData = new SpriteData(new Vector2(keeseWidth, keeseHeight), vireKeese, 2, 1);
            bubbleData = new SpriteData(new Vector2(bubbleWidth, bubbleHeight), bubble, 2, 1);
            manhandlaBodyData = new SpriteData(new Vector2(ManhandlaBodyWidth, ManhandlaBodyHeight), manhandlaBodyTexture, 1, 1);
            manhandlaHeadData = new SpriteData(new Vector2(ManhandlaHeadWidth, ManhandlaHeadHeight), manhandlaHeadDownTexture, 2, 1);
            GleeokBodyData = new SpriteData(new Vector2(GleeockBodyWidth, GleeockBodyHeight), GleeokBodyTexture, 3, 1);
            GleeokHeadOffData = new SpriteData(new Vector2(GleeockHeadOffWidth, GleeockHeadOffHeight), GleeokHeadOffTexture, 2, 1);
            GleeokHeadData = new SpriteData(new Vector2(GleeockHeadWidth, GleeockHeadHeight), GleeokHeadTexture, 1, 1);
            GleeokNeckData = new SpriteData(new Vector2(GleeockNeckWidth, GleeockNeckHeight), GleeokNeckTexture, 1, 1);
            likelikeData = new SpriteData(new Vector2(likelikeWidth, likelikeHeight), likelike, 3, 1);
            polsVoiceData = new SpriteData(new Vector2(PolsVoiceWidth, PolsVoiceHeight), polsVoice, 2, 1);
        }

        // Stalfos Sprites
        public ISprite CreateStalfosSprite()
        {
            return new ObjectSprite(stalfos, stalfosData);
        }

        // Gibdo Sprites
        public ISprite CreateGibdoSprite()
        {
            return new ObjectSprite(gibdo, gibdoData);
        }

        // Firesnake Sprites
        public ISprite CreateFireSnakeSprite()
        {
            return new ObjectSprite(fireSnake, fireSnakeData);
        }

        public ISprite CreateBubbleSprite()
        {
            return new ObjectSprite(bubble, bubbleData);
        }

        // Darknut Sprites
        public ISprite CreateBlueDarknutSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(upBlueDarknut, upDarknutData);
                case Physics.Direction.South:
                    return new ObjectSprite(downBlueDarknut, downDarknutData);
                case Physics.Direction.East:
                    return new ObjectSprite(rightBlueDarknut, rightDarknutData);
                default:
                    return new ObjectSprite(leftBlueDarknut, leftDarknutData);
            }
        }

        public ISprite CreateRedDarknutSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(upRedDarknut, upDarknutData);
                case Physics.Direction.South:
                    return new ObjectSprite(downRedDarknut, downDarknutData);
                case Physics.Direction.East:
                    return new ObjectSprite(rightRedDarknut, rightDarknutData);
                default:
                    return new ObjectSprite(leftRedDarknut, leftDarknutData);
            }
        }

        // Goriya Sprites
        public ISprite CreateGoriyaSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(upGoriya, upGoriyaData);
                case Physics.Direction.South:
                    return new ObjectSprite(downGoriya, downGoriyaData);
                case Physics.Direction.East:
                    return new ObjectSprite(rightGoriya, rightGoriyaData);
                default:
                    return new ObjectSprite(leftGoriya, leftGoriyaData);
            }
        }

        public ISprite CreateBlueGoriyaSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(upBlueGoriya, upGoriyaData);
                case Physics.Direction.South:
                    return new ObjectSprite(downBlueGoriya, downGoriyaData);
                case Physics.Direction.East:
                    return new ObjectSprite(rightBlueGoriya, rightGoriyaData);
                default:
                    return new ObjectSprite(leftBlueGoriya, leftGoriyaData);
            }
        }

        public ISprite CreateManhandlaBodySprite()
        {
            return new ObjectSprite(manhandlaBodyTexture, manhandlaBodyData);
        }

        public ISprite CreateManhandlaHeadSprite(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(manhandlaHeadUpTexture, manhandlaHeadData);
                case Physics.Direction.South:
                    return new ObjectSprite(manhandlaHeadDownTexture, manhandlaHeadData);
                case Physics.Direction.East:
                    return new ObjectSprite(manhandlaHeadRightTexture, manhandlaHeadData);
                default:
                    return new ObjectSprite(manhandlaHeadLeftTexture, manhandlaHeadData);
            }
        }

        public ISprite CreateGleeockNeckSprite()
        {
            return new ObjectSprite(GleeokNeckTexture, GleeokNeckData);
        }

        public ISprite CreateGleeockBodySprite()
        {
            return new ObjectSprite(GleeokBodyTexture, GleeokBodyData) { FrameDelay = 20 };
        }

        public ISprite CreateGleeockHeadSprite()
        {
            return new ObjectSprite(GleeokHeadTexture, GleeokHeadData);
        }

        public ISprite CreateGleeockHeadOffSprite()
        {
            return new ObjectSprite(GleeokHeadOffTexture, GleeokHeadOffData);
        }

        // Wallmaster Sprites
        public ISprite CreateLeftMovingWallMasterSprite()
        {
            return new ObjectSprite(leftWallMaster, leftWallMasterData);
        }

        public ISprite CreateRightMovingWallMasterSprite()
        {
            return new ObjectSprite(rightWallMaster, rightWallMasterData);
        }

        public ISprite CreateAttackingWallMasterSprite()
        {
            return new ObjectSprite(leftWallMaster, leftWallMasterData);
        }

        // Rope Sprites
        public ISprite CreateLeftMovingRopeSprite()
        {
            return new ObjectSprite(leftRope, leftRopeData);
        }

        public ISprite CreateRightMovingRopeSprite()
        {
            return new ObjectSprite(rightRope, rightRopeData);
        }

        // Gel Sprites
        public ISprite CreateGelSprite()
        {
            return new ObjectSprite(gel, gelData);
        }

        // Zol Sprites
        public ISprite CreateZolSprite()
        {
            return new ObjectSprite(zol, zolData);
        }

        // Spike Cross Sprites
        public ISprite CreateSpikeCrossSprite()
        {
            return new ObjectSprite(spikeCross, spikeCrossData);
        }

        // Keese Sprites
        public ISprite CreateKeeseSprite()
        {
            return new ObjectSprite(keese, keeseData);
        }

        // Dragon Sprites
        public ISprite CreateDragonSprite()
        {
            return new ObjectSprite(dragon, dragonData);
        }

        public ISprite CreateDamagedDragonSprite()
        {
            return new ObjectSprite(damagedDragon, damagedDragonData);
        }

        // Dodongo Sprites
        public ISprite CreateDownMovingDodongoSprite()
        {
            return new ObjectSprite(downDodongo, downDodongoData);
        }

        public ISprite CreateUpMovingDodongoSprite()
        {
            return new ObjectSprite(upDodongo, upDodongoData);
        }

        public ISprite CreateLeftMovingDodongoSprite()
        {
            return new ObjectSprite(leftDodongo, leftDodongoData);
        }

        public ISprite CreateRightMovingDodongoSprite()
        {
            return new ObjectSprite(rightDodongo, rightDodongoData);
        }

        // Old Man Sprites
        public ISprite CreateOldManSprite()
        {
            return new ObjectSprite(oldMan, oldManData);
        }

        public ISprite CreateAngryOldManSprite()
        {
            return new ObjectSprite(angryOldMan, oldManData);
        }

        // Merchant Sprites
        public ISprite CreateMerchantSprite()
        {
            return new ObjectSprite(merchant, merchantData);
        }

        // Vire Sprites
        public ISprite CreateDownMovingVireSprite()
        {
            return new ObjectSprite(downVire, downVireData);
        }

        public ISprite CreateUpMovingVireSprite()
        {
            return new ObjectSprite(upVire, upVireData);
        }

        public ISprite CreateVireKeeseSprite()
        {
            return new ObjectSprite(vireKeese, vireKeeseData);
        }

        public ISprite CreateLikelikeSprite()
        {
            return new ObjectSprite(likelike, likelikeData);
        }

        public ISprite CreatePolsVoiceSprite()
        {
            return new ObjectSprite(polsVoice, polsVoiceData);
        }

        // Enemy Spawn Sprites
        public ISprite CreateEnemySpawn()
        {
            return new ObjectSprite(spawnEnemy, spawnEnemyData);
        }

        // Enemy Death Sprites
        public ISprite CreateDeadEnemySprite()
        {
            return new ObjectSprite(deadEnemy, deadEnemyData);
        }
    }
}