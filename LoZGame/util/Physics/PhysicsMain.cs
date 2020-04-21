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
                this.boundsLocation = value.Location.ToVector2();
                this.bounds = value;
            }
        }

        public Physics(Vector2 location)
        {
            this.Location = location;
            this.Depth = GameData.Instance.PhysicsConstants.DefaultDepth;
            this.Mass = DefaultMass;
            this.Rotation = GameData.Instance.PhysicsConstants.DefaultRotation;
            this.MovementVelocity = Vector2.Zero;
            this.MovementAcceleration = Vector2.Zero;
            this.KnockbackVelocity = Vector2.Zero;
            this.Friction = Vector2.Zero;
            this.MasterMovement = Vector2.Zero;
            this.bounds = Rectangle.Empty;
            this.BoundsOffset = Vector2.Zero;
            this.boundsLocation = Vector2.Zero;
            this.CurrentDirection = Direction.None;
            this.IsMoveable = true;
            this.Gravity = 0.0f;
        }

        public void SetDepth()
        {
            if (this.Bounds.Bottom != GameData.Instance.PhysicsConstants.ZeroDepth)
            {
                this.Depth = GameData.Instance.PhysicsConstants.DefaultDepth - (GameData.Instance.PhysicsConstants.DefaultDepth / this.Bounds.Bottom);
            }
            else
            {
                this.Depth = GameData.Instance.PhysicsConstants.DefaultDepth / 2;
            }
        }

        public void SetLocation()
        {
            this.Location = new Vector2(this.bounds.X + this.BoundsOffset.X, this.bounds.Y + this.BoundsOffset.Y);
        }
    }
}