namespace LoZClone
{
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

        public Link(LoZGame game)
        {
            this.Game = game;
            this.CurrentColor = "Green";
            this.CurrentDirection = "Down";
            this.CurrentWeapon = "Wood";
            this.CurrentLocation = new Vector2(150, 200);
            this.CurrentTint = Color.White;
            this.CurrentSpeed = 2;
            this.DamageTimer = 0;
            this.DamageCounter = 0;
            this.State = new NullState(game, this);
            this.bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
            this.linkCollisionHandler = new PlayerCollisionHandler(this);
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

        public void OnCollisionResponse(ICollider otherCollider)
        {
            if (otherCollider is IEnemy)
            {
                this.linkCollisionHandler.OnCollisionResponse((IEnemy)otherCollider);
            }
            else if (otherCollider is IProjectile)
            {
                this.linkCollisionHandler.OnCollisionResponse((IProjectile)otherCollider);
            }
        }
    }
}