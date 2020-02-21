namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Link : PlayerEssentials, IPlayer
    {
        // private Rectangle linkBounds;
        private LinkCollisionHandler linkCollisionHandler;

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
            this.IsDead = false;
            // this.linkBounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
            this.State = new NullState(game, this);
            this.linkCollisionHandler = new LinkCollisionHandler(this, this.State);
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