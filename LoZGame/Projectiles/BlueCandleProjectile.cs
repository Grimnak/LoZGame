namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BlueCandleProjectile : ProjectileEssentials, IProjectile
    {
        private const int LifeTimeMax = 500;
        private const int TravelTime = 100;
        private const float AccelDecay = 0.95f;
        private int lifeTime;

        public BlueCandleProjectile(Physics source)
        {
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.FlameWidth;
            Heigth = ProjectileSpriteFactory.Instance.FlameHeight;
            Offset = (Heigth * 3) / 4;
            Speed = GameData.Instance.ProjectileSpeedConstants.CandleSpeed;
            Acceleration = -0.25f;
            Damage = GameData.Instance.ProjectileDamageConstants.CandleDamage;
            Source = source;
            InitializeDirection();
            Data.SpriteEffect = SpriteEffects.None;
            Data.Rotation = 0;
            Sprite = ProjectileSpriteFactory.Instance.BlueCandle();
            lifeTime = LifeTimeMax;
            Sprite.FrameDelay = 10;
            Physics.Mass = GameData.Instance.ProjectileMassConstants.FlameMass;
        }

        public override void Update()
        {
            lifeTime--;
            Sprite.Update();
            if (lifeTime >= LifeTimeMax - TravelTime)
            {
                Physics.Move();
                Physics.Accelerate();
                Physics.SetDepth();
                Physics.MovementAcceleration *= AccelDecay;
            }
            else if (lifeTime <= 0)
            {
                IsExpired = true;
            }
        }
    }
}