namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Physics
    {
        public Vector2 Location { get; set; }

        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }

        public Physics(Vector2 location, Vector2 velocity, Vector2 acceleration)
        {
            this.Location = location;
            this.Velocity = velocity;
            this.Acceleration = acceleration;
        }

        public void ResetVelocity()
        {
            this.Velocity = new Vector2(0, 0);
        }

        public void Move()
        {
            this.Location = new Vector2(this.Location.X + this.Velocity.X, this.Location.Y + this.Velocity.Y);
        }

        public void Accelerate()
        {
            this.Velocity = new Vector2(this.Velocity.X + this.Acceleration.X, this.Velocity.Y + this.Acceleration.Y);
        }

        public void StopMovement()
        {
            this.Velocity = new Vector2(0, 0);
            this.Acceleration = new Vector2(0, 0);
        }

        public void StopMovementY()
        {
            this.Velocity = new Vector2(this.Velocity.X + this.Acceleration.X, 0);
            this.Acceleration = new Vector2(this.Acceleration.X, 0);
        }

        public void StopMovementX()
        {
            this.Velocity = new Vector2(0, this.Velocity.Y + this.Acceleration.Y);
            this.Acceleration = new Vector2(0, this.Acceleration.Y);
        }
    }
}