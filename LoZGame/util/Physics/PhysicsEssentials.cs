namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public partial class Physics
    {
        private Rectangle bounds;
        private Vector2 boundsLocation;
        private const int DefaultMass = 10;
        private const float DefaultKnockbackTime = 0.5f;

        public enum Direction
        {
            None,
            North,
            South,
            East,
            West,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest
        }

        public bool IsMoveable { get; set; }

        public float Depth { get; set; }

        public int Mass { get; set; }

        public float Rotation { get; set; }

        public Vector2 Location { get; set; }

        public Vector2 MovementVelocity { get; set; }

        public Vector2 MovementAcceleration { get; set; }

        public Vector2 KnockbackVelocity { get; set; }

        public Vector2 Friction { get; set; }

        public Vector2 MasterMovement { get; set; }

        public Vector2 BoundsOffset { get; set; }

        public Direction CurrentDirection { get; set; }
    }
}