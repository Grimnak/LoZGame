using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class FireballProjectile : ProjectileEssentials, IProjectile
    {
        private const int FrameChange = 15;
        private const int XVelocity = 3;
        private const int YVelocity = 1;
        private const int MaxLife = 300;
        private int lifeTime;

        public FireballProjectile(Physics physics)
        {
            this.SetUp(this);
            this.Physics = physics;
            this.Data = new EntityData();
            this.Width = ProjectileSpriteFactory.Instance.FireballWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.FireballHeight;
            this.Physics.Bounds = new Rectangle((this.Physics.Location - (new Vector2(Width, Heigth) / 2)).ToPoint(), new Point(Width, Heigth));
            this.Physics.BoundsOffset = new Vector2(this.Width, this.Heigth);
            this.Physics.SetLocation();
            this.Sprite = ProjectileSpriteFactory.Instance.Fireball();
            this.IsExpired = false;
            this.lifeTime = MaxLife;
            this.Damage = 2;
        }

        public override void Update()
        {
            base.Update();
            this.lifeTime--;
            if (this.lifeTime <= 0)
            {
                this.IsExpired = true;
            }
        }
    }
}
