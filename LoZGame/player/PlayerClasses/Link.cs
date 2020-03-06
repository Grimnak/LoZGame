namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Link : PlayerEssentials, IPlayer
    {
        private PlayerCollisionHandler linkCollisionHandler;
        private Rectangle bounds;
        private int startingHealth = 5;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Link(Vector2 location)
        {
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.Health = new HealthManager(startingHealth);
            this.linkCollisionHandler = new PlayerCollisionHandler(this);
            this.CurrentColor = "Green";
            this.CurrentDirection = "Up";
            this.CurrentWeapon = "Wood";
            this.CurrentTint = LoZGame.Instance.DungeonTint;
            this.MoveSpeed = 2;
            this.DamageTimer = 0;
            this.State = new IdleState(this);
            this.bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
        }

        private void DamagePushback()
        {
            if (Math.Abs((int)this.Physics.Velocity.X) != 0 || Math.Abs((int)this.Physics.Velocity.Y) != 0)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
            }
        }

        private void HandleDamage()
        {
            if (this.DamageTimer > 0 && this.Health.CurrentHealth > 0)
            {
                this.DamageTimer--;
                if (this.DamageTimer % 10 > 5)
                {
                    this.CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    this.CurrentTint = Color.White;
                }
                this.DamagePushback();
            }
        }

        public override void Update()
        {
            this.HandleDamage();
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;
            this.State.Update();
        }

        public override void Draw()
        {
            this.State.Draw();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
            {
                this.linkCollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.linkCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.linkCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IDoor)
            {
                this.linkCollisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
            else if (otherCollider is IItem)
            {
                this.linkCollisionHandler.OnCollisionResponse((IItem)otherCollider, collisionSide);
            }

        }
        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            this.linkCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }
    }
}