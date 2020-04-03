namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Physics : PhysicsHelper
    {
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
            this.Bounds = Rectangle.Empty;
            this.BoundsOffset = Vector2.Zero;
            this.CurrentDirection = Direction.None;
        }

        public void SetDepth()
        {
            if (this.Bounds.Bottom != 0)
            {
                this.Depth = 1 - (1 / this.Bounds.Bottom);
            }
            else
            {
                this.Depth = 0.0f;
            }
        }

        public void SetLocation()
        {
            this.Location = new Vector2(this.Bounds.X + this.BoundsOffset.X, this.Bounds.Y + this.BoundsOffset.Y);
        }

        public void Move()
        {

            this.Bounds = new Rectangle(this.Bounds.Location + this.MovementVelocity.ToPoint(), this.Bounds.Size);
            this.SetLocation();
        }

        public void HandleKnockBack()
        {
            this.Bounds = this.Bounds = new Rectangle(this.Bounds.Location + this.KnockbackVelocity.ToPoint(), this.Bounds.Size);
            this.SetLocation();
        }

        public void Accelerate()
        {
            this.MovementVelocity += this.MovementAcceleration;
        }

        public void Knockback(Vector2 momentum)
        {
            if (this.Mass < 10 && this.Mass > 0)
            {
                this.KnockbackVelocity = momentum;
            }
        }

        public Vector2 GetMomentum()
        {
            Vector2 momentum = MovementVelocity *= Mass;
            return momentum;
        }
    }
}