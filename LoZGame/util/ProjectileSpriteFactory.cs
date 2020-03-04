﻿namespace LoZClone
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
        private static readonly int explosionHeight = 50;
        private static readonly int explosionWidth = 48;
        private static readonly int triforceSize = 12;

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

        public int TriforceSize
        {
            get { return triforceSize; }
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
        private Texture2D triforceSpriteSheet;
        private readonly SpriteSheetData triforceData = new SpriteSheetData("Triforce", triforceSize, triforceSize, 1, 2);
        private Texture2D swordBeamSpriteSheet;
        private readonly SpriteSheetData swordBeamData = new SpriteSheetData("SwordBeam", swordBeamWidth, standardHeight, 1, 4);
        private Texture2D swordExplosionSpriteSheet;
        private readonly SpriteSheetData swordExplosionData = new SpriteSheetData("SwordBeamExplosion", standardWidth, triforceSize, 1, 4);
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

        public TriforceProjectileSprite Triforce(Vector2 loc, int scale, int instance)
        {
            return new TriforceProjectileSprite(this.triforceSpriteSheet, this.triforceData, loc, scale, instance);
        }

        public BoomerangProjectileSprite Boomerang(IPlayer player, int scale, int instance)
        {
            return new BoomerangProjectileSprite(this.boomerangSpriteSheet, this.boomerangData, player, scale, instance);
        }

        public BoomerangEnemySprite BoomerangEnemy(Goriya goriya, int scale, int instance)
        {
            return new BoomerangEnemySprite(this.boomerangSpriteSheet, this.boomerangData, goriya.Physics.Location, scale, instance);
        }

        public MagicBoomerangProjectileSprite MagicBoomerang(IPlayer player, int scale, int instance)
        {
            return new MagicBoomerangProjectileSprite(this.magicBoomerangSpriteSheet, this.magicBoomerangData, player, scale, instance);
        }

        public MagicBoomerangEnemySprite MagicBoomerangEnemy(Goriya goriya, int scale, int instance)
        {
            return new MagicBoomerangEnemySprite(this.magicBoomerangSpriteSheet, this.magicBoomerangData, scale, instance);
        }

        public BombProjectileSprite Bomb(Vector2 loc, string direction, int scale, int instance, ExplosionManager explosion)
        {
            return new BombProjectileSprite(this.bombSpriteSheet, this.bombData, loc, direction, scale, instance, explosion);
        }

        public ArrowProjectileSprite Arrow(Vector2 loc, string direction, int scale, int instance)
        {
            return new ArrowProjectileSprite(this.arrowSpriteSheet, this.arrowData, loc, direction, scale, instance);
        }

        public SilverArrowProjectileSprite SilverArrow(Vector2 loc, string direction, int scale, int instance)
        {
            return new SilverArrowProjectileSprite(this.silverArrowSpriteSheet, this.silverArrowData, loc, direction, scale, instance);
        }

        public RedCandleProjectileSprite RedCandle(Vector2 loc, string direction, int scale, int instance)
        {
            return new RedCandleProjectileSprite(this.flameSpriteSheet, this.flameData, loc, direction, scale, instance);
        }

        public BlueCandleProjectileSprite BlueCandle(Vector2 loc, string direction, int scale, int instance)
        {
            return new BlueCandleProjectileSprite(this.flameSpriteSheet, this.flameData, loc, direction, scale, instance);
        }

        public SwordBeamProjectileSprite SwordBeam(IPlayer player, int scale, int instance, ExplosionManager explosion)
        {
            return new SwordBeamProjectileSprite(this.swordBeamSpriteSheet, this.swordBeamData, player, scale, instance, explosion);
        }

        public SwordBeamExplosionSprite SwordExplosion(Vector2 loc, string direction, int scale, int instance)
        {
            return new SwordBeamExplosionSprite(this.swordExplosionSpriteSheet, this.swordExplosionData, loc, direction, scale, instance);
        }

        public BombExplosionSprite BombExplosionOne(Vector2 loc, int scale, int instance)
        {
            return new BombExplosionSprite(this.explosionOneSpriteSheet, this.explosionOneData, loc, scale, instance);
        }

        public BombExplosionSprite BombExplosionTwo(Vector2 loc, int scale, int instance)
        {
            return new BombExplosionSprite(this.explosionTwoSpriteSheet, this.explosionTwoData, loc, scale, instance);
        }

        public BombExplosionSprite BombExplosionThree(Vector2 loc, int scale, int instance)
        {
            return new BombExplosionSprite(this.explosionThreeSpriteSheet, this.explosionThreeData, loc, scale, instance);
        }

        public BombExplosionSprite BombExplosionFour(Vector2 loc, int scale, int instance)
        {
            return new BombExplosionSprite(this.explosionFourSpriteSheet, this.ExplosionFourData, loc, scale, instance);
        }

        public BombExplosionSprite BombExplosionFive(Vector2 loc, int scale, int instance)
        {
            return new BombExplosionSprite(this.explosionFiveSpriteSheet, this.explosionFiveData, loc, scale, instance);
        }
    }
}
