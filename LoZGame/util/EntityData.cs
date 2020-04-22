namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class EntityData
    {
        public int Damage { get; set; }

        public float Speed { get; set; }

        public float Resistance { get; set; }

        public SpriteEffects SpriteEffect { get; set; }

        public Vector2 Origin { get; set; }

        public float Rotation { get; set; }

        public EntityData()
        {
            Damage = 0;
            Speed = 0;
            Resistance = 1;
            SpriteEffect = SpriteEffects.None;
            Origin = Vector2.Zero;
            Rotation = 0.0f;
        }

        public void ModifyDamage(float factor)
        {
            Damage = (int)((float)Damage * factor);
        }

        public void ModifySpeed(float factor)
        {
            Speed *= factor;
        }
    }
}
