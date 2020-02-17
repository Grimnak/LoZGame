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
        private Texture2D projectileSpriteSheet;
        private Texture2D fireProjectileSpriteSheet;
        private Texture2D swordBeamSpriteSheet;
        private Texture2D swordBeamExplosionSpriteSheet;
        private Texture2D explosionOneSpriteSheet;
        private Texture2D explosionTwoSpriteSheet;
        private Texture2D explosionThreeSpriteSheet;
        private Texture2D explosionFourSpriteSheet;
        private Texture2D explosionFiveSpriteSheet;
        private static readonly int dRAW_SCALE = 2;

        private static readonly ProjectileSpriteFactory InstanceValue = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance => InstanceValue;

        public int Scale => dRAW_SCALE;

        public Texture2D SpriteSheet => this.projectileSpriteSheet;

        private ProjectileSpriteFactory()
        { }

        public void LoadAllTextures(ContentManager content)
        {
            this.projectileSpriteSheet = content.Load<Texture2D>("Items");
            this.fireProjectileSpriteSheet = content.Load<Texture2D>("fire");
            this.swordBeamSpriteSheet = content.Load<Texture2D>("SwordBeam");
            this.swordBeamExplosionSpriteSheet = content.Load<Texture2D>("SwordBeamSecondary");
            this.explosionOneSpriteSheet = content.Load<Texture2D>("BombExplosionOne");
            this.explosionTwoSpriteSheet = content.Load<Texture2D>("BombExplosionTwo");
            this.explosionThreeSpriteSheet = content.Load<Texture2D>("BombExplosionThree");
            this.explosionFourSpriteSheet = content.Load<Texture2D>("BombExplosionFour");
            this.explosionFiveSpriteSheet = content.Load<Texture2D>("BombExplosionFive");
        }

        public IProjectile Triforce(Vector2 loc, int scale, int instance)
        {
            return new TriforceProjectile(this.projectileSpriteSheet, loc, scale, instance);
        }

        public IProjectile Boomerang(IPlayer player, int scale, int instance)
        {
            return new BoomerangProjectile(this.projectileSpriteSheet, player, scale, instance);
        }

        public IProjectile BoomerangEnemy(Goriya goriya, int scale, int instance)
        {
            return new BoomerangEnemy(this.projectileSpriteSheet, goriya, scale, instance);
        }

        public IProjectile MagicBoomerang(IPlayer player, int scale, int instance)
        {
            return new MagicBoomerangProjectile(this.projectileSpriteSheet, player, scale, instance);
        }

        public IProjectile Bomb(Vector2 loc, string direction, int scale, int instance, ExplosionManager explosion)
        {
            return new BombProjectile(this.projectileSpriteSheet, loc, direction, scale, instance, explosion);
        }

        public IProjectile Arrow(Vector2 loc, string direction, int scale, int instance)
        {
            return new ArrowProjectile(this.projectileSpriteSheet, loc, direction, scale, instance);
        }

        public IProjectile SilverArrow(Vector2 loc, string direction, int scale, int instance)
        {
            return new SilverArrowProjectile(this.projectileSpriteSheet, loc, direction, scale, instance);
        }

        public IProjectile RedCandle(Vector2 loc, string direction, int scale, int instance)
        {
            return new RedCandleProjectile(this.fireProjectileSpriteSheet, loc, direction, scale, instance);
        }

        public IProjectile BlueCandle(Vector2 loc, string direction, int scale, int instance)
        {
            return new BlueCandleProjectile(this.fireProjectileSpriteSheet, loc, direction, scale, instance);
        }

        public IProjectile SwordBeam(IPlayer player, int scale, int instance, ExplosionManager explosion)
        {
            return new SwordBeamProjectile(this.swordBeamSpriteSheet, player, scale, instance, explosion);
        }

        public IProjectile SwordExplosion(Vector2 loc, string direction, int scale, int instance)
        {
            return new SwordBeamExplosion(this.swordBeamExplosionSpriteSheet, loc, direction, scale, instance);
        }

        public IProjectile BombExplosionOne(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionOneSpriteSheet, loc, scale, instance);
        }

        public IProjectile BombExplosionTwo(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionTwoSpriteSheet, loc, scale, instance);
        }

        public IProjectile BombExplosionThree(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionThreeSpriteSheet, loc, scale, instance);
        }

        public IProjectile BombExplosionFour(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionFourSpriteSheet, loc, scale, instance);
        }

        public IProjectile BombExplosionFive(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(this.explosionFiveSpriteSheet, loc, scale, instance);
        }
    }
}
