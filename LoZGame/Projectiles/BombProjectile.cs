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
            this.Height = ProjectileSpriteFactory.Instance.StandardHeight;
            this.Offset = LinkSpriteFactory.LinkHeight;
            this.Source = source;
            this.lifeTime = MaxLife;
            this.InitializeDirection();
            this.Data.Rotation = 0;
            this.Data.SpriteEffect = SpriteEffects.None;
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
                Vector2 bombCenter = new Vector2(this.Physics.Location.X + (this.Width / 2), this.Physics.Location.Y + (this.Height / 2));
                this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, Width, Height);
                LoZGame.Instance.GameObjects.Entities.ExplosionManager.AddExplosion(explosiontype, bombCenter);
            }
        }
    }
}