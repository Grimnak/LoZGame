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
        private ProjectileSpeedData projectileSpeedData;

        private static readonly int MaxLifeTime = 20;

        public SwordBeamExplosion(Physics physics)
        {
            this.SetUp(this);
            this.Physics = physics;
            this.lifeTime = MaxLifeTime;
            this.Speed = projectileSpeedData.SwordBeamExplosionSpeed;
            Width = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            Heigth = ProjectileSpriteFactory.Instance.SwordBeamExplosionHeight * scale;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, 0, 0);
            this.Physics.BoundsOffset = new Vector2(Width, Heigth) / 4;
            this.Physics.SetLocation();
            this.Sprite = ProjectileSpriteFactory.Instance.SwordExplosion();

            switch (this.Physics.CurrentDirection)
            {
                case Physics.Direction.NorthWest:
                    this.Physics.MovementVelocity = new Vector2(-1 * Speed, -1 * Speed);
                    this.Data.SpriteEffect = SpriteEffects.None;
                    break;
                case Physics.Direction.SouthEast:
                    this.Physics.MovementVelocity = new Vector2(Speed, Speed);
                    this.Data.SpriteEffect = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
                    break;
                case Physics.Direction.SouthWest:
                    this.Physics.MovementVelocity = new Vector2(-1 * Speed, Speed);
                    this.Data.SpriteEffect = SpriteEffects.FlipVertically;
                    break;
                default:
                    this.Physics.MovementVelocity = new Vector2(Speed, -1 * Speed);
                    this.Data.SpriteEffect = SpriteEffects.FlipHorizontally;
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
            this.lifeTime--;
            if (this.lifeTime <= 0)
            {
                this.IsExpired = true;
            }
        }
    }
}