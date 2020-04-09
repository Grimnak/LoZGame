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
        private const int MaxLife = 300;
        private int lifeTime;

        public FireballProjectile(Physics physics)
        {
            this.Physics = new Physics(physics.Location)
            {
                MovementVelocity = new Vector2(physics.MovementVelocity.X, physics.MovementVelocity.Y)
            };
            this.CollisionHandler = new ProjectileCollisionHandler(this);
            this.Data = new EntityData();
            this.Width = ProjectileSpriteFactory.Instance.FireballWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.FireballHeight;
            this.Physics.BoundsOffset = new Vector2(this.Width, this.Heigth) / 2;
            this.Physics.Bounds = new Rectangle((this.Physics.Location - this.Physics.BoundsOffset).ToPoint(), new Point(Width, Heigth));
            this.Physics.BoundsOffset *= 2;
            this.Physics.SetLocation();
            this.Sprite = ProjectileSpriteFactory.Instance.Fireball();
            this.IsExpired = false;
            this.lifeTime = MaxLife;
            this.Damage = GameData.Instance.ProjectileDamageData.FireballDamage;
            this.Physics.Mass = GameData.Instance.ProjectileMassData.FireballMass;
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
