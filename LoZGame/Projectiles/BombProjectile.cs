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
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.StandardWidth;
            Height = ProjectileSpriteFactory.Instance.StandardHeight;
            Offset = LinkSpriteFactory.LinkHeight;
            Source = source;
            lifeTime = MaxLife;
            InitializeDirection();
            Data.Rotation = 0;
            Data.SpriteEffect = SpriteEffects.None;
            Physics.BoundsOffset = new Vector2(Width, Height);
            Physics.Bounds = new Rectangle((Physics.Location - Physics.BoundsOffset).ToPoint(), new Point(Width, Height));
            Physics.SetLocation();
            Sprite = ProjectileSpriteFactory.Instance.Bomb();
        }

        public override void Update()
        {
            base.Update();
            lifeTime--;
            if (lifeTime <= 0)
            {
                IsExpired = true;
                int explosiontype = (int)LoZGame.Instance.GameObjects.Entities.ExplosionManager.Explosion;
                LoZGame.Instance.GameObjects.Entities.ExplosionManager.AddExplosion(explosiontype, Physics.Bounds.Center.ToVector2());
            }
        }
    }
}