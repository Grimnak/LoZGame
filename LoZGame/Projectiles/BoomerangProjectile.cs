namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BoomerangProjectile : ProjectileEssentials, IProjectile
    {
        private static readonly int MaxDistance = 150;
        private int distTraveled;

        public BoomerangProjectile(Physics source)
        {
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.StandardWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.BoomerangHeight;
            this.Offset = (this.Heigth * 3) / 4;
            this.StunDuration = LoZGame.Instance.UpdateSpeed;
            this.Speed = GameData.Instance.ProjectileSpeedConstants.LinkBoomerangSpeed;
            this.Source = source;
            this.InitializeDirection();
            this.Sprite = ProjectileSpriteFactory.Instance.Boomerang();
            this.Physics.Mass = GameData.Instance.ProjectileMassConstants.BoomerangMass;
        }

        private void ReturnHome()
        {
            if (this.Physics.Bounds.Intersects(this.Source.Bounds))
            {
                this.IsExpired = true;
            }
            else
            {
                Vector2 sourceLoc = new Vector2(this.Source.Bounds.X + (this.Source.Bounds.Width / 2), this.Source.Bounds.Y + (this.Source.Bounds.Height / 2));
                float diffX = sourceLoc.X - (this.Physics.Bounds.X + (this.Physics.Bounds.Width / 2));
                float diffY = sourceLoc.Y - (this.Physics.Bounds.Y + (this.Physics.Bounds.Height / 2));
                float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
                this.Physics.MovementVelocity = new Vector2(diffX / diffTotal * Speed, diffY / diffTotal * Speed);
            }
        }

        public override void Update()
        {
            base.Update();
            if (this.distTraveled >= MaxDistance)
            {
                this.Returning = true;
            }
            else
            {
                this.distTraveled += (int)this.Speed;
            }
            if (this.Returning)
            {
                this.ReturnHome();
            }
            this.Data.Rotation += MathHelper.PiOver4 / 2;
        }
    }
}