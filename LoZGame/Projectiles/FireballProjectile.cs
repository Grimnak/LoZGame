using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class FireballProjectile : IProjectile
    {
        private const int FrameChange = 15;
        private const int XVelocity = 3;
        private const int YVelocity = 1;
        private const int MaxLife = 300;

        private ICollider collider;
        private ISprite sprite;
        private int lifeTime;
        private readonly float rotation;
        private bool expired;
        private Vector2 Size;
        private ProjectileCollisionHandler collisionHandler;
        private int damage;

        public int StunDuration { get { return 0; } set {/*do nothing*/} }

        public bool Returning { get { return false; } set {/*do nothing*/} }

        public int Damage { get { return damage; } set { damage = value; } }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public FireballProjectile(ICollider collider, Vector2 location, Vector2 velocity)
        {
            if (collider is Dragon || collider is OldMan)
            {
                this.collider = collider;
                this.Physics = new Physics(location, velocity, new Vector2(0, 0));
            }

            this.collisionHandler = new ProjectileCollisionHandler(this);
            float size = (ProjectileSpriteFactory.Instance.FireballHeight * ProjectileSpriteFactory.Instance.Scale) * 1.5f;
            this.Size = new Vector2(ProjectileSpriteFactory.Instance.FireballHeight * ProjectileSpriteFactory.Instance.Scale, ProjectileSpriteFactory.Instance.FireballWidth * ProjectileSpriteFactory.Instance.Scale * 1.5f);
            this.Bounds = new Rectangle((int)this.Physics.Location.X - ProjectileSpriteFactory.Instance.FireballHeight, (int)this.Physics.Location.Y - ProjectileSpriteFactory.Instance.FireballWidth, (int)this.Size.X, (int)this.Size.Y);
            this.sprite = ProjectileSpriteFactory.Instance.Fireball();
            this.expired = false;
            this.lifeTime = MaxLife;
            this.damage = 2;
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.collisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

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
            this.Bounds = new Rectangle((int)this.Physics.Location.X - ProjectileSpriteFactory.Instance.FireballHeight, (int)this.Physics.Location.Y - ProjectileSpriteFactory.Instance.FireballWidth, (int)this.Size.X, (int)this.Size.Y);

            this.Physics.Move();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}
