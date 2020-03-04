namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class TriforceProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int FrameChange = 10;

        private int lifeTime;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private bool expired;
        private readonly bool hostile;
        private ISprite sprite;
        private int projectileWidth;
        private int projectileHeight;

        public bool IsHostile => this.hostile;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public static int LifeTime => 200;

        public TriforceProjectile(Vector2 loc)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.TriforceSize * this.scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.TriforceSize * this.scale;
            this.lifeTime = LifeTime;
            this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / (2 * scale)), loc.Y - LinkSize), new Vector2(0, 0), new Vector2(0, 0));
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.expired = false;
            this.hostile = false;
            this.sprite = ProjectileSpriteFactory.Instance.Triforce();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            // do nothing
        }

        public bool IsExpired => this.expired;

        public void Update()
        {
            this.lifeTime--;

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }

            if (this.lifeTime % FrameChange == 0)
            {
                this.sprite.Update();
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}