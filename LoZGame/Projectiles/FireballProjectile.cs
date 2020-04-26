namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class FireballProjectile : ProjectileEssentials, IProjectile
    {
        public FireballProjectile(Physics physics)
        {
            Physics = new Physics(physics.Location)
            {
                MovementVelocity = new Vector2(physics.MovementVelocity.X, physics.MovementVelocity.Y)
            };
            CollisionHandler = new ProjectileCollisionHandler(this);
            Data = new EntityData();
            Width = ProjectileSpriteFactory.Instance.FireballWidth;
            Height = ProjectileSpriteFactory.Instance.FireballHeight;
            Physics.BoundsOffset = new Vector2(Width, Height) / 2;
            Physics.Bounds = new Rectangle((Physics.Location - Physics.BoundsOffset + new Vector2(4)).ToPoint(), new Point(Width, Height) - new Point(8));
            Physics.BoundsOffset *= 2;
            Physics.BoundsOffset -= new Vector2(4);
            Physics.SetLocation();
            Sprite = ProjectileSpriteFactory.Instance.Fireball();
            IsExpired = false;
            Damage = GameData.Instance.ProjectileDamageConstants.FireballDamage;
            Physics.Mass = GameData.Instance.ProjectileMassConstants.FireballMass;
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(otherCollider, collisionSide);
            if (otherCollider is IBlock)
            {
                CollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
        }
    }
}
