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
            this.Depth = 1.0f;
            this.Mass = DefaultMass;
            this.Rotation = 0.0f;
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
        }

        public void SetDepth()
        {
            if (this.bounds.Bottom != 0)
            {
                this.Depth = 1 - (1 / this.bounds.Bottom);
            }
            else
            {
                this.Depth = 0.0f;
            }
        }

        public void SetLocation()
        {
            this.Location = new Vector2(this.bounds.X + this.BoundsOffset.X, this.bounds.Y + this.BoundsOffset.Y);
        }
    }
}