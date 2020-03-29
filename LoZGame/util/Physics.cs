namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Physics: PhysicsHelper
    {
        public Physics(Vector2 location)
        {
            this.Location = location;
            this.Depth = 0.0f;
            this.Mass = 1;
            this.MovementVelocity = Vector2.Zero;
            this.MovementAcceleration = Vector2.Zero;
            this.ForceVelocity = Vector2.Zero;
            this.ForceAcceleration = Vector2.Zero;
            this.MasterMovement = Vector2.Zero;
            this.Bounds = Rectangle.Empty;
        }

        public void SetLocation()
        {
            this.Location = new Vector2(this.Bounds.X, this.Bounds.Y);
        }

        public void Move()
        {
            Vector2 totalVelocity = Vector2.Zero;
            totalVelocity.X = this.MovementVelocity.X + this.ForceVelocity.X + this.MasterMovement.X;
            totalVelocity.Y = this.MovementVelocity.Y + this.ForceVelocity.Y + this.MasterMovement.Y;
            this.Bounds = new Rectangle(this.Bounds.X + (int)totalVelocity.X, this.Bounds.Y + (int)totalVelocity.Y, this.Bounds.Width, this.Bounds.Height);
            this.Location = new Vector2(this.Bounds.X, this.Bounds.Y);
        }

        public void Accelerate()
        {
            Vector2 totalAcceleration = Vector2.Zero;
            totalAcceleration.X = this.MovementAcceleration.X + this.ForceAcceleration.X;
            totalAcceleration.Y = this.MovementAcceleration.Y + this.ForceAcceleration.Y;
            this.MovementVelocity = new Vector2(this.MovementVelocity.X + totalAcceleration.X, this.MovementVelocity.Y + totalAcceleration.Y);
        }

        public void SetForce(Vector2 momentum, Vector2 force)
        {
            if (this.Mass > 0)
            {
                this.ForceVelocity = new Vector2(momentum.X / this.Mass, momentum.Y / this.Mass);
                this.ForceAcceleration = new Vector2(force.X / this.Mass, force.Y / this.Mass);
            }
        }

        public Vector2 GetMomentum()
        {
            Vector2 momentum = Vector2.Zero;
            momentum.X = this.MovementVelocity.X + this.ForceVelocity.X;
            momentum.Y = this.MovementVelocity.Y + this.ForceVelocity.Y;
            return momentum;
        }
    }
}