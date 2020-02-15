using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
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
        private static int DRAW_SCALE = 2;

        private static ProjectileSpriteFactory instance = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public int Scale
        {
            get { return DRAW_SCALE; }
        }

        public Texture2D SpriteSheet {
            get { return projectileSpriteSheet; }
        }

        private ProjectileSpriteFactory()
        { }


        public void LoadAllTextures(ContentManager content)
        {
            projectileSpriteSheet = content.Load<Texture2D>("Items");
            fireProjectileSpriteSheet = content.Load<Texture2D>("fire");
            swordBeamSpriteSheet = content.Load<Texture2D>("SwordBeam");
            swordBeamExplosionSpriteSheet = content.Load<Texture2D>("SwordBeamSecondary");
            explosionOneSpriteSheet = content.Load<Texture2D>("BombExplosionOne");
            explosionTwoSpriteSheet = content.Load<Texture2D>("BombExplosionTwo");
            explosionThreeSpriteSheet = content.Load<Texture2D>("BombExplosionThree");
            explosionFourSpriteSheet = content.Load<Texture2D>("BombExplosionFour");
            explosionFiveSpriteSheet = content.Load<Texture2D>("BombExplosionFive");
        }

       
        
        public IProjectile Triforce(Vector2 loc, int scale, int instance)
        {
            return new TriforceProjectile(projectileSpriteSheet, loc, scale, instance);
        }
        public IProjectile Boomerang(Link player, int scale, int instance)
        {
            return new BoomerangProjectile(projectileSpriteSheet, player, scale, instance);
        }
        public IProjectile MagicBoomerang(Link player, int scale, int instance)
        {
            return new MagicBoomerangProjectile(projectileSpriteSheet, player, scale, instance);
        }
        public IProjectile Bomb(Vector2 loc, string direction, int scale, int instance, ProjectileManager projectile)
        {
            return new BombProjectile(projectileSpriteSheet, loc, direction, scale, instance, projectile);
        }
        public IProjectile Arrow(Vector2 loc, string direction, int scale, int instance)
        {
            return new ArrowProjectile(projectileSpriteSheet, loc, direction, scale, instance);
        }
        public IProjectile SilverArrow(Vector2 loc, string direction, int scale, int instance)
        {
            return new SilverArrowProjectile(projectileSpriteSheet, loc, direction, scale, instance);
        }
        public IProjectile RedCandle(Vector2 loc, string direction, int scale, int instance)
        {
            return new RedCandleProjectile(fireProjectileSpriteSheet, loc, direction, scale, instance);
        }
        public IProjectile BlueCandle(Vector2 loc, string direction, int scale, int instance)
        {
            return new BlueCandleProjectile(fireProjectileSpriteSheet, loc, direction, scale, instance);
        }
        public IProjectile SwordBeam(Link player, int scale, int instance, ProjectileManager projectile)
        {
            return new SwordBeamProjectile(swordBeamSpriteSheet, player, scale, instance, projectile);
        }
        public IProjectile SwordExplosion(Vector2 loc, string direction, int scale, int instance)
        {
            return new SwordBeamExplosion(swordBeamExplosionSpriteSheet, loc, direction, scale, instance);
        }
        public IProjectile BombExplosionOne(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(explosionOneSpriteSheet, loc, scale, instance);
        }
        public IProjectile BombExplosionTwo(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(explosionTwoSpriteSheet, loc, scale, instance);
        }
        public IProjectile BombExplosionThree(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(explosionThreeSpriteSheet, loc, scale, instance);
        }
        public IProjectile BombExplosionFour(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(explosionFourSpriteSheet, loc, scale, instance);
        }
        public IProjectile BombExplosionFive(Vector2 loc, int scale, int instance)
        {
            return new BombExplosion(explosionFiveSpriteSheet, loc, scale, instance);
        }
    }
}
