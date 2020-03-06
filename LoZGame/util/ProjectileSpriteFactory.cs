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
        private static readonly int swordBeamWidth = 7;
        private static readonly int boomerangHeight = 10;
        private static readonly int standardHeight = 18;
        private static readonly int standardWidth = 8;
        private static readonly int flameWidth = 32;
        private static readonly int flameHeight = 34;
        private static readonly int arrowWidth = 5;
        private static readonly int swordBeamExplosionHeight = 12;
        private static readonly int explosionHeight = 50;
        private static readonly int explosionWidth = 48;
        private static readonly int fireballWidth = 8;
        private static readonly int fireballHeight = 10;

        public int SwordBeamWidth
        {
            get { return SwordBeamWidth; }
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
            else if (projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile || projectile is BoomerangEnemy)
            {
                return standardWidth * DRAWSCALE;
            }
            else if (projectile is DragonFireBall)
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
            else if (projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile || projectile is BoomerangEnemy)
            {
                return boomerangHeight * DRAWSCALE;
            }
            else if (projectile is DragonFireBall)
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
            else
            {
                return 0;
            }
        }

        public Vector2 ExplosionCenter { get { return new Vector2(ExplosionWidth / 2, ExplosionHeight / 2); } }

        private Texture2D flameSpriteSheet;
        private readonly SpriteSheetData flameData = new SpriteSheetData("Flame", flameWidth, flameHeight, 1, 2);
        private Texture2D arrowSpriteSheet;
        private readonly SpriteSheetData arrowData = new SpriteSheetData("WoodenArrow", arrowWidth, standardHeight, 1, 1);
        private Texture2D silverArrowSpriteSheet;
        private readonly SpriteSheetData silverArrowData = new SpriteSheetData("SilverArrow", arrowWidth, standardHeight, 1, 1);
        private Texture2D boomerangSpriteSheet;
        private readonly SpriteSheetData boomerangData = new SpriteSheetData("Boomerang", standardWidth, boomerangHeight, 1, 1);
        private Texture2D magicBoomerangSpriteSheet;
        private readonly SpriteSheetData magicBoomerangData = new SpriteSheetData("MagicBoomerang", standardWidth, boomerangHeight, 1, 1);
        private Texture2D bombSpriteSheet;
        private readonly SpriteSheetData bombData = new SpriteSheetData("Bomb", standardWidth, standardHeight, 1, 1);
        private Texture2D swordBeamSpriteSheet;
        private readonly SpriteSheetData swordBeamData = new SpriteSheetData("SwordBeam", swordBeamWidth, standardHeight, 1, 4);
        private Texture2D swordExplosionSpriteSheet;
        private readonly SpriteSheetData swordExplosionData = new SpriteSheetData("SwordBeamExplosion", standardWidth, swordBeamExplosionHeight, 1, 4);
        private Texture2D explosionOneSpriteSheet;
        private readonly SpriteSheetData explosionOneData = new SpriteSheetData("BombExplosionOne", explosionWidth, explosionHeight, 1, 3);
        private Texture2D explosionTwoSpriteSheet;
        private readonly SpriteSheetData explosionTwoData = new SpriteSheetData("BombExplosionTwo", explosionWidth, explosionHeight, 1, 3);
        private Texture2D explosionThreeSpriteSheet;
        private readonly SpriteSheetData explosionThreeData = new SpriteSheetData("BombExplosionThree", explosionWidth, explosionHeight, 1, 3);
        private Texture2D explosionFourSpriteSheet;
        private readonly SpriteSheetData ExplosionFourData = new SpriteSheetData("BombExplosionFour", explosionWidth, explosionHeight, 1, 3);
        private Texture2D explosionFiveSpriteSheet;
        private readonly SpriteSheetData explosionFiveData = new SpriteSheetData("BombExplosionFive", explosionWidth, explosionHeight, 1, 3);
        private Texture2D fireballSpriteSheet;
        private readonly SpriteSheetData fireballData = new SpriteSheetData("fireball", fireballWidth, fireballHeight, 1, 4);

        private static readonly ProjectileSpriteFactory InstanceValue = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        private ProjectileSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.boomerangSpriteSheet = content.Load<Texture2D>(this.boomerangData.FilePath);
            this.magicBoomerangSpriteSheet = content.Load<Texture2D>(this.magicBoomerangData.FilePath);
            this.bombSpriteSheet = content.Load<Texture2D>(this.bombData.FilePath);
            this.magicBoomerangSpriteSheet = content.Load<Texture2D>(this.magicBoomerangData.FilePath);
            this.arrowSpriteSheet = content.Load<Texture2D>(this.arrowData.FilePath);
            this.silverArrowSpriteSheet = content.Load<Texture2D>(this.silverArrowData.FilePath);
            this.flameSpriteSheet = content.Load<Texture2D>(this.flameData.FilePath);
            this.swordBeamSpriteSheet = content.Load<Texture2D>(this.swordBeamData.FilePath);
            this.swordExplosionSpriteSheet = content.Load<Texture2D>(this.swordExplosionData.FilePath);
            this.explosionOneSpriteSheet = content.Load<Texture2D>(this.explosionOneData.FilePath);
            this.explosionTwoSpriteSheet = content.Load<Texture2D>(this.explosionTwoData.FilePath);
            this.explosionThreeSpriteSheet = content.Load<Texture2D>(this.explosionThreeData.FilePath);
            this.explosionFourSpriteSheet = content.Load<Texture2D>(this.ExplosionFourData.FilePath);
            this.explosionFiveSpriteSheet = content.Load<Texture2D>(this.explosionFiveData.FilePath);
            this.fireballSpriteSheet = content.Load<Texture2D>(this.fireballData.FilePath);
        }

        public FireballSprite Fireball()
        {
            return new FireballSprite(this.fireballSpriteSheet, this.fireballData, DRAWSCALE);
        }

        public BoomerangProjectileSprite Boomerang()
        {
            return new BoomerangProjectileSprite(this.boomerangSpriteSheet, this.boomerangData, DRAWSCALE);
        }

        public MagicBoomerangProjectileSprite MagicBoomerang()
        {
            return new MagicBoomerangProjectileSprite(this.magicBoomerangSpriteSheet, this.magicBoomerangData, DRAWSCALE);
        }

        public BombProjectileSprite Bomb()
        {
            return new BombProjectileSprite(this.bombSpriteSheet, this.bombData, DRAWSCALE);
        }

        public ArrowProjectileSprite Arrow(float rotation)
        {
            return new ArrowProjectileSprite(this.arrowSpriteSheet, this.arrowData, rotation, DRAWSCALE);
        }

        public SilverArrowProjectileSprite SilverArrow(float rotation)
        {
            return new SilverArrowProjectileSprite(this.silverArrowSpriteSheet, this.silverArrowData, rotation, DRAWSCALE);
        }

        public RedCandleProjectileSprite RedCandle()
        {
            return new RedCandleProjectileSprite(this.flameSpriteSheet, this.flameData, DRAWSCALE / 2);
        }

        public BlueCandleProjectileSprite BlueCandle()
        {
            return new BlueCandleProjectileSprite(this.flameSpriteSheet, this.flameData, DRAWSCALE / 2);
        }

        public SwordBeamProjectileSprite SwordBeam(float rotation)
        {
            return new SwordBeamProjectileSprite(this.swordBeamSpriteSheet, this.swordBeamData, rotation, DRAWSCALE);
        }

        public SwordBeamExplosionSprite SwordExplosion(SpriteEffects effect, float rotation)
        {
            return new SwordBeamExplosionSprite(this.swordExplosionSpriteSheet, this.swordExplosionData, effect, rotation, DRAWSCALE);
        }

        public BombExplosionSprite BombExplosionOne()
        {
            return new BombExplosionSprite(this.explosionOneSpriteSheet, this.explosionOneData, DRAWSCALE);
        }

        public BombExplosionSprite BombExplosionTwo()
        {
            return new BombExplosionSprite(this.explosionTwoSpriteSheet, this.explosionTwoData, DRAWSCALE);
        }

        public BombExplosionSprite BombExplosionThree()
        {
            return new BombExplosionSprite(this.explosionThreeSpriteSheet, this.explosionThreeData, DRAWSCALE);
        }

        public BombExplosionSprite BombExplosionFour()
        {
            return new BombExplosionSprite(this.explosionFourSpriteSheet, this.ExplosionFourData, DRAWSCALE);
        }

        public BombExplosionSprite BombExplosionFive()
        {
            return new BombExplosionSprite(this.explosionFiveSpriteSheet, this.explosionFiveData, DRAWSCALE);
        }
    }
}
