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
        private static readonly int SwordBeamWidth = 7;
        private static readonly int BoomerangHeight = 10;
        private static readonly int StandardHeight = 18;
        private static readonly int StandardWidth = 8;
        private static readonly int FlameWidth = 32;
        private static readonly int FlameHeight = 34;
        private static readonly int ArrowWidth = 5;
        private static readonly int ExplosionHeight = 50;
        private static readonly int ExplosionWidth = 48;
        private static readonly int TriforceSize = 12;

        public Vector2 ExplosionCenter { get { return new Vector2(ExplosionWidth / 2, ExplosionHeight / 2); } }

        private Texture2D flameSpriteSheet;
        private readonly SpriteSheetData flameData = new SpriteSheetData("Flame", FlameWidth, FlameHeight, 1, 2);
        private Texture2D arrowSpriteSheet;
        private readonly SpriteSheetData arrowData = new SpriteSheetData("WoodenArrow", ArrowWidth, StandardHeight, 1, 1);
        private Texture2D silverArrowSpriteSheet;
        private readonly SpriteSheetData silverArrowData = new SpriteSheetData("SilverArrow", ArrowWidth, StandardHeight, 1, 1);
        private Texture2D boomerangSpriteSheet;
        private readonly SpriteSheetData boomerangData = new SpriteSheetData("Boomerang", StandardWidth, BoomerangHeight, 1, 1);
        private Texture2D magicBoomerangSpriteSheet;
        private readonly SpriteSheetData magicBoomerangData = new SpriteSheetData("MagicBoomerang", StandardWidth, BoomerangHeight, 1, 1);
        private Texture2D bombSpriteSheet;
        private readonly SpriteSheetData bombData = new SpriteSheetData("Bomb", StandardWidth, StandardHeight, 1, 1);
        private Texture2D triforceSpriteSheet;
        private readonly SpriteSheetData triforceData = new SpriteSheetData("Triforce", TriforceSize, TriforceSize, 1, 2);
        private Texture2D swordBeamSpriteSheet;
        private readonly SpriteSheetData swordBeamData = new SpriteSheetData("SwordBeam", SwordBeamWidth, StandardHeight, 1, 4);
        private Texture2D swordExplosionSpriteSheet;
        private readonly SpriteSheetData swordExplosionData = new SpriteSheetData("SwordBeamExplosion", StandardWidth, TriforceSize, 1, 4);
        private Texture2D explosionOneSpriteSheet;
        private readonly SpriteSheetData explosionOneData = new SpriteSheetData("BombExplosionOne", ExplosionWidth, ExplosionHeight, 1, 3);
        private Texture2D explosionTwoSpriteSheet;
        private readonly SpriteSheetData explosionTwoData = new SpriteSheetData("BombExplosionTwo", ExplosionWidth, ExplosionHeight, 1, 3);
        private Texture2D explosionThreeSpriteSheet;
        private readonly SpriteSheetData explosionThreeData = new SpriteSheetData("BombExplosionThree", ExplosionWidth, ExplosionHeight, 1, 3);
        private Texture2D explosionFourSpriteSheet;
        private readonly SpriteSheetData ExplosionFourData = new SpriteSheetData("BombExplosionFour", ExplosionWidth, ExplosionHeight, 1, 3);
        private Texture2D explosionFiveSpriteSheet;
        private readonly SpriteSheetData explosionFiveData = new SpriteSheetData("BombExplosionFive", ExplosionWidth, ExplosionHeight, 1, 3);

        private static readonly ProjectileSpriteFactory InstanceValue = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance => InstanceValue;

        public int Scale => DRAWSCALE;

        private ProjectileSpriteFactory()
        { }

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
            this.triforceSpriteSheet = content.Load<Texture2D>(this.triforceData.FilePath);
        }

        public IProjectile Triforce(Vector2 loc, int scale, int instance)
        {
            return new TriforceProjectile(this.triforceSpriteSheet, this.triforceData, loc, scale, instance);
        }

        public IProjectile Boomerang(IPlayer player, int scale, int instance)
        {
            return new BoomerangProjectile(this.boomerangSpriteSheet, this.boomerangData, player, scale, instance);
        }

        public IProjectile BoomerangEnemy(Goriya goriya, int scale, int instance)
        {
            return new BoomerangEnemy(this.boomerangSpriteSheet, this.boomerangData, goriya, scale, instance);
        }

        public IProjectile MagicBoomerang(IPlayer player, int scale, int instance)
        {
            return new MagicBoomerangProjectile(this.magicBoomerangSpriteSheet, this.magicBoomerangData, player, scale, instance);
        }

        public IProjectile MagicBoomerangEnemy(Goriya goriya, int scale, int instance)
        {
            return new MagicBoomerangEnemy(this.magicBoomerangSpriteSheet, this.magicBoomerangData, goriya, scale, instance);
        }

        public IProjectile Bomb(Vector2 loc, string direction, int scale, int instance, ExplosionManager explosion)
        {
            return new BombProjectile(this.bombSpriteSheet, this.bombData, loc, direction, scale, instance, explosion);
        }

        public IProjectile Arrow(Vector2 loc, string direction, int scale, int instance)
        {
            return new ArrowProjectile(this.arrowSpriteSheet, this.arrowData, loc, direction, scale, instance);
        }

        public IProjectile SilverArrow(Vector2 loc, string direction, int scale, int instance)
        {
            return new SilverArrowProjectile(this.silverArrowSpriteSheet, this.silverArrowData, loc, direction, scale, instance);
        }

        public IProjectile RedCandle(Vector2 loc, string direction, int scale, int instance)
        {
            return new RedCandleProjectile(this.flameSpriteSheet, this.flameData, loc, direction, scale, instance);
        }

        public IProjectile BlueCandle(Vector2 loc, string direction, int scale, int instance)
        {
            return new BlueCandleProjectile(this.flameSpriteSheet, this.flameData, loc, direction, scale, instance);
        }

        public IProjectile SwordBeam(IPlayer player, int scale, int instance, ExplosionManager explosion)
        {
            return new SwordBeamProjectile(this.swordBeamSpriteSheet, this.swordBeamData, player, scale, instance, explosion);
        }

        public IProjectile SwordExplosion(Vector2 loc, string direction, int scale, int instance)
        {
            return new SwordBeamExplosion(this.swordExplosionSpriteSheet, this.swordExplosionData, loc, direction, scale, instance);
        }

        public IProjectile BombExplosionOne(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionOneSpriteSheet, this.explosionOneData, loc, scale, instance);
        }

        public IProjectile BombExplosionTwo(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionTwoSpriteSheet, this.explosionTwoData, loc, scale, instance);
        }

        public IProjectile BombExplosionThree(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionThreeSpriteSheet, this.explosionThreeData, loc, scale, instance);
        }

        public IProjectile BombExplosionFour(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionFourSpriteSheet, this.ExplosionFourData, loc, scale, instance);
        }

        public IProjectile BombExplosionFive(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionFiveSpriteSheet, this.explosionFiveData, loc, scale, instance);
        }
    }
}
