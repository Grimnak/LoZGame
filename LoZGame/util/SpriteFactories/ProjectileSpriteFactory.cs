namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class ProjectileSpriteFactory
    {
        private const int DRAWSCALE = 2;
        private static readonly int swordBeamWidth = 14;
        private static readonly int boomerangHeight = 20;
        private static readonly int standardHeight = 36;
        private static readonly int standardWidth = 16;
        private static readonly int flameWidth = 32;
        private static readonly int flameHeight = 34;
        private static readonly int arrowWidth = 10;
        private static readonly int arrowHeight = 32;
        private static readonly int swordBeamExplosionHeight = 24;
        private static readonly int explosionHeight = 100;
        private static readonly int explosionWidth = 96;
        private static readonly int fireballWidth = 25;
        private static readonly int fireballHeight = 25;
        private static readonly int swordWidth = LinkSpriteFactory.LinkWidth;
        private static readonly int swordHeight = LinkSpriteFactory.LinkHeight;
        private static readonly int sonicBeamWidth = 32;
        private static readonly int sonicBeamHeight = 32;

        private static readonly int spartanLaserHorizontalHeight = 8;
        private static readonly int spartanLaserHorizontalWidth = 20;
        private static readonly int spartanLaserVerticalWidth = 4;
        private static readonly int spartanLaserVerticalHeight = 10;

        public int SwordWidth
        {
            get { return swordWidth; }
        }

        public int SwordHeight
        {
            get { return swordHeight; }
        }

        public int SwordBeamWidth
        {
            get { return swordBeamWidth; }
        }

        public int SwordBeamHeight
        {
            get { return standardHeight; }
        }

        public int BoomerangHeight
        {
            get { return boomerangHeight; }
        }

        public int StandardHeight
        {
            get { return standardHeight; }
        }

        public int StandardWidth
        {
            get { return standardWidth; }
        }

        public int FlameWidth
        {
            get { return flameWidth; }
        }

        public int FlameHeight
        {
            get { return flameHeight; }
        }

        public int ArrowWidth
        {
            get { return arrowWidth; }
        }

        public int ArrowHeight
        {
            get { return arrowHeight; }
        }

        public int ExplosionHeight
        {
            get { return explosionHeight; }
        }

        public int ExplosionWidth
        {
            get { return explosionWidth; }
        }

        public int SwordBeamExplosionHeight
        {
            get { return swordBeamExplosionHeight; }
        }

        public int FireballHeight
        {
            get { return fireballHeight; }
        }

        public int FireballWidth
        {
            get { return fireballWidth; }
        }

        public int SonicBeamWidth
        {
            get { return sonicBeamWidth; }
        }

        public int SonicBeamHeight
        {
            get { return sonicBeamHeight; }
        }

        public static int GetProjectileWidth(IProjectile projectile)
        {
            if (projectile is ArrowProjectile || projectile is SilverArrowProjectile)
            {
                return arrowWidth * DRAWSCALE;
            }
            else if (projectile is BlueCandleProjectile || projectile is RedCandleProjectile)
            {
                return flameWidth;
            }
            else if (projectile is BombProjectile)
            {
                return standardWidth * DRAWSCALE;
            }
            else if (projectile is BombExplosion)
            {
                return explosionWidth * DRAWSCALE;
            }
            else if (projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile)
            {
                return standardWidth * DRAWSCALE;
            }
            else if (projectile is FireballProjectile)
            {
                return fireballWidth * DRAWSCALE;
            }
            else if (projectile is SwordBeamProjectile)
            {
                return swordBeamWidth * DRAWSCALE;
            }
            else if (projectile is SwordBeamExplosion)
            {
                return standardWidth * DRAWSCALE;
            }
            else if (projectile is SwordProjectile)
            {
                return swordWidth;
            }
            else if (projectile is SonicBeamProjectile)
            {
                return sonicBeamWidth;
            }
            else
            {
                return 0;
            }
        }

        public static int GetProjectileHeight(IProjectile projectile)
        {
            if (projectile is ArrowProjectile || projectile is SilverArrowProjectile)
            {
                return standardHeight * DRAWSCALE;
            }
            else if (projectile is BlueCandleProjectile || projectile is RedCandleProjectile)
            {
                return flameHeight;
            }
            else if (projectile is BombProjectile)
            {
                return standardHeight * DRAWSCALE;
            }
            else if (projectile is BombExplosion)
            {
                return explosionHeight * DRAWSCALE;
            }
            else if (projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile)
            {
                return boomerangHeight * DRAWSCALE;
            }
            else if (projectile is FireballProjectile)
            {
                return fireballHeight * DRAWSCALE;
            }
            else if (projectile is SwordBeamProjectile)
            {
                return standardHeight * DRAWSCALE;
            }
            else if (projectile is SwordBeamExplosion)
            {
                return swordBeamExplosionHeight * DRAWSCALE;
            }
            else if (projectile is SwordProjectile)
            {
                return swordHeight;
            }
            else if (projectile is SonicBeamProjectile)
            {
                return sonicBeamHeight;
            }
            else
            {
                return 0;
            }
        }

        public Vector2 ExplosionCenter { get { return new Vector2(ExplosionWidth / 2, ExplosionHeight / 2); } }

        private Texture2D flameSpriteSheet;
        private SpriteData flameData;
        private Texture2D arrowSpriteSheet;
        private SpriteData arrowData;
        private Texture2D silverArrowSpriteSheet;
        private SpriteData silverArrowData;
        private Texture2D boomerangSpriteSheet;
        private SpriteData boomerangData;
        private Texture2D magicBoomerangSpriteSheet;
        private SpriteData magicBoomerangData;
        private Texture2D bombSpriteSheet;
        private SpriteData bombData;
        private Texture2D swordBeamSpriteSheet;
        private SpriteData swordBeamData;
        private Texture2D swordExplosionSpriteSheet;
        private SpriteData swordExplosionData;
        private Texture2D explosionOneSpriteSheet;
        private SpriteData explosionOneData;
        private Texture2D explosionTwoSpriteSheet;
        private SpriteData explosionTwoData;
        private Texture2D explosionThreeSpriteSheet;
        private SpriteData explosionThreeData;
        private Texture2D explosionFourSpriteSheet;
        private SpriteData ExplosionFourData;
        private Texture2D explosionFiveSpriteSheet;
        private SpriteData explosionFiveData;
        private Texture2D fireballSpriteSheet;
        private SpriteData fireballData;
        private SpriteData swordData;
        private Texture2D greenWoodSwordSpriteSheet;
        private Texture2D greenWhiteSwordSpriteSheet;
        private Texture2D greenMagicSwordSpriteSheet;
        private Texture2D blueWoodSwordSpriteSheet;
        private Texture2D blueWhiteSwordSpriteSheet;
        private Texture2D blueMagicSwordSpriteSheet;
        private Texture2D redWoodSwordSpriteSheet;
        private Texture2D redWhiteSwordSpriteSheet;
        private Texture2D redMagicSwordSpriteSheet;
        private Texture2D spartanLaserUpTexture;
        private Texture2D spartanLaserDownTexture;
        private Texture2D spartanLaserRightTexture;
        private Texture2D spartanLaserLeftTexture;
        private Texture2D sonicBeamLeftTexture;
        private Texture2D sonicBeamRightTexture;
        private Texture2D sonicBeamUpTexture;
        private Texture2D sonicBeamDownTexture;
        private SpriteData sonicBeamData;
        private SpriteData spartanLaserDataVertical;
        private SpriteData spartanLaserDataHorizontal;

        private static readonly ProjectileSpriteFactory InstanceValue = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        private ProjectileSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            LoadTextures(content);
            LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            boomerangSpriteSheet = content.Load<Texture2D>("Boomerang");
            magicBoomerangSpriteSheet = content.Load<Texture2D>("MagicBoomerang");
            bombSpriteSheet = content.Load<Texture2D>("Bomb");
            arrowSpriteSheet = content.Load<Texture2D>("WoodenArrow");
            silverArrowSpriteSheet = content.Load<Texture2D>("SilverArrow");
            flameSpriteSheet = content.Load<Texture2D>("Flame");
            swordBeamSpriteSheet = content.Load<Texture2D>("SwordBeam");
            swordExplosionSpriteSheet = content.Load<Texture2D>("SwordBeamExplosion");
            explosionOneSpriteSheet = content.Load<Texture2D>("BombExplosionOne");
            explosionTwoSpriteSheet = content.Load<Texture2D>("BombExplosionTwo");
            explosionThreeSpriteSheet = content.Load<Texture2D>("BombExplosionThree");
            explosionFourSpriteSheet = content.Load<Texture2D>("BombExplosionFour");
            explosionFiveSpriteSheet = content.Load<Texture2D>("BombExplosionFive");
            fireballSpriteSheet = content.Load<Texture2D>("fireball");
            greenWoodSwordSpriteSheet = content.Load<Texture2D>("Green_Wood_Up");
            greenWhiteSwordSpriteSheet = content.Load<Texture2D>("Green_White_Up");
            greenMagicSwordSpriteSheet = content.Load<Texture2D>("Green_Magic_Up");
            blueWoodSwordSpriteSheet = content.Load<Texture2D>("Blue_Wood_Up");
            blueWhiteSwordSpriteSheet = content.Load<Texture2D>("Blue_White_Up");
            blueMagicSwordSpriteSheet = content.Load<Texture2D>("Blue_White_Up"); // never created
            redWoodSwordSpriteSheet = content.Load<Texture2D>("Red_Wood_Up");
            redWhiteSwordSpriteSheet = content.Load<Texture2D>("Red_White_Up");
            redMagicSwordSpriteSheet = content.Load<Texture2D>("Red_White_Up"); // never created
            spartanLaserUpTexture = content.Load<Texture2D>("SpartanLaser_up");
            spartanLaserDownTexture = content.Load<Texture2D>("SpartanLaser_down");
            spartanLaserRightTexture = content.Load<Texture2D>("SpartanLaser_right");
            spartanLaserLeftTexture = content.Load<Texture2D>("SpartanLaser_left");
            sonicBeamLeftTexture = content.Load<Texture2D>("sonicBeam_Left");
            sonicBeamRightTexture = content.Load<Texture2D>("sonicBeam_Right");
            sonicBeamUpTexture = content.Load<Texture2D>("sonicBeam_Up");
            sonicBeamDownTexture = content.Load<Texture2D>("sonicBeam_Down");
        }

        private void LoadData()
        {
            flameData = new SpriteData(new Vector2(flameWidth, flameHeight), flameSpriteSheet, 2, 1);
            arrowData = new SpriteData(new Vector2(arrowWidth, standardHeight), arrowSpriteSheet, 1, 1);
            silverArrowData = new SpriteData(new Vector2(arrowWidth, standardHeight), silverArrowSpriteSheet, 1, 1);
            boomerangData = new SpriteData(new Vector2(standardWidth, boomerangHeight), boomerangSpriteSheet, 1, 1);
            magicBoomerangData = new SpriteData(new Vector2(standardWidth, boomerangHeight), magicBoomerangSpriteSheet, 1, 1);
            bombData = new SpriteData(new Vector2(standardWidth, standardHeight), bombSpriteSheet, 1, 1);
            swordBeamData = new SpriteData(new Vector2(swordBeamWidth, standardHeight), swordBeamSpriteSheet, 4, 1);
            swordExplosionData = new SpriteData(new Vector2(standardWidth, swordBeamExplosionHeight), swordExplosionSpriteSheet, 4, 1);
            explosionOneData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionOneSpriteSheet, 3, 1);
            explosionTwoData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionTwoSpriteSheet, 3, 1);
            explosionThreeData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionThreeSpriteSheet, 3, 1);
            ExplosionFourData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionFourSpriteSheet, 3, 1);
            explosionFiveData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionFiveSpriteSheet, 3, 1);
            fireballData = new SpriteData(new Vector2(fireballWidth, fireballHeight), fireballSpriteSheet, 1, 4);
            swordData = new SpriteData(new Vector2(swordWidth, swordHeight), greenWoodSwordSpriteSheet, 1, 2);
            spartanLaserDataVertical = new SpriteData(new Vector2(spartanLaserVerticalWidth, spartanLaserVerticalHeight), spartanLaserUpTexture, 1, 1);
            spartanLaserDataHorizontal = new SpriteData(new Vector2(spartanLaserHorizontalHeight, spartanLaserHorizontalWidth), spartanLaserRightTexture, 1, 1);
            sonicBeamData = new SpriteData(new Vector2(sonicBeamWidth, sonicBeamHeight), sonicBeamLeftTexture, 1, 1);
        }

        public ISprite Sword(Link.LinkColor color, Link.LinkWeapon type)
        {
            switch (color)
            {
                case Link.LinkColor.Green:
                    switch (type)
                    {
                        case Link.LinkWeapon.White:
                            return new ObjectSprite(greenWhiteSwordSpriteSheet, swordData);
                        case Link.LinkWeapon.Magic:
                            return new ObjectSprite(greenMagicSwordSpriteSheet, swordData);
                        default:
                            return new ObjectSprite(greenWoodSwordSpriteSheet, swordData);
                    }
                case Link.LinkColor.Red:
                    switch (type)
                    {
                        case Link.LinkWeapon.White:
                            return new ObjectSprite(redWhiteSwordSpriteSheet, swordData);
                        case Link.LinkWeapon.Magic:
                            return new ObjectSprite(redMagicSwordSpriteSheet, swordData);
                        default:
                            return new ObjectSprite(redWoodSwordSpriteSheet, swordData);
                    }
                case Link.LinkColor.Blue:
                    switch (type)
                    {
                        case Link.LinkWeapon.White:
                            return new ObjectSprite(blueWhiteSwordSpriteSheet, swordData);
                        case Link.LinkWeapon.Magic:
                            return new ObjectSprite(blueMagicSwordSpriteSheet, swordData);
                        default:
                            return new ObjectSprite(blueWoodSwordSpriteSheet, swordData);
                    }
                default:
                    return new ObjectSprite(greenWoodSwordSpriteSheet, swordData);
            }
        }

        public ISprite Fireball()
        {
            return new ObjectSprite(fireballSpriteSheet, fireballData);
        }

        public ISprite Boomerang()
        {
            return new ObjectSprite(boomerangSpriteSheet, boomerangData);
        }

        public ISprite MagicBoomerang()
        {
            return new ObjectSprite(magicBoomerangSpriteSheet, magicBoomerangData);
        }

        public ISprite Bomb()
        {
            return new ObjectSprite(bombSpriteSheet, bombData);
        }

        public ISprite Arrow()
        {
            return new ObjectSprite(arrowSpriteSheet, arrowData);
        }

        public ISprite SilverArrow()
        {
            return new ObjectSprite(silverArrowSpriteSheet, silverArrowData);
        }

        public ISprite RedCandle()
        {
            return new ObjectSprite(flameSpriteSheet, flameData);
        }

        public ISprite BlueCandle()
        {
            return new ObjectSprite(flameSpriteSheet, flameData);
        }

        public ISprite SwordBeam()
        {
            return new ObjectSprite(swordBeamSpriteSheet, swordBeamData);
        }

        public ISprite SwordExplosion()
        {
            return new ObjectSprite(swordExplosionSpriteSheet, swordExplosionData);
        }

        public ISprite BombExplosionOne()
        {
            return new ObjectSprite(explosionOneSpriteSheet, explosionOneData);
        }

        public ISprite BombExplosionTwo()
        {
            return new ObjectSprite(explosionTwoSpriteSheet, explosionTwoData);
        }

        public ISprite BombExplosionThree()
        {
            return new ObjectSprite(explosionThreeSpriteSheet, explosionThreeData);
        }

        public ISprite BombExplosionFour()
        {
            return new ObjectSprite(explosionFourSpriteSheet, ExplosionFourData);
        }

        public ISprite BombExplosionFive()
        {
            return new ObjectSprite(explosionFiveSpriteSheet, explosionFiveData);
        }

        public ISprite SonicBeam(Physics.Direction direction)
        {
            switch (direction)
            {
                case Physics.Direction.North:
                    return new ObjectSprite(sonicBeamUpTexture, sonicBeamData);
                case Physics.Direction.East:
                    return new ObjectSprite(sonicBeamRightTexture, sonicBeamData);
                case Physics.Direction.West:
                    return new ObjectSprite(sonicBeamLeftTexture, sonicBeamData);
                default:
                    return new ObjectSprite(sonicBeamDownTexture, sonicBeamData);
            }
        }
    }
}
