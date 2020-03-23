namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class DroppedPotion : IItem, IDrop
    {
        private static readonly int DespawnTimer = LoZGame.Instance.UpdateSpeed * 20;
        private static readonly int SpawnTimer = LoZGame.Instance.UpdateSpeed * 1;
        private ISprite sprite;
        private ItemCollisionHandler itemCollisionHandler;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private Vector2 Size;
        private float layer;
        private int lifeTime;
        private bool expired;
        private IProjectile boomerang;
        private bool grabbed;

        public IProjectile Boomerang { get { return this.boomerang; } set { this.boomerang = value; } }

        public bool IsGrabbed { get { return grabbed; } set { this.grabbed = value; } }

        public int PickUpItemTime { get { return -1; } }

        public bool Expired { get { return this.expired; } set { this.expired = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public DroppedPotion(Vector2 loc)
        {
            this.sprite = ItemSpriteFactory.Instance.LifePotion(ItemSpriteFactory.Instance.Scale);
            this.Physics = new Physics(loc, new Vector2(0, -1), new Vector2(0, 0.1f));
            this.Size = new Vector2(ItemSpriteFactory.PotionWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.PotionHeight * ItemSpriteFactory.Instance.Scale);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.lifeTime = 0;
            this.expired = false;
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.grabbed = false;
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.itemCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            if (!grabbed)
            {
                if (otherCollider is IProjectile)
                {
                    this.itemCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
                }
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            itemCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public void ReverseBob()
        {
            this.Physics.Acceleration = new Vector2(0, this.Physics.Acceleration.Y * -1);
        }

        private void TrackBoomerang()
        {
            this.Physics.Velocity = new Vector2(this.boomerang.Physics.Velocity.X, this.boomerang.Physics.Velocity.Y);
        }

        public void Update()
        {
            this.lifeTime++;
            this.Physics.Move();
            this.Physics.Accelerate();
            if (this.lifeTime >= DespawnTimer)
            {
                this.expired = true;
            }
            if (this.lifeTime % 20 == 0 && !grabbed)
            {
                this.ReverseBob();
            }
            if (grabbed)
            {
                this.TrackBoomerang();
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
        }

        public void Draw(Color spriteTint)
        {
            if ((this.lifeTime > SpawnTimer && this.lifeTime < (DespawnTimer - (4 * SpawnTimer))) || this.lifeTime % 4 < 2)
            {
                this.sprite.Draw(this.Physics.Location, spriteTint);
            }
        }
    }
}