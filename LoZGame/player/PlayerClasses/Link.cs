namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class Link : PlayerEssentials, IPlayer
    {
        private PlayerCollisionHandler linkCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Link()
        {
            this.CurrentColor = "Green";
            this.CurrentDirection = "Down";
            this.CurrentWeapon = "Wood";
            this.CurrentLocation = new Vector2(150, 200);
            this.CurrentTint = Color.White;
            this.MoveSpeed = 2;
            this.DamageTimer = 0;
            this.DamageCounter = 0;
            this.State = new NullState(this);
            this.bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
            this.linkCollisionHandler = new PlayerCollisionHandler(this);
        }

        private void DamagePushback()
        {
            if (Math.Abs((int)this.Velocity.X) != 0 || Math.Abs((int)this.Velocity.Y) != 0)
            {
                this.CurrentLocation = new Vector2(this.CurrentLocation.X + this.Velocity.X, this.CurrentLocation.Y + this.Velocity.Y);
                this.Velocity = new Vector2(this.Velocity.X + this.Acceleration.X, this.Velocity.Y + this.Acceleration.Y);
            }
        }

        private void HandleDamage()
        {
            if (this.DamageTimer > 0 && this.DamageCounter < 3)
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
            this.bounds.X = (int)this.CurrentLocation.X;
            this.bounds.Y = (int)this.CurrentLocation.Y;
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
        }
    }
}