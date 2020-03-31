namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class RedCandleProjectile : ProjectileEssentials, IProjectile
    {
        private const int LifeTimeMax = 500;
        private const int TravelTime = 100;
        private const float AccelDecay = 0.95f;
        private int lifeTime;

        public RedCandleProjectile(Physics source)
        {
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.FlameWidth;
            this.Height = ProjectileSpriteFactory.Instance.FlameHeight;
            this.Offset = (this.Height * 3) / 4;
            this.Speed = 5;
            this.Acceleration = -0.25f;
            this.Damage = 10;
            this.Source = source;
            this.InitializeDirection();
            this.Data.SpriteEffect = SpriteEffects.None;
            this.Data.Rotation = 0;
            this.Sprite = ProjectileSpriteFactory.Instance.RedCandle();
            this.lifeTime = LifeTimeMax;
            this.Sprite.FrameDelay = 10;
        }

        public override void Update()
        {
            this.lifeTime--;
            this.Sprite.Update();
            if (this.lifeTime >= LifeTimeMax - TravelTime)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
                this.Physics.SetDepth();
                this.Physics.MovementAcceleration *= AccelDecay;
            }
            else if (this.lifeTime <= 0)
            {
                this.IsExpired = true;
            }
        }
    }
}