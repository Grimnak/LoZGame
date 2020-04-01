namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class EntityData
    {
        public float MovementSpeed { get; set; }

        public SpriteEffects SpriteEffect { get; set; }

        public Vector2 Origin { get; set; }

        public float Rotation { get; set; }

        public EntityData()
        {
            this.MovementSpeed = 0;
            this.SpriteEffect = SpriteEffects.None;
            this.Origin = Vector2.Zero;
            this.Rotation = 0.0f;
        }
    }
}
