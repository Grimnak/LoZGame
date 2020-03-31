namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombProjectile : ProjectileEssentials, IProjectile
    {
        private static readonly int MaxLife = 120;
        private int lifeTime;

        public BombProjectile(Physics source)
        {
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.StandardWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.StandardHeight;
            this.Offset = LinkSpriteFactory.LinkHeight;
            this.Source = source;
            this.lifeTime = MaxLife;
            this.InitializeDirection();
            this.Data.Rotation = 0;
            this.Data.SpriteEffect = SpriteEffects.None;
            this.Physics.BoundsOffset = new Vector2(this.Width, this.Heigth);
            this.Physics.Bounds = new Rectangle((this.Physics.Location - this.Physics.BoundsOffset).ToPoint(), new Point(this.Width, this.Heigth));
            this.Physics.SetLocation();
            this.Sprite = ProjectileSpriteFactory.Instance.Bomb();
        }

        public override void Update()
        {
            base.Update();
            lifeTime--;
            if (this.lifeTime <= 0)
            {
                this.IsExpired = true;
                int explosiontype = (int)LoZGame.Instance.GameObjects.Entities.ExplosionManager.Explosion;
                LoZGame.Instance.GameObjects.Entities.ExplosionManager.AddExplosion(explosiontype, this.Physics.Bounds.Center.ToVector2());
            }
        }
    }
}