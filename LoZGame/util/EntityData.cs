namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class EntityData
    {
        public enum Directions
        {
            North,
            South,
            East,
            West,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest,
            Unknown
        } 

        public Directions Direction { get; set; }

        public float MovementSpeed { get; }

        public SpriteEffects SpriteEffect { get; set; }

        public Vector2 Origin { get; set; }

        public float Rotation { get; set; }

        public EntityData()
        {
            this.Direction = Directions.Unknown;
            this.MovementSpeed = 0;
        }
    }
}
