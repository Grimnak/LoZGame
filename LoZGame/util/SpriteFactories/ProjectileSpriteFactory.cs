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
        //private static readonly int fireballWidth = 32;
        //private static readonly int fireballHeight = 40;
        private static readonly int fireballWidth = 25;
        private static readonly int fireballHeight = 25;
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
            else if (projectile is SwordProjectile)
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
            else if (projectile is SwordProjectile)
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
        private Texture2D whiteSwordSpriteSheet;
        private SpriteData whiteSwordData;
        private Texture2D magicSwordSpriteSheet;
        private SpriteData magicSwordData;

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
            this.whiteSwordSpriteSheet = content.Load<Texture2D>("Green_White_Up");
            this.magicSwordSpriteSheet = content.Load<Texture2D>("Green_Magic_Up");
        }

        private void LoadData()
        {
            this.flameData = new SpriteData(new Vector2(flameWidth, flameHeight), flameSpriteSheet, 2, 1);
            this.arrowData = new SpriteData(new Vector2(arrowWidth, standardHeight), arrowSpriteSheet, 1, 1);
            this.silverArrowData = new SpriteData(new Vector2(arrowWidth, standardHeight), silverArrowSpriteSheet, 1, 1);
            this.boomerangData = new SpriteData(new Vector2(standardWidth, boomerangHeight), boomerangSpriteSheet, 1, 1);
            this.magicBoomerangData = new SpriteData(new Vector2(standardWidth, boomerangHeight), magicBoomerangSpriteSheet, 1, 1);
            this.bombData = new SpriteData(new Vector2(standardWidth, standardHeight), bombSpriteSheet, 1, 1);
            this.swordBeamData = new SpriteData(new Vector2(swordBeamWidth, standardHeight), swordBeamSpriteSheet, 4, 1);
            this.swordExplosionData = new SpriteData(new Vector2(standardWidth, swordBeamExplosionHeight), swordExplosionSpriteSheet, 4, 1);
            this.explosionOneData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionOneSpriteSheet, 3, 1);
            this.explosionTwoData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionTwoSpriteSheet, 3, 1);
            this.explosionThreeData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionThreeSpriteSheet, 3, 1);
            this.ExplosionFourData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionFourSpriteSheet, 3, 1);
            this.explosionFiveData = new SpriteData(new Vector2(explosionWidth, explosionHeight), explosionFiveSpriteSheet, 3, 1);
            this.fireballData = new SpriteData(new Vector2(fireballWidth, fireballHeight), fireballSpriteSheet, 1, 4);
            this.greenWoodSwordData = new SpriteData(new Vector2(swordWidth, swordHeight), greenWoodSwordSpriteSheet, 1, 2);
            this.whiteSwordData = new SpriteData(new Vector2(swordWidth, swordHeight), whiteSwordSpriteSheet, 1, 2);
            this.magicSwordData = new SpriteData(new Vector2(swordWidth, swordHeight), magicSwordSpriteSheet, 1, 2);
        }

        public ISprite GreenWoodSword()
        {
            return new ObjectSprite(this.greenWoodSwordSpriteSheet, this.greenWoodSwordData);
        }

        public ISprite GreenWhiteSword()
        {
            return new ObjectSprite(this.whiteSwordSpriteSheet, this.whiteSwordData);
        }

        public ISprite GreenMagicSword()
        {
            return new ObjectSprite(this.magicSwordSpriteSheet, this.magicSwordData);
        }

        public ISprite Fireball()
        {
            return new ObjectSprite(this.fireballSpriteSheet, this.fireballData);
        }

        public ISprite Boomerang()
        {
            return new ObjectSprite(this.boomerangSpriteSheet, this.boomerangData);
        }

        public ISprite MagicBoomerang()
        {
            return new ObjectSprite(this.magicBoomerangSpriteSheet, this.magicBoomerangData);
        }

        public ISprite Bomb()
        {
            return new ObjectSprite(this.bombSpriteSheet, this.bombData);
        }

        public ISprite Arrow()
        {
            return new ObjectSprite(this.arrowSpriteSheet, this.arrowData);
        }

        public ISprite SilverArrow()
        {
            return new ObjectSprite(this.silverArrowSpriteSheet, this.silverArrowData);
        }

        public ISprite RedCandle()
        {
            return new ObjectSprite(this.flameSpriteSheet, this.flameData);
        }

        public ISprite BlueCandle()
        {
            return new ObjectSprite(this.flameSpriteSheet, this.flameData);
        }

        public ISprite SwordBeam()
        {
            return new ObjectSprite(this.swordBeamSpriteSheet, this.swordBeamData);
        }

        public ISprite SwordExplosion()
        {
            return new ObjectSprite(this.swordExplosionSpriteSheet, this.swordExplosionData);
        }

        public ISprite BombExplosionOne()
        {
            return new ObjectSprite(this.explosionOneSpriteSheet, this.explosionOneData);
        }

        public ISprite BombExplosionTwo()
        {
            return new ObjectSprite(this.explosionTwoSpriteSheet, this.explosionTwoData);
        }

        public ISprite BombExplosionThree()
        {
            return new ObjectSprite(this.explosionThreeSpriteSheet, this.explosionThreeData);
        }

        public ISprite BombExplosionFour()
        {
            return new ObjectSprite(this.explosionFourSpriteSheet, this.ExplosionFourData);
        }

        public ISprite BombExplosionFive()
        {
            return new ObjectSprite(this.explosionFiveSpriteSheet, this.explosionFiveData);
        }
    }
}
