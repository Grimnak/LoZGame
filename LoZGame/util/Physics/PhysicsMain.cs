namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public partial class Physics
    {
        public Rectangle Bounds
        {
            get => bounds;

            set
            {
                boundsLocation = value.Location.ToVector2();
                bounds = value;
            }
        }

        public Physics(Vector2 location)
        {
            Location = location;
            Depth = GameData.Instance.PhysicsConstants.DefaultDepth;
            Mass = DefaultMass;
            Rotation = GameData.Instance.PhysicsConstants.DefaultRotation;
            MovementVelocity = Vector2.Zero;
            MovementAcceleration = Vector2.Zero;
            KnockbackVelocity = Vector2.Zero;
            Friction = Vector2.Zero;
            MasterMovement = Vector2.Zero;
            bounds = Rectangle.Empty;
            BoundsOffset = Vector2.Zero;
            boundsLocation = Vector2.Zero;
            CurrentDirection = Direction.None;
            IsMoveable = true;
            Gravity = GameData.Instance.PhysicsConstants.DefaultGravity;
        }

        public void SetDepth()
        {
            if (Bounds.Bottom != GameData.Instance.PhysicsConstants.ZeroDepth)
            {
                Depth = GameData.Instance.PhysicsConstants.DefaultDepth - (GameData.Instance.PhysicsConstants.DefaultDepth / Bounds.Bottom);
            }
            else
            {
                Depth = GameData.Instance.PhysicsConstants.DefaultDepth / 2;
            }
        }

        public void SetLocation()
        {
            Location = new Vector2(bounds.X + BoundsOffset.X, bounds.Y + BoundsOffset.Y);
        }
    }
}