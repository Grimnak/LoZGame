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
            this.Damage = 0;
            this.Speed = 0;
            this.Resistance = 1;
            this.SpriteEffect = SpriteEffects.None;
            this.Origin = Vector2.Zero;
            this.Rotation = 0.0f;
        }

        public void ModifyDamage(float factor)
        {
            this.Damage = (int)((float)Damage * factor);
        }

        public void ModifySpeed(float factor)
        {
            this.Speed *= factor;
        }
    }
}
