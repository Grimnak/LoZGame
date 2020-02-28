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

        public void Move()
        {
            this.Location = new Vector2(this.Location.X + this.Velocity.X, this.Location.Y + this.Velocity.Y);
        }

        public void Accelerate()
        {
            this.Velocity = new Vector2(this.Velocity.X + this.Acceleration.X, this.Velocity.Y + this.Acceleration.Y);
        }

    }
}