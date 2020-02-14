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
        public IProjectile Bomb(Vector2 loc, string direction, int scale, int instance)
        {
            return new BombProjectile(projectileSpriteSheet, loc, direction, scale, instance);
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
    }
}
