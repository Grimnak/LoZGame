﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class MagicBoomerangProjectile : ProjectileEssentials, IProjectile
    {
        private static readonly int MaxDistance = 225;
        private int distTraveled;

        public MagicBoomerangProjectile(Physics source)
        {
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.StandardWidth;
            Heigth = ProjectileSpriteFactory.Instance.BoomerangHeight;
            Offset = (Heigth * 3) / 4;
            StunDuration = LoZGame.Instance.UpdateSpeed * 2;
            Speed = GameData.Instance.ProjectileSpeedConstants.LinkMagicBoomerangSpeed;
            Source = source;
            InitializeDirection();
            Sprite = ProjectileSpriteFactory.Instance.MagicBoomerang();
            Physics.Mass = GameData.Instance.ProjectileMassConstants.BoomerangMass;
        }

        private void ReturnHome()
        {
            if (Physics.Bounds.Intersects(Source.Bounds))
            {
                IsExpired = true;
            }
            else
            {
                Vector2 sourceLoc = new Vector2(Source.Bounds.X + (Source.Bounds.Width / 2), Source.Bounds.Y + (Source.Bounds.Height / 2));
                float diffX = sourceLoc.X - (Physics.Bounds.X + (Physics.Bounds.Width / 2));
                float diffY = sourceLoc.Y - (Physics.Bounds.Y + (Physics.Bounds.Height / 2));
                float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
                Physics.MovementVelocity = new Vector2(diffX / diffTotal * Speed, diffY / diffTotal * Speed);
            }
        }

        public override void Update()
        {
            base.Update();
            if (distTraveled >= MaxDistance)
            {
                Returning = true;
            }
            else
            {
                distTraveled += (int)Speed;
            }
            if (Returning)
            {
                ReturnHome();
            }
            Data.Rotation += MathHelper.PiOver4 / 2;
        }
    }
}