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
            this.Physics.Bounds = new Rectangle((this.Physics.Location - this.Physics.BoundsOffset + new Vector2(4)).ToPoint(), new Point(Width, Heigth) - new Point(8));
            this.Physics.BoundsOffset *= 2;
            this.Physics.BoundsOffset -= new Vector2(4);
            this.Physics.SetLocation();
            this.Sprite = ProjectileSpriteFactory.Instance.Fireball();
            this.IsExpired = false;
            this.Damage = GameData.Instance.ProjectileDamageConstants.FireballDamage;
            this.Physics.Mass = GameData.Instance.ProjectileMassConstants.FireballMass;
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(otherCollider, collisionSide);
            if (otherCollider is IBlock)
            {
                this.CollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
        }
    }
}
