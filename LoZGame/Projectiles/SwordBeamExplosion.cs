namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamExplosion : ProjectileEssentials, IProjectile
    {
        private int lifeTime;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private readonly string direction;
        private readonly float rotation;
        private int damage;
        private ProjectileSpeedConstants projectileSpeedData;

        private static readonly int MaxLifeTime = 20;

        public SwordBeamExplosion(Physics physics)
        {
            SetUp(this);
            Physics = physics;
            lifeTime = MaxLifeTime;
            Speed = projectileSpeedData.SwordBeamExplosionSpeed;
            Width = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            Height = ProjectileSpriteFactory.Instance.SwordBeamExplosionHeight * scale;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, 0, 0);
            Physics.BoundsOffset = new Vector2(Width, Height) / 4;
            Physics.SetLocation();
            Sprite = ProjectileSpriteFactory.Instance.SwordExplosion();
            Physics.Mass = GameData.Instance.ProjectileMassConstants.SwordBeamMass;

            switch (Physics.CurrentDirection)
            {
                case Physics.Direction.NorthWest:
                    Physics.MovementVelocity = new Vector2(-1 * Speed, -1 * Speed);
                    Data.SpriteEffect = SpriteEffects.None;
                    break;
                case Physics.Direction.SouthEast:
                    Physics.MovementVelocity = new Vector2(Speed, Speed);
                    Data.SpriteEffect = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
                    break;
                case Physics.Direction.SouthWest:
                    Physics.MovementVelocity = new Vector2(-1 * Speed, Speed);
                    Data.SpriteEffect = SpriteEffects.FlipVertically;
                    break;
                default:
                    Physics.MovementVelocity = new Vector2(Speed, -1 * Speed);
                    Data.SpriteEffect = SpriteEffects.FlipHorizontally;
                    break;
            }
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void Update()
        {
            base.Update();
            lifeTime--;
            if (lifeTime <= 0)
            {
                IsExpired = true;
            }
        }
    }
}