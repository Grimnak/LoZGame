namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public partial class PhysicsEssentials
    {
        public float Depth { get; set; }

        public int Mass { get; set; }

        public float Rotation { get; set; }

        public Vector2 Location { get; set; }

        public Vector2 MovementVelocity { get; set; }

        public Vector2 MovementAcceleration { get; set; }

        public Vector2 ForceVelocity { get; set; }

        public Vector2 ForceAcceleration { get; set; }

        public Vector2 MasterMovement { get; set; }

        public Rectangle Bounds { get; set; }

        public Vector2 BoundsOffset { get; set; }
    }
}