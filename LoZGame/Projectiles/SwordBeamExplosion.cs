namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamExplosion : IProjectile
    {
        private int lifeTime;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private readonly string direction;
        private readonly float rotation;
        private bool expired;
        private readonly SpriteEffects effect;
        private ISprite sprite;
        private int projectileWidth;
        private int projectileHeight;
        private ProjectileCollisionHandler collisionHandler;
        private int damage;

        public int StunDuration { get { return 0; } set {/*do nothing*/} }

        public bool Returning { get { return false; } set {/*do nothing*/} }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        

        private static readonly int FrameDelay = 4;
        private static readonly float Speed = 2.5f;
        private static readonly int MaxLifeTime = 20;

        public SwordBeamExplosion(Vector2 location, string direction)
        {
            this.lifeTime = MaxLifeTime;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            projectileHeight = ProjectileSpriteFactory.Instance.SwordBeamExplosionHeight * scale;
            this.direction = direction;
            this.Physics = new Physics(new Vector2(location.X - projectileWidth, location.Y - projectileHeight));
            if (this.direction.Equals("NorthEast"))
            {
                this.Physics.MovementVelocity = new Vector2(Speed, -1 * Speed);
                this.effect = SpriteEffects.FlipHorizontally;
            }
            else if (this.direction.Equals("NorthWest"))
            {
                this.Physics.MovementVelocity = new Vector2(-1 * Speed, -1 * Speed);
                this.effect = SpriteEffects.None;
            }
            else if (this.direction.Equals("SouthEast"))
            {
                this.Physics.MovementVelocity = new Vector2(Speed, Speed);
                this.effect = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
            }
            else
            {
                this.Physics.MovementVelocity = new Vector2(-1 * Speed, Speed);
                this.effect = SpriteEffects.FlipVertically;
            }
            this.damage = 0;
            this.Physics.Bounds = Rectangle.Empty;
            this.expired = false;
            this.sprite = ProjectileSpriteFactory.Instance.SwordExplosion(this.effect);
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
            {
                this.collisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime % FrameDelay == 0)
            {
                this.sprite.Update();
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
            this.Physics.Move();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}