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
        private ProjectileDamageData projectileDamageData;
        private ProjectileSpeedData projectileSpeedData;

        public RedCandleProjectile(Physics source)
        {
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.FlameWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.FlameHeight;
            this.Offset = (this.Heigth * 3) / 4;
            this.Acceleration = -0.25f;
            this.Speed = projectileSpeedData.CandleSpeed;
            this.Damage = projectileDamageData.CandleDamage;
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