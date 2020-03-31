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
        private static readonly int arrowHeight = 16;
        private static readonly int swordBeamExplosionHeight = 24;
        private static readonly int explosionHeight = 100;
        private static readonly int explosionWidth = 96;
        private static readonly int fireballWidth = 8;
        private static readonly int fireballHeight = 10;
        private static readonly int swordWidth = LinkSpriteFactory.LinkWidth;
        private static readonly int swordHeight = LinkSpriteFactory.LinkHeight;

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
            else if (projectile is WoodenSwordProjectile)
            {
                return swordWidth;
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
            else if (projectile is WoodenSwordProjectile)
            {
                return swordHeight;
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
        private Texture2D greenWoodSwordSpriteSheet;
        private SpriteData greenWoodSwordData;

        private static readonly ProjectileSpriteFactory InstanceValue = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        private ProjectileSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            this.LoadTextures(content);
            this.LoadData();
        }

        private void LoadTextures(ContentManager content)
        {
            this.boomerangSpriteSheet = content.Load<Texture2D>("Boomerang");
            this.magicBoomerangSpriteSheet = content.Load<Texture2D>("MagicBoomerang");
            this.bombSpriteSheet = content.Load<Texture2D>("Bomb");
            this.arrowSpriteSheet = content.Load<Texture2D>("WoodenArrow");
            this.silverArrowSpriteSheet = content.Load<Texture2D>("SilverArrow");
            this.flameSpriteSheet = content.Load<Texture2D>("Flame");
            this.swordBeamSpriteSheet = content.Load<Texture2D>("SwordBeam");
            this.swordExplosionSpriteSheet = content.Load<Texture2D>("SwordBeamExplosion");
            this.explosionOneSpriteSheet = content.Load<Texture2D>("BombExplosionOne");
            this.explosionTwoSpriteSheet = content.Load<Texture2D>("BombExplosionTwo");
            this.explosionThreeSpriteSheet = content.Load<Texture2D>("BombExplosionThree");
            this.explosionFourSpriteSheet = content.Load<Texture2D>("BombExplosionFour");
            this.explosionFiveSpriteSheet = content.Load<Texture2D>("BombExplosionFive");
            this.fireballSpriteSheet = content.Load<Texture2D>("fireball");
            this.greenWoodSwordSpriteSheet = content.Load<Texture2D>("Green_Wood_Up");
        }

        private void LoadData()
        {
            this.flameData = new SpriteData(new Vector2(flameWidth, flameHeight), flameSpriteSheet, 2, 1);
            this.arrowData = new SpriteData(new Vector2(arrowWidth, standardHeight) * DRAWSCALE, arrowSpriteSheet, 1, 1);
            this.silverArrowData = new SpriteData(new Vector2(arrowWidth, standardHeight) * DRAWSCALE, silverArrowSpriteSheet, 1, 1);
            this.boomerangData = new SpriteData(new Vector2(standardWidth, boomerangHeight) * DRAWSCALE, boomerangSpriteSheet, 1, 1);
            this.magicBoomerangData = new SpriteData(new Vector2(standardWidth, boomerangHeight) * DRAWSCALE, magicBoomerangSpriteSheet, 1, 1);
            this.bombData = new SpriteData(new Vector2(standardWidth, standardHeight) * DRAWSCALE, bombSpriteSheet, 1, 1);
            this.swordBeamData = new SpriteData(new Vector2(swordBeamWidth, standardHeight) * DRAWSCALE, swordBeamSpriteSheet, 4, 1);
            this.swordExplosionData = new SpriteData(new Vector2(standardWidth, swordBeamExplosionHeight) * DRAWSCALE, swordExplosionSpriteSheet, 4, 1);
            this.explosionOneData = new SpriteData(new Vector2(explosionWidth, explosionHeight) * DRAWSCALE, explosionOneSpriteSheet, 3, 1);
            this.explosionTwoData = new SpriteData(new Vector2(explosionWidth, explosionHeight) * DRAWSCALE, explosionTwoSpriteSheet, 3, 1);
            this.explosionThreeData = new SpriteData(new Vector2(explosionWidth, explosionHeight) * DRAWSCALE, explosionThreeSpriteSheet, 3, 1);
            this.ExplosionFourData = new SpriteData(new Vector2(explosionWidth, explosionHeight) * DRAWSCALE, explosionFourSpriteSheet, 3, 1);
            this.explosionFiveData = new SpriteData(new Vector2(explosionWidth, explosionHeight) * DRAWSCALE, explosionFiveSpriteSheet, 3, 1);
            this.fireballData = new SpriteData(new Vector2(fireballWidth, fireballHeight) * DRAWSCALE, fireballSpriteSheet, 4, 1);
            this.greenWoodSwordData = new SpriteData(new Vector2(swordWidth, swordHeight), greenWoodSwordSpriteSheet, 1, 2);
        }

        public Sprite GreenWoodSword()
        {
            return new Sprite(this.greenWoodSwordSpriteSheet, this.greenWoodSwordData);
        }

        public Sprite Fireball()
        {
            return new Sprite(this.fireballSpriteSheet, this.fireballData);
        }

        public Sprite Boomerang()
        {
            return new Sprite(this.boomerangSpriteSheet, this.boomerangData);
        }

        public Sprite MagicBoomerang()
        {
            return new Sprite(this.magicBoomerangSpriteSheet, this.magicBoomerangData);
        }

        public Sprite Bomb()
        {
            return new Sprite(this.bombSpriteSheet, this.bombData);
        }

        public Sprite Arrow()
        {
            return new Sprite(this.arrowSpriteSheet, this.arrowData);
        }

        public Sprite SilverArrow()
        {
            return new Sprite(this.silverArrowSpriteSheet, this.silverArrowData);
        }

        public Sprite RedCandle()
        {
            return new Sprite(this.flameSpriteSheet, this.flameData);
        }

        public Sprite BlueCandle()
        {
            return new Sprite(this.flameSpriteSheet, this.flameData);
        }

        public Sprite SwordBeam()
        {
            return new Sprite(this.swordBeamSpriteSheet, this.swordBeamData);
        }

        public Sprite SwordExplosion()
        {
            return new Sprite(this.swordExplosionSpriteSheet, this.swordExplosionData);
        }

        public Sprite BombExplosionOne()
        {
            return new Sprite(this.explosionOneSpriteSheet, this.explosionOneData);
        }

        public Sprite BombExplosionTwo()
        {
            return new Sprite(this.explosionTwoSpriteSheet, this.explosionTwoData);
        }

        public Sprite BombExplosionThree()
        {
            return new Sprite(this.explosionThreeSpriteSheet, this.explosionThreeData);
        }

        public Sprite BombExplosionFour()
        {
            return new Sprite(this.explosionFourSpriteSheet, this.ExplosionFourData);
        }

        public Sprite BombExplosionFive()
        {
            return new Sprite(this.explosionFiveSpriteSheet, this.explosionFiveData);
        }
    }
}
