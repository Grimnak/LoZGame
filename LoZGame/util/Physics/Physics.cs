namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public class Physics : PhysicsHelper
    {
        private Rectangle bounds;
        private Vector2 boundsLocation;

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
            this.Mass = 1;
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

        public void Move()
        {
            this.boundsLocation += this.MovementVelocity;
            this.bounds = new Rectangle(this.boundsLocation.ToPoint(), this.bounds.Size);
            this.SetLocation();
        }

        public void HandleKnockBack()
        {
            this.boundsLocation += this.KnockbackVelocity;
            this.bounds = new Rectangle(this.boundsLocation.ToPoint(), this.bounds.Size);
            this.SetLocation();
        }

        public void Accelerate()
        {
            this.MovementVelocity += this.MovementAcceleration;
        }

        public void Knockback(Vector2 momentum)
        {
            if (IsMoveable)
            {
                Console.WriteLine("set knockback to " + momentum.ToString());
                this.KnockbackVelocity = momentum;
            }
        }

        public float GetMomentum()
        {
            float momentum = MovementVelocity.Length() * Mass;
            Console.WriteLine("returned momentum of " + momentum.ToString());
            return momentum;
        }
    }
}