namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombExplosion : IProjectile
    {
        private static readonly int MaxLifeTime = 90;
        private static readonly int DissipateOne = 20;
        private static readonly int DissipateTwo = 5;

        private ISprite sprite;
        private Vector2 Size;
        private int lifeTime;
        private readonly int instance;
        private bool expired;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public BombExplosion(Vector2 location, int scale, int instance)
        {
            this.Physics = new Physics(new Vector2(location.X, location.Y), new Vector2(0, 0), new Vector2(0, 0));
            this.lifeTime = MaxLifeTime;
            this.hostile = true;
            this.instance = instance;
            this.expired = false;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            // do nothing
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime == DissipateOne || this.lifeTime == DissipateTwo)
            {
                this.sprite.Update();
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}